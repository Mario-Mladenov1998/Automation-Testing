using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;






using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class SauceDemoLoginTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();

            options.AddArgument("--disable-notifications");

            options.AddArgument("--disable-infobars");

            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("--guest");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login_With_Valid_Credentials()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            Assert.That(driver.Url, Does.Contain("inventory"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


        [Test]
        public void Login_With_Invalid_Password_Shows_Error()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("wrong_password");

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            var errorMessage = driver.FindElement(By.CssSelector("h3[data-test='error']"));

            Assert.That(errorMessage.Displayed, Is.True);
        }

        [Test]
        public void Products_Page_Loads_After_Login()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            var productsTitle = driver.FindElement(By.ClassName("title"));

            Assert.That(productsTitle.Text, Is.EqualTo("Products"));
        }


        [Test]
        public void Add_Product_To_Cart()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            Thread.Sleep(1000);

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            Thread.Sleep(1000);

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            Thread.Sleep(2000);

            var addToCartButton = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();

            Thread.Sleep(2000);

            var cartBadge = driver.FindElement(By.ClassName("shopping_cart_badge"));

            Assert.That(cartBadge.Text, Is.EqualTo("1"));

        }

        [Test]
        public void Remove_Product_From_Cart()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            var addToCartButton = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();

            var removeButton = driver.FindElement(By.Id("remove-sauce-labs-backpack"));
            removeButton.Click();

            var cartIcon = driver.FindElement(By.ClassName("shopping_cart_link"));

            Assert.That(cartIcon.Displayed, Is.True);
        }

        [Test]
        public void Sort_Products_By_Price_Low_To_High()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            var sortDropDown = driver.FindElement(By.ClassName("product_sort_container"));
            var select = new SelectElement(sortDropDown);

            select.SelectByValue("lohi");

            var firstPrice = driver.FindElement(By.ClassName("inventory_item_price")).Text;

            Assert.That(firstPrice, Does.Contain("7.99"));
        }

        [Test]
        public void Complete_Checkout_Flow()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");

            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            var addToCartButton = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();

            var cartIcon = driver.FindElement(By.ClassName("shopping_cart_link"));
            cartIcon.Click();

            driver.FindElement(By.Id("checkout")).Click();

            driver.FindElement(By.Id("first-name")).SendKeys("Mario");
            driver.FindElement(By.Id("last-name")).SendKeys("Mladenov");

            driver.FindElement(By.Id("postal-code")).SendKeys("1000");
            driver.FindElement(By.Id("continue")).Click();
            driver.FindElement(By.Id("finish")).Click();

            var successMessage = driver.FindElement(By.ClassName("complete-header"));

            Assert.That(successMessage.Text, Does.Contain("Thank you"));
        }
    }
}

