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

        /* [TestInitialize]
         public void Startup()
         {
             new DriverManager().SetUpDriver(new FirefoxConfig());
             _driver = new FirefoxDriver();
         }*/

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestingBooksTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Books");
            Assert.AreEqual("Books - BookTrackingWeb", _driver.Title);

            _driver.Quit();

        }

        [TestMethod]
        public void TestingCategoryTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Categories");
            Assert.AreEqual("Categories - BookTrackingWeb", _driver.Title);

            _driver.Quit();

        }

        [TestMethod]
        public void TestingBookQuotesTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookQuotes");
            Assert.AreEqual("BookQuotes - BookTrackingWeb", _driver.Title);

            _driver.Quit();

        }

        [TestMethod]
        public void TestingBookReadTracksTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookReadTracks");
            Assert.AreEqual("BookReadTracks - BookTrackingWeb", _driver.Title);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBooksButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/index");
            Assert.IsTrue(_driver.FindElement(By.Id("Books")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingCategoryButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/index");
            Assert.IsTrue(_driver.FindElement(By.Id("Category")).Displayed);

            _driver.Quit();
        }
        [TestMethod]
        public void TestingBookQuotesAddButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookQuotes");
            Assert.IsTrue(_driver.FindElement(By.Id("bookQuotesAdd")).Displayed);

            _driver.Quit();
        }
        [TestMethod]
        public void TestingBookQuotesEditButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookQuotes");
            Assert.IsTrue(_driver.FindElement(By.Id("bookQuotesEdit")).Displayed);

            _driver.Quit();
        }
        [TestMethod]
        public void TestingBookQuotesDeleteButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookQuotes");
            Assert.IsTrue(_driver.FindElement(By.Id("bookQuotesDelete")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBookReadTracksAddButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookReadTracks");
            Assert.IsTrue(_driver.FindElement(By.Id("addButton")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBookReadTracksEditButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookReadTracks");
            Assert.IsTrue(_driver.FindElement(By.Id("bookReadTracksEdit")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBookReadTracksDeleteButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/BookReadTracks");
            Assert.IsTrue(_driver.FindElement(By.Id("bookReadTracksDelete")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBookAddButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Books");
            Assert.IsTrue(_driver.FindElement(By.Id("addButton")).Displayed);

            _driver.Quit();
        }

       

             [TestMethod]
        public void TestingBookEditButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Books");
            Assert.IsTrue(_driver.FindElement(By.Id("booksEdit")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBookDeleteButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Books");
            Assert.IsTrue(_driver.FindElement(By.Id("booksDelete")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingBookStatusButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Books");
            Assert.IsTrue(_driver.FindElement(By.Id("booksStatus")).Displayed);

            _driver.Quit();
        }


        [TestMethod]
        public void TestingCategoryAddButton()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Categories");
            Assert.IsTrue(_driver.FindElement(By.Id("addCTButton")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingCategoryEdit()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Categories");
            Assert.IsTrue(_driver.FindElement(By.Id("categoriesEdit")).Displayed);

            _driver.Quit();
        }

        [TestMethod]
        public void TestingCategoryDelete()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Categories");
            Assert.IsTrue(_driver.FindElement(By.Id("categoriesDelete")).Displayed);

            _driver.Quit();
        }
    }
}