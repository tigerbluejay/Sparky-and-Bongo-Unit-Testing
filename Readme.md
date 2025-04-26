# DotNetMastery's Sparky and Bongo Unit Test Projects
# Unit Tests Demonstrations (Sparky) and Implementation (Bongo)

Introduction
Sparky and Bongo is a dual-project suite developed by DotNetMastery to demonstrate and apply unit testing practices in the .NET ecosystem. The Sparky section is an educational walkthrough of unit testing fundamentals using MSTest, NUnit, and xUnit. The Bongo section is a real-world ASP.NET MVC application where unit testing is applied in practice. Together, they offer both conceptual understanding and practical implementation, making this repository a powerful resource for learning Test-Driven Development (TDD).

Built with .NET 6
Unit Testing Frameworks used:
• MSTest v2.2.10
• NUnit v3.13.3
• xUnit v2.4.2
• Moq v4.18.4

Project Structure
This repository consists of two main groups of projects:

🔹 Sparky – Unit Testing Demonstrations
Progressive examples covering various types of unit tests and mocking techniques.

1. SparkyMSTest
Demonstrates the AAA pattern (Arrange, Act, Assert) with simple MSTest tests.

2. SparkyNUnitTest
Covers a wide variety of NUnit features, including:

Basic assertions:

Assert equality for integers and booleans

Assert double values using delta

Assert collections for equality, membership, order, uniqueness

Assert string and property values

Assert nulls and value ranges

Advanced assertions:

Multiple simultaneous assertions

Exception testing with Assert.Throws

Type checking

Moq Framework usage:

Mocking interfaces

Setting up mock methods to return specific values (based on input, ranges, or by ref/out)

Property mocking

Using callbacks to capture or manipulate parameters

Verifying method calls and property access

3. SparkyXUnitTest
Mirrors the functionality in SparkyNUnitTest, using xUnit for demonstration.

🔹 Bongo – Real-World MVC App with Unit Tests
An ASP.NET MVC app that applies unit testing techniques in real-world scenarios.

4. Bongo.Core.Tests
Verifying mock calls and property sets

Validating exception types, messages, and parameters

Testing enum-based logic with test cases

Extracting parameters via callbacks

Ensuring methods are not called under specific conditions

5. Bongo.DataAccess.Tests
Using In-Memory Databases for lightweight integration tests

Applying Custom Comparers for collection equality

6. Bongo.Models.Tests
Testing data annotations and attributes

7. Bongo.Web.Tests
Verifying mocked service calls

Asserting specific IActionResult types (e.g., ViewResult, RedirectToActionResult)

Returning mock data with specific properties

Summary
This repository is ideal for:

Developers learning unit testing fundamentals

Teams applying TDD in real-world .NET projects

Anyone seeking practical Moq examples with MSTest, NUnit, or xUnit
### 7) Bongo.Web.Tests
	- Verify a Method in a mocked object is called
	- Verify certain IActionResults like Views or Redirects are returned
	- Setup a Mock object to return another object with specific properties
