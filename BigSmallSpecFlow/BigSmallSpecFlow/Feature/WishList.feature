Feature: WishList
	Simple calculator for adding two numbers

Background: 
	Given User is on homepage

@tag1
Scenario: To check if the User can add the item to the WishList
	Given User is on homepage
	When User searches a valid product and User press Enter
	And User selects the item 
	And User clicks on add to wishlist
	And User clicks on wish list
	Then User should be able to view the item added to the wish list