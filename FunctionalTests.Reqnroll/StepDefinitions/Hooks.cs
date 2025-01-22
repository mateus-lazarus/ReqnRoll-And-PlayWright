using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace FunctionalTests.Reqnroll.StepDefinitions;

[Binding]
public class Hooks
{
    public PlaywrightTestManager playwrightTestManager;

    [BeforeTestRun]
    public async Task BeforeScenario()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        playwrightTestManager = new PlaywrightTestManager(4, browser); // 4 concurrent pages
    }
}


public class PagePoolItem(IPage page)
{
    public bool IsBeingUsed { get; set; } = false;
    public IPage Page { get; } = page;
    public int PageNumber { get; set; }
}


public class PlaywrightTestManager
{
    private readonly ConcurrentBag<PagePoolItem> _pagePool;
    private readonly SemaphoreSlim _semaphore;

    public PlaywrightTestManager(int poolSize, IBrowser browser)
    {
        _pagePool = [];
        _semaphore = new SemaphoreSlim(poolSize, poolSize);

        // Initialize page pool
        for (int i = 0; i < poolSize; i++)
        {
            var newPage = browser.NewPageAsync().Result;
            _pagePool.Add(new PagePoolItem(newPage));
        }
    }

    public IPage RetrieveTestPage(int pageNumber)
    {
        foreach (var item in _pagePool)
        {
            if (item.PageNumber == pageNumber)
            {
                return item.Page;
            }
        }

        throw new KeyNotFoundException($"Could not find item with specified key : {pageNumber}");
    }

    public async Task<IPage> AcquirePageAsync(int pageNumber, CancellationToken cancellationToken = default)
    {
        while (true)
        {
            // Wait for semaphore availability
            await _semaphore.WaitAsync(cancellationToken);

            try
            {
                foreach (var item in _pagePool)
                {
                    // Use a more thread-safe approach with lock
                    lock (item)
                    {
                        if (!item.IsBeingUsed)
                        {
                            item.IsBeingUsed = true;
                            item.PageNumber = pageNumber;
                            return item.Page;
                        }
                    }
                }

                // If no page is available, release semaphore and wait
                _semaphore.Release();

                // Introduce a short delay to prevent tight spinning
                await Task.Delay(200, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation
                throw;
            }
        }
    }

    // Alternative with timeout
    public async Task<IPage> AcquirePageAsync(int pageNumber, TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource(timeout);

        try
        {
            return await AcquirePageAsync(pageNumber, cts.Token);
        }
        catch (OperationCanceledException)
        {
            throw new TimeoutException($"Could not acquire a page within the specified timeout : {timeout.Nanoseconds}ns");
        }
    }

    public void ReleasePage(IPage page)
    {
        foreach (var item in _pagePool)
        {
            if (item.Page == page)
            {
                lock (item)
                {
                    item.IsBeingUsed = false;
                }
                return;
            }
        }
    }
}

//[TestClass]
//public class PlaywrightTests
//{
//    private static IBrowser _browser;
//    private static PlaywrightTestManager _pageManager;

//    [ClassInitialize]
//    public static async Task ClassInitialize(TestContext context)
//    {
//        var playwright = await Playwright.CreateAsync();
//        _browser = await playwright.Chromium.LaunchAsync();
//        _pageManager = new PlaywrightTestManager(4, _browser); // 4 concurrent pages
//    }

//    [TestMethod]
//    public async Task TestMethod1()
//    {
//        var page = await _pageManager.AcquirePageAsync();
//        try
//        {
//            // Your test logic here
//            await page.GotoAsync("https://example.com");
//            // Assertions, interactions, etc.
//        }
//        finally
//        {
//            // Always release page back to pool
//            _pageManager.ReleasePage(page);
//        }
//    }

//    [TestMethod]
//    public async Task TestMethod2()
//    {
//        var page = await _pageManager.AcquirePageAsync();
//        try
//        {
//            // Another test logic
//            await page.GotoAsync("https://another-example.com");
//        }
//        finally
//        {
//            _pageManager.ReleasePage(page);
//        }
//    }

//    [ClassCleanup]
//    public static async Task ClassCleanup()
//    {
//        await _browser.DisposeAsync();
//    }
//}
