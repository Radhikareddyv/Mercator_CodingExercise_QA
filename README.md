# Mercator_CodingExercise_QA
The goal is to Add test to  https://www.saucedemo.com/ using the template provided on https://github.com/Radhikareddyv/Mercator_CodingExercise_QA

# Following tools are used:
1. Reqnroll
2. Reqnroll.NUnit
3. Selenium (WebDriver)
4. NUnit 3.14.0
5. Utilises Page Object Model pattern

 #  The tasks is:
1. Verify that highest price item added to the cart

# Running the Tests
Open the Test Explorer in Visual Studio (View -> Test Explorer).
Run all tests or select specific tests to run.

# Project Structure
Features: Contains Gherkin syntax files defining the scenarios.

StepDefinitions: Holds the C# code that maps Gherkin steps to actions.

PageObjects: Defines page objects that represent web pages, providing a clear separation of concerns.

Utilities: Contains Hooks classes and utility functions.

# Writing Tests
Add new Gherkin scenarios in the Features directory.

Implement step definitions in the StepDefinitions directory.

Leverage page objects from the PageObjects directory for better maintainability
