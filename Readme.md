# DotNetMastery's Sparky and Bongo Unit Test Projects
# Unit Tests Demonstrations (Sparky) and Implementation (Bongo)

This project is a combination of two sets of Projects: Sparky and Bongo.

Both of them deal with Unit Testing.

Sparky constitutes a demonstration with progressive complexity of the fundamentals of Unit Testing. Bongo is an actual real world MVC application where Unit Testing is implemented.

## Features

### 1) SparkyMSTest Project
	Implements a simple test to demonstrate Arrange, Act and Assert

### 2) SparkyNUnitTest Project
	Unit Test demonstrations span various classes. The main takeaways to learn here are:
	Checking the return value of a function:
	- Assert that an int is equal to another
	- Assert that a bool is true or false
	- Implement Test Cases where return values of a function are evaluated
	- Implement Test Cases with Expected results (boolean)
	- Implement delta value checker when testing for doubles equality
	- Asserting that Collections are equal
	- Asserting that Collections contain a member, are not empty, have no members of a value, are ordered and unique.
	- Evaluating the value of a string when it is set to a property
	- Evaluate a property is null
	- Evaluate if an int result is within a range
	- Multiple (simoultaneous) assertions
	- Using Assert.Throws to evaluate things related to exceptions thrown
	- Evaluating that a result is of a certain Type
	- Evaluate whether a method call returns a certain result
	Mocking with Moq Framework:
	- Mocking Interfaces
	- Setting up the method of a mocked object to return something specific
	- Setting up the method of a mocked object to return something specific when receiving inputs of a certain kind.
	- Setting up the method of a mocked object to return something specific when receiving inputs within a certain range.
	- Setting up the method of a mocked object to return an out variable
	- Checking for exact object matches (ref) when setting up mocked object methods
	- Setting up the properties of a mocked object to be something
	- Using Callbacks to capture input parameters and transform them
	- Using Callbacks to increment a counter or variable that has nothing to do with the object being mocked.
	- Verify a the method of a mocked object is called
	- Verify a the property of a mocked object is set or get 

### 3) SparkyXUnitTest Project

	Does the exact same implementation as the previous projects only this time in XUnit.

### 4) Bongo.Core.Tests
	- Verify the method of a mocked object is called
	- Assert an exception is thrown and verify exception message and parameters
	- Check whether properties are correctly set, compare them to dummy expected results
	- Using Test Cases to check alternative enums are set correctly
	- Use callback to extract an input parameter that is passed on a mocked method.
	- Verify a method of a mocked object is not called under certain circumstances.

### 5) Bongo.DataAccess.Tests
	- Using In Memory Databases to substitute for small integration tests
	- Using a Custom Comparer on a CollectionAssert for Equality

### 6) Bongo.Models.Tests
	- Working with Attributes

### 7) Bongo.Web.Tests
	- Verify a Method in a mocked object is called
	- Verify certain IActionResults like Views or Redirects are returned
	- Setup a Mock object to return another object with specific properties
