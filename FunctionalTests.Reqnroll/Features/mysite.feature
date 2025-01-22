Feature: My Own Site

@homepage-linktree
Scenario: Visit My Linktree Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page

@homepage-to-portfolio
Scenario: Visit My Portfolio Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page
	When I click on the link to my portfolio site
	Then I should see the portfolio page

@homepage-to-calculator
Scenario: Visit My Calculator Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page
	When I click on the link to my calculator site
	Then I should see calculator page

@homepage-to-mock-endpoints-tool
Scenario: Visit My MockEndpointsTool Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page
	When I click on the link to my mockendpointstool site
	Then I should see mockendpointstool page

@homepage-to-linkedin
Scenario: Visit My LinkedIn Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page
	When I click on the link to my linkedin page
	Then I should see the linkedin page

@homepage-to-github
Scenario: Visit My Github Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page
	When I click on the link to my github page
	Then I should see the github page

@homepage-to-medium
Scenario: Visit My Medium Site
	Given I navigate to mateuslazarus.com
	Then I should see my link tree page
	When I click on the link to my medium page
	Then I should see the medium page
