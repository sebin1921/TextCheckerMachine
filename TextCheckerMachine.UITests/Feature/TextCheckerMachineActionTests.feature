Feature: TextCheckerMachineActionTests

@CleanUpBrowser
Scenario Outline: Test To find palindrome in a sentence 
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I find the 'Palindromes' of text 'aabaa madam malayalam you aabaa'
	Then I get '3' unique palindromes as follows:
	| Word      | Count |
	| aabaa     | 2     |
	| malayalam | 1     |
	| madam     | 1     |

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |

@CleanUpBrowser
Scenario Outline: Test To find palindrome in a sentence which  doesn't have palindromes
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I find the 'Palindromes' of text 'I have a dog'
	Then I get a message 'There is no Palindrome in the given text:'

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |

	
@CleanUpBrowser
Scenario Outline: Test To find duplicate words in a sentence 
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I find the 'DuplicateWords' of text 'bus car bus bus train car'
	Then I get the list duplicate as follows:
	| Word | Count |
	| bus  | 3     |
	| car  | 2     |

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |
	| Edge             |

@CleanUpBrowser
Scenario Outline: Test To find duplicate words in a sentence which  doesn't have duplicates
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I find the 'DuplicateWords' of text 'I have a dog'
	Then I get a message 'There is no duplicate words in the given text:'

Examples:
	| Browser          |
	| Chrome           |
	| Firefox          |
	| InternetExplorer |
	| Edge             |

@CleanUpBrowser
Scenario Outline: Test To find if text is a valid html
	Given I use '<Browser>' as a user agent        
	When I am on the start up page of the application
	Then Verify that the page title is 'Home Page'
	When I find if the text '<inputText>' is a valid html
	Then I get the result '<Result>'

Examples:
	| Browser          | inputText          | Result |
	#| Chrome           | <Html>             | false  |
	| Firefox          | <Html>             | false  |
	| InternetExplorer | <Html>             | false  |
	#| Chrome           | <Html></html>      | true   |
	| Firefox          | <Html></html>      | true   |
	| InternetExplorer | <Html></html>     | true   |
	#| Chrome           | <Html><html/> <bod | false  |
	| Firefox          | <Html><html/> <bod | false  |
	| InternetExplorer | <Html><html/> <bod | false  |