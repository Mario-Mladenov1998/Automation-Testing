# UI automation project built with **Selenium WebDriver**, **C#**, and **NUnit**.
The project demonstrates automated testing of login functionality and e-commerce user flows.

---

## Technologies Used

- C#
- .NET
- Selenium WebDriver
- NUnit
- Visual Studio

---

## Tested Websites

Automation Exercise  
https://automationexercise.com

SauceDemo  
https://www.saucedemo.com

---

## Automated Test Scenarios

### Automation Exercise Tests
- Opens the login page
- Verifies that the page title contains "Automation"
- Verifies that the Email input field is visible
- Verifies that the Password input field is visible
- Verifies that the URL contains "login"

### SauceDemo Tests
- Login with valid credentials
- Login with invalid credentials
- Verify products page loads after login
- Add product to cart
- Remove product from cart
- Sort products by price (Low --> High)
- Complete checkout flow

---
## Project Structure


SeleniumTests
LoginTests.cs
SauceDemoLoginTests.cs


---

## How to Run the Tests

1. Open the project in **Visual Studio**
2. Restore NuGet packages
3. Open **Test Explorer**
4. Click **Run All Tests**

---

## Purpose of the Project

This project demonstrates:

- Browser automation
- UI element validation
- Basic functional testing
- Automated test structure using Selenium and NUnit
## Project Structure
- SeleniumTests/
- LoginTests.cs
- SauceDemoLoginTests.cs
- SeleniumTests.csproj
- README.md

