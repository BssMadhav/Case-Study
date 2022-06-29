Feature: AddToCart
	Simple calculator for adding two numbers

Background: 
	Given User is on homepage

@tag1
Scenario: To verify if the User can add the selected item to cart
	Given User is on homepage
	When User searches for an item and selects an item
	And User clicks on Add to Cart
	Then User should be able to view the item in shopping cart