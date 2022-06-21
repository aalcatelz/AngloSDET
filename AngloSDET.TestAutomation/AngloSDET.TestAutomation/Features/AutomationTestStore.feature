Feature: AutomationTestStore
Description: This feature will test basic https://automationteststore.com/ functionality

Scenario: Add 1 product to cart
	Given I have completed preconditions for navigating to automationteststore page
	When I select category 'Apparel & accessories' with subcategory 'Shoes'
	And I add product 'Ruby Shoo Womens Jada T-Bar' to cart
	Then Shopping cart contains added products

Scenario: Add 2 products to cart
	Given I have completed preconditions for navigating to automationteststore page
	When I select category 'Makeup' with subcategory 'Face'
	And I add product 'Delicate Oil-Free Powder Blush' to cart
	When I select category 'Skincare' with subcategory 'Eyes'
	And I add product 'Eye master' to cart
	Then Shopping cart contains added products

Scenario: Cart should be epmty by default
	Given I have completed preconditions for navigating to automationteststore page
	When I open Cart from header panel
	Then Shopping cart should be empty