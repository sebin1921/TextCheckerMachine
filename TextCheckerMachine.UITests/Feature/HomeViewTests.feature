Feature: HomeViewTests
	
@CleanUpBrowser
Scenario Outline: Test TextCheckerMachine app loaded successfully
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |
	| Edge             |

@CleanUpBrowser
Scenario Outline: Test operations with empty input text
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I find the 'DuplicateWords' of text ''
	Then I get a message 'Input text is required.'

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |

@CleanUpBrowser
Scenario Outline: Test for invalid page
	Given I use '<Browser>' as a user agent 
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I redirect the page to a invalid url
	Then I get a message 'The page you are looking for cannot be found. Please check the URL'

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |


	