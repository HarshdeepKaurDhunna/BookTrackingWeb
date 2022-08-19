using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace BookTrackingWeb

{
    [TestClass]
    public class UITest
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            _driver = new FirefoxDriver();
        }

        [TestMethod]
        public void TestingBooksTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/Books/");
            Assert.AreEqual("Books", _driver.Title);

            _driver.Quit();

        }

        [TestMethod]
        public void TestingCategoryTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/Categories/");
            Assert.AreEqual("Categories", _driver.Title);

            _driver.Quit();

        }

        [TestMethod]
        public void TestingBookQuotesTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/BookQuotes/");
            Assert.AreEqual("BookQuotes", _driver.Title);

            _driver.Quit();

        }

        [TestMethod]
        public void TestingBookReadTracksTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/BookReadTracks/");
            Assert.AreEqual("BookReadTracks", _driver.Title);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBooksButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_driver.FindElement(By.Name("Book")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingCategoryButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_driver.FindElement(By.Name("Category")).Displayed);

            _driver.Quit();
        }


    }
}

