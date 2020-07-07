Feature: Google Search
	In order to learn more about specflow
	As earger learner
	I want to search such information from google

Scenario: Search specflow in google
	Given I navigate to Google site
	When I search with keyword "specflow"
	Then I should see related citing