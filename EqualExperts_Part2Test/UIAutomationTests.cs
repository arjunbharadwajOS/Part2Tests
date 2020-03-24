using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using EqualExperts_Part2Test.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace EqualExperts_Part2Test
{
    // Selenium Tests is created on Chrome Browser - Create, verify and Delete Booking Scenario
    [TestClass]
    public class UIAutomationTests
    {
        public IWebDriver driver = null;

        [TestInitialize]
        [Description("Initialize the webdriver object for chrome browser")]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://hotel-test.equalexperts.io/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.0);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// The below method covers creation of bookings using all input fields.
        /// Verify the created booking by firstName and obtain bookingId.
        /// Delete the created booking based on booking Id.
        /// </summary>
        [TestMethod]
        public void Create_Verify_DeletionBookings()
        {
            ReservationPage reservationPage = new ReservationPage(driver);
            PageFactory.InitElements(driver, reservationPage);

            //Local Variables
            string firstNameText = "first_" + DateTime.Now.ToString("yyyy_MM_dd").ToString();
            string lastNameText = "last_" + DateTime.Now.ToString("yyyy_MM_dd").ToString();
            string priceText = "150";
            string depositStatus = "true";
            string checkInDate = DateTime.Now.ToString("yyyy-MM-dd");
            string checkoutDate = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");

            //Booking Creation - Start
            reservationPage.pageHeaderDisplayed();

            reservationPage.enterFirstName(firstNameText);

            reservationPage.enterLastname(lastNameText);

            reservationPage.enterTotalPrice(priceText);

            reservationPage.selectDepositPaid(depositStatus);

            reservationPage.enterCheckInDate(checkInDate);

            reservationPage.enterCheckOutDate(checkoutDate);

            reservationPage.clickCreateBooking();

            //Booking Creation - End

            //Verify booking is created - Begin

            Assert.IsTrue(reservationPage.firstNameDisplay(firstNameText).Displayed);

            string bookingId = reservationPage.bookingIdCreated(firstNameText);
            Assert.IsNotNull(bookingId);

            //Verify booking is created - End

            // Delete the booking

            reservationPage.clickDeleteButton(bookingId);

        }

        [TestCleanup]
        [Description("Webdriver is closed post execution")]
        public void tearDown()
        {
            driver.Quit();
        }

    }
}
