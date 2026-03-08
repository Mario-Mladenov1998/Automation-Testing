using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests;

public class LoginTests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://automationexercise.com/login");
    }

    [Test]
    public void Open_Login_Page()
    {
        driver.Navigate().GoToUrl("https://automationexercise.com/login");

        Assert.That(driver.Title, Does.Contain("Automation"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }



    [Test]
    public void Login_Page_Contains_Email_Field()
    {
        driver.Navigate().GoToUrl("https://automationexercise.com/login");

        var emailField = driver.FindElement(By.Name("email"));
        Assert.That(emailField.Displayed, Is.True);
    }


    [Test]
    public void Login_Page_Contains_Password_Field()
    {
        driver.Navigate().GoToUrl("https://automationexercise.com/login");

        var passwordField = driver.FindElement(By.Name("password"));
        Assert.That(passwordField.Displayed, Is.True);
    }

    [Test]
    public void Login_Page_Url_Is_Correct()
    {
        driver.Navigate().GoToUrl("https://automationexercise.com/login");

        Assert.That(driver.Url, Does.Contain("login"));
    }
}
