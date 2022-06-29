Feature: SearchProduct
	Simple calculator for adding two numbers

Background: 
	Given User is on homepage

@tag1
Scenario: To test if the User can search an existing product using Search Functionality
	Given User is on homepage
	When User enters product name in search bar and User press Enter
	Then Products related the searched product should be displayed