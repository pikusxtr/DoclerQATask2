Feature: DoclerQaSiteNavigation

Scenario: Verify page title on Home Page
	When I open Main page
	Then Page title is equal to "UI Testing Site"

Scenario: Verify page title on Form Page
	Given I open Main page
	When I click Form button
	Then Page title is equal to "UI Testing Site"

Scenario: Verify "h1", "p" html tags content on Home Page
	When I open Main page
	Then Text in "h1" tag is equal to "Welcome to the Docler Holding QA Department"
	And Text in "p" tag is equal to "This site is dedicated to perform some exercises and demonstrate automated web testing."

Scenario: Verify Home button navigation
	Given I open Form page
	When I click Home button
	Then Home Page is displayed

Scenario: Verify UITesting button navigation
	Given I open Form page
	When I click UITesting button
	Then Home Page is displayed

Scenario: Verify Form button navigation
	Given I open Main page
	When I click Form button
	Then Form Page is displayed

Scenario: Verify Form page content: number of buttons and input elements
	When I open Form page
	Then 1 "input" of type "text" element is displayed
	And 1 "button" of type "submit" element is displayed

Scenario: Verify Home button is active on Home Page
	Given I open Main page
	When I click Home button
	Then Home button is active

Scenario: Verify Form button is active on Form Page
	Given I open Main page
	When I click Form button
	Then Form button is active

Scenario: Verify logo image is displayed on Home Page
	When I open Main page
	Then Logo image is displayed

Scenario: Verify logo image is displayed on Form Page
	Given I open Main page
	When I click Form button
	Then Logo image is displayed

Scenario: Verify Error page response status code
	When I send GET request for Error Page
	Then HTTP Response status code is equal to 404 

Scenario Outline: Verify text submitted on the Form Page
	Given I open Form page
	When I submit <text_input>
	Then Hello Page is displayed
	And <result> text is displayed

	Examples:
	| text_input | result         |
	| John       | Hello John!    |
	| Sophia     | Hello Sophia!  |
	| Charlie    | Hello Charlie! |
	| Emily      | Hello Emily!   |
