using FunctionalTests.Reqnroll.StepDefinitions;
using Microsoft.Playwright;
using System.Threading.Tasks;


namespace FunctionalTests.Reqnroll.Pages;

public class TesteryHomePage(Hooks hooks)
{
    private readonly IPage _page = hooks.Page;

    public ILocator PlatformLink => _page?.Locator("a[href='/platform']");
    public ILocator ContactLink => _page?.Locator("a[href='/contact'].nav-link");
    public ILocator GetStartedButton => _page?.Locator("button");

    public async Task GoTo()
    {
        if (_page is null)
        {
            return;
        }

        await _page.GotoAsync("https://testery.com");
    }
}
