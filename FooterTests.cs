using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FooterCheckTests.Tests
{
    public class FooterTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Footer_HasRequiredElements()
        {
            driver.Navigate().GoToUrl("https://only.digital/");

            // Проверка: есть <footer>
            var footer = driver.FindElement(By.TagName("footer"));
            Assert.IsNotNull(footer, "Футер не найден на странице");

            // Проверка: есть ссылка mailto:
            var email = footer.FindElement(By.CssSelector("a[href^='mailto:']"));
            Assert.IsTrue(email.Displayed, "Ссылка на e-mail не найдена в футере");

            // Проверка: есть ссылка на VK
            var vk = footer.FindElement(By.CssSelector("a[href*='vk.com']"));
            Assert.IsTrue(vk.Displayed, "Ссылка на VK не найдена в футере");

            // Проверка: есть копирайт
            var copyright =
                footer.FindElements(By.XPath(".//*[contains(text(), '©')]")).FirstOrDefault();
            Assert.IsNotNull(copyright, "Копирайт не найден в футере");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}