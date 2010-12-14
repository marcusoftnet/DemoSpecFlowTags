Feature: Tag demonstrator
	In order to show the capabilities of tags in SpecFlow
	As a developer
	I want to write scenarios that has tags and show their usage in code


@ignore
Scenario: Ignored scenario
	Given that my scenario has the @ignore tag
	When I run the scenario
	Then the scenario is ignored
		And the missing step definitions are not reported 

Scenario: A scenario without tag
	Given that my scenario has no tags
	When I run the scenario
	Then before scenario hook without tag is run
	
@testTag1
Scenario: A scenario with 1 tag
	Given that my scenario has 1 tag
	When I run the scenario
	Then before scenario hook with the tag is run

@testTag1 @testTag2 @testTag3
Scenario: A scenario with 3 tags
	Given that my scenario has 3 tags
	When I run the scenario
	Then before scenario hook with the tags is run
