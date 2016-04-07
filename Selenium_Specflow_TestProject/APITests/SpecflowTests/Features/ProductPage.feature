Feature: ProductPage
	In order to test the product page functionality
	As a user
	I want to view the product and its details

Scenario Outline: Camera Product Page testing through API
Given I have a <Product>
When I retrieve the product
Then the response should be as <status>

Examples: 
| Product         | status |
| olympus-pen-f   | OK    |
| nonexistingitem | InternalServerError  |
