using Microsoft.Playwright;
using Reqnroll;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace FunctionalTests.Reqnroll.StepDefinitions;

[Binding]
public class Hooks(ScenarioContext scenarioContext)
{
    public IPage Page { get; private set; }
    private readonly ScenarioContext _scenarioContext = scenarioContext;

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();

        Page = await context.NewPageAsync();
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        System.Console.WriteLine("After Scenario. Thank you :D");
    }
}
