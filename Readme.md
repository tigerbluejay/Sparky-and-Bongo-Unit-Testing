# Sparky and Bongo – Unit Testing Projects

## Introduction

**Sparky and Bongo** is a dual-project suite developed by **DotNetMastery** to demonstrate and apply unit testing practices in the .NET ecosystem. The **Sparky** section is an educational walkthrough of unit testing fundamentals using MSTest, NUnit, and xUnit. The **Bongo** section is a real-world ASP.NET MVC application where unit testing is applied in practice. Together, they offer both conceptual understanding and practical implementation, making this repository a powerful resource for learning **Test-Driven Development (TDD)**.

> **Built with:** .NET 6  
> **Unit Testing Frameworks:**  
> - MSTest v2.2.10  
> - NUnit v3.13.3  
> - xUnit v2.4.2  
> - Moq v4.18.4

---

## 📁 Project Structure

This repository consists of two main groups of projects:

### 🔹 Sparky – Unit Testing Demonstrations

Progressive examples covering various types of unit tests and mocking techniques.

#### 1. `SparkyMSTest`

Demonstrates the **AAA pattern** (Arrange, Act, Assert) with simple MSTest tests.

#### 2. `SparkyNUnitTest`

Covers a wide variety of NUnit features, including:

- **Basic assertions:**
  - Assert equality for integers and booleans
  - Assert double values using delta
  - Assert collections for:
    - Equality
    - Containment
    - Emptiness
    - Uniqueness
    - Order
  - Assert string and property values
  - Assert nulls and values within ranges
- **Advanced assertions:**
  - Multiple simultaneous assertions
  - Exception testing with `Assert.Throws`
  - Type checking
- **Moq Framework usage:**
  - Mocking interfaces
  - Setting up methods to return values:
    - For any input
    - Based on specific input values
    - Based on ranges
    - Using out/ref parameters
  - Property mocking
  - Using callbacks to:
    - Capture or manipulate parameters
    - Update external variables
  - Verifying:
    - Method calls
    - Property gets/sets

#### 3. `SparkyXUnitTest`

Mirrors the functionality of `SparkyNUnitTest`, but implemented using **xUnit**.

---

### 🔹 Bongo – Real-World MVC App with Unit Tests

An ASP.NET MVC app that applies unit testing techniques in real-world scenarios.

#### 4. `Bongo.Core.Tests`

- Verifies mock method and property calls
- Validates exceptions and messages
- Uses test cases to evaluate enums
- Extracts parameters using callbacks
- Ensures methods are *not* called under certain conditions

#### 5. `Bongo.DataAccess.Tests`

- Uses **in-memory databases** for lightweight integration testing
- Applies **custom comparers** for collection assertions

#### 6. `Bongo.Models.Tests`

- Tests model-level **data annotations and attributes**

#### 7. `Bongo.Web.Tests`

- Verifies mocked service method calls
- Asserts `IActionResult` types like `ViewResult`, `RedirectToActionResult`
- Returns mock objects with specified properties

---

## ✅ Summary

This repository is ideal for:

- Developers learning unit testing fundamentals
- Teams applying TDD in real-world .NET projects
- Anyone seeking practical **Moq**, **MSTest**, **NUnit**, or **xUnit** examples
### 7) Bongo.Web.Tests
	- Verify a Method in a mocked object is called
	- Verify certain IActionResults like Views or Redirects are returned
	- Setup a Mock object to return another object with specific properties
