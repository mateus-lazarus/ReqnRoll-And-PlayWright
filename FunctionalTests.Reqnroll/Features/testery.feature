Feature: Testery

@homepage
Scenario: Visit Testery Site
	Given I navigate to testery.com
	Then I see the testery links
	When I click on contact link
	Then I see the contact page