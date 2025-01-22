using FluentAssertions;
using FunctionalTests.Reqnroll.Pages;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;


namespace FunctionalTests.Reqnroll.StepDefinitions;

[Binding]
public sealed class TesteryHomePageStepDefinitions(
    Hooks hooks, TesteryHomePage testeryHomePage
)
{
    private readonly IPage _page = hooks.Page;
    private readonly TesteryHomePage _testeryHomePage = testeryHomePage;

    [Given("I navigate to testery.com")]
    public async Task GivenNavigateToAsync()
    {
        await _testeryHomePage.GoTo();
    }

    [When("I click on contact link")]
    public async Task WhenIClickonContactLinkAsync()
    {
        await _testeryHomePage.ContactLink.ClickAsync();
    }

    [Then("I see the testery links")]
    public async Task ThenISeeTheLinksAsync()
    {
        bool linkIsThere = await _testeryHomePage.PlatformLink.IsVisibleAsync();
        bool linkTwoIsThere = await _testeryHomePage.ContactLink.IsVisibleAsync();
        bool getStartedButton = await _testeryHomePage.GetStartedButton?.Last.IsVisibleAsync();

        linkIsThere.Should().BeTrue();
        linkTwoIsThere.Should().BeTrue();
        getStartedButton.Should().BeTrue();
    }

    [Then("I see the contact page")]
    public void ThenISeeTheContactPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Be("https://testery.com/contact");
    }
}