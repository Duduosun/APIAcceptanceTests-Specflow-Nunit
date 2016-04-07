Feature: Search
	In order to test the Search functionality
	As a user
	I should be able to search items with both search and advanced search feature

Scenario Outline: Search testing through API
Given I want to search for <searchitem> 
When I search for it
Then the response to be as <status>

Examples: 
| searchitem | status |
| Canon      | OK     |
| Nikon     | OK     |  

Scenario Outline: Advanced Search testing through API
Given I want to search for <searchitem> 
When I search for it with advanced parameters
 | minPrice | maxPrice | minMp | maxMp |
 | 100      | 500      | 12    | 18    |
 | 200      | 500      | 12    | 18    |
Then the response to be as <status>

Examples: 
| searchitem | status | 
| Pentax     |   OK     | 
| Leica      |   OK     | 


