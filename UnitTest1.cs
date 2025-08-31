using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void Test1()
        {

            // Sudo code for setting up Selenium
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com");
            // 2a. Maximize to browser window
            driver.Manage().Window.Maximize();
            // 3. Find The element
            IWebElement webElement = driver.FindElement(By.Name("q"));
            // 4. Type in the element
            webElement.SendKeys("Selenium");
            // 5. Click on the element
            webElement.SendKeys(Keys.Return);