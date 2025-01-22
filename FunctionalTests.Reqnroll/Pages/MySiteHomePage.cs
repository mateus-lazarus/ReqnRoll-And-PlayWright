using FunctionalTests.Reqnroll.StepDefinitions;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace FunctionalTests.Reqnroll.Pages;

public class MySiteHomePage(Hooks hooks)
{
    private readonly Hooks _hooks = hooks;

    public ILocator AboutMe => _page?.Locator("a[href='/about-me']");
    public ILocator CalculatorLink => _page?.Locator("a[href='/calculator']");
    public ILocator MockEndpointsToolLink => _page?.Locator("a[href='/mock-endpoints-tool']");
    public ILocator LinkedInLink => _page?.Locator("a[href='https://linkedin.com/in/mateus-lazarus']");
    public ILocator GithubLink => _page?.Locator("a[href='https://github.com/mateus-lazarus']");
    public ILocator MediumLink => _page?.Locator("a[href='https://medium.com/@mateus-lazarus']");

    public async Task GoTo()
    {
        await (await _hooks.playwrightTestManager.AcquirePageAsync()).GotoAsync("https://mateuslazarus.com");
    }
}
