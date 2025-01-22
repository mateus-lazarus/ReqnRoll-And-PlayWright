using FluentAssertions;
using FunctionalTests.Reqnroll.Pages;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace FunctionalTests.Reqnroll.StepDefinitions;

[Binding]
public sealed class MySiteHomePageStepDefinitions(Hooks hooks, MySiteHomePage mySiteHomePage)
{
    private readonly IPage _page = hooks.Page;
    private readonly MySiteHomePage _mySiteHomePage = mySiteHomePage;

    // Given Scenarios 
    [Given("I navigate to mateuslazarus.com")]
    public async Task GivenNavigateToAsync()
    {
        await _mySiteHomePage.GoTo();
    }



    // When Scenarios
    [When("I click on the link to my calculator site")]
    public async Task WhenIClickOnCalculatorLinkAsync()
    {
        await _mySiteHomePage.CalculatorLink.ClickAsync();
    }

    [When("I click on the link to my portfolio site")]
    public async Task WhenIClickOnPortfolioLinkAsync()
    {
        await _mySiteHomePage.AboutMe.ClickAsync();
    }

    [When("I click on the link to my mockendpointstool site")]
    public async Task WhenIClickOnMockEndpointsToolLinkAsync()
    {
        await _mySiteHomePage.MockEndpointsToolLink.ClickAsync();
    }

    [When("I click on the link to my linkedin page")]
    public async Task WhenIClickOnLinkedinLinkAsync()
    {
        await _mySiteHomePage.LinkedInLink.ClickAsync();
    }

    [When("I click on the link to my github page")]
    public async Task WhenIClickOnGithubLinkAsync()
    {
        await _mySiteHomePage.GithubLink.ClickAsync();
    }

    [When("I click on the link to my medium page")]
    public async Task WhenIClickOnMediumLinkAsync()
    {
        await _mySiteHomePage.MediumLink.ClickAsync();
    }



    // Then Scenarios
    [Then("I should see my link tree page")]
    public async Task ThenISeeTheLinksAsync()
    {
        // Validate the links on the page are visible
        var links = new[]
        {
            _mySiteHomePage.CalculatorLink,
            _mySiteHomePage.AboutMe,
            _mySiteHomePage.MockEndpointsToolLink,
            _mySiteHomePage.LinkedInLink,
            _mySiteHomePage.GithubLink,
            _mySiteHomePage.MediumLink
        };

        foreach (var link in links)
        {
            var isVisible = await link.IsVisibleAsync();
            isVisible.Should().BeTrue();
        }
    }

    [Then("I should see calculator page")]
    public void ThenISeeTheCalculatorPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Be("https://mateuslazarus.com/calculator/");
    }

    [Then("I should see the portfolio page")]
    public void ThenISeeThePortfolioPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Be("https://mateuslazarus.com/about-me");
    }

    [Then("I should see mockendpointstool page")]
    public void ThenISeeTheMockEndpointsToolPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Be("https://mateuslazarus.com/mock-endpoints-tool");
    }

    [Then("I should see the linkedin page")]
    public void ThenISeeTheLinkedinPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Contain("https://www.linkedin.com/");
    }

    [Then("I should see the github page")]
    public void ThenISeeTheGithubPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Be("https://github.com/mateus-lazarus");
    }

    [Then("I should see the medium page")]
    public void ThenISeeTheMediumPage()
    {
        string url = _page?.Url ?? string.Empty;
        url.Should().Be("https://medium.com/@mateus-lazarus");
    }
}