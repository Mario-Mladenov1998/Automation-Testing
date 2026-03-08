EADME
# Selenium Login Page Tests

This project contains automated UI tests for the Login page of the Automation Exercise website.

The tests are written in **C# using Selenium WebDriver and NUnit** and verify that the login page and its core elements are working correctly.

## Technologies Used

# C#
# .NET
# Selenium WebDriver
# NUnit
# Visual Studio

## Test Website

https://automationexercise.com/login

## Automated Test Cases

The following UI tests are implemented:

1. **Open_Login_Page**
   # Navigates to the login page
   # Verifies that the page title contains "Automation"

2. **Login_Page_Contains_Email_Field**
   # Opens the login page
   # Verifies that the Email input field is visible

3. **Login_Page_Contains_Password_Field**
   # Opens the login page
   # Verifies that the Password input field is visible

4. **Login_Page_Url_Is_Correct**
   # Opens the login page
   # Verifies that the URL contains "login"

## Project Structure




## How to Run the Tests

1. Open the project in **Visual Studio**
2. Restore NuGet packages
3. Open **Test Explorer**
4. Run the tests

## Purpose

This project demonstrates basic **UI automation testing using Selenium and NUnit**, including:

# Browser automation
# Element validation
# Page verification
# Basic test structure
