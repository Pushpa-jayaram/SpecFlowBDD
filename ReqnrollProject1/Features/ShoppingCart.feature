Feature: Shopping Cart

Scenario: Add product to cart successfully
	Given user launches application
	When user searches for "MacBook"
	And user opens the product
	And user adds product to cart
	And user opens shopping cart
	Then product should be displayed in cart