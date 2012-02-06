Feature: Document
	In order to document the current system state in a human readable format
	As a developer
	I want to be able to create a hierarchical document of information

Scenario: Can create a document
	Given I have a builder
	When I create a document
	Then the document should be empty
	 And the document should be a list of alerts

Scenario: Can create a document with a title
	Given I have a builder
	 And I have some text
	When I create a document with the text
	Then the document should contain a text block with a value of the text as the last alert

Scenario: Can add a seperator
	Given I have a document
	When I add a seperator
	Then the document should contain a seperator as the last alert

Scenario: Can add a url
	Given I have a document
	 And I have some text
	 And I have some url
	When I add a url wit the text as the name
	Then the document should contain a url as the last alert with the url and text

Scenario: Can add an exception as a list of alerts
	Given I have a document
	 And I have an exception
	When I add a exception as a list
	Then the document should contain a url as the last alert

Scenario: Can add an exception as a table
	Given I have a document
	 And I have an exception
	When I add a exception as a table
	Then the document should contain a url as the last alert

Scenario: Can add an object as a table
	Given I have a document
	 And I have an object
	When I add a object as a table
	Then the document should contain a url as the last alert

Scenario: Can add a list of object as a list of tables
	Given I have a document
	And I have a list of  objects
	When I add a list of objects as a list of tables
	Then the document should contain a url as the last alert