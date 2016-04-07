Feature: Categories
	In order to test the categories and subcategories functionality
	As a user
	I want to test the categories menu through the API layer by filtering with categories and subcategories


Scenario Outline: Categories testing through API
Given I want to filter items based on <subcategory> and <productitem> 
When I filter and search for it
Then the response should be with <status>

Examples: 

| subcategory | productitem   | status   |
| brand       | Canon        | OK       |
| type        | Ultracompact | OK       |
| price       | 2000         | OK       |
| sensor      | Full-Frame   | OK       |
| color       | Black        | OK       |
| feature     | GPS          | OK       |
| unknown     | Sony         | NotFound |


