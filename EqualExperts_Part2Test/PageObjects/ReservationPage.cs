using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EqualExperts_Part2Test.PageObjects
{
        //Page Factory Class for Reservation Page - Web Elements and Functions are declared here
        public class ReservationPage
        {

            public IWebDriver _driver;

            public ReservationPage(IWebDriver driver)
            {
                _driver = driver;
            }

            [FindsBy(How = How.XPath, Using = "//h1[text()='Hotel booking form']")]
            public IWebElement pageHeader { get; set; }

            [FindsBy(How = How.Id, Using = "firstname")]
            public IWebElement firstName { get; set; }

            [FindsBy(How = How.Id, Using = "lastname")]
            public IWebElement lastName { get; set; }

            [FindsBy(How = How.Id, Using = "totalprice")]
            public IWebElement totalPrice { get; set; }

            [FindsBy(How = How.Id, Using = "depositpaid")]
            public IWebElement depositPaid { get; set; }

            [FindsBy(How = How.Id, Using = "checkin")]
            public IWebElement checkIn { get; set; }

            [FindsBy(How = How.Id, Using = "checkout")]
            public IWebElement checkOut { get; set; }

            [FindsBy(How = How.XPath, Using = "//*[@onclick='createBooking()']")]
            public IWebElement createBooking { get; set; }

            [FindsBy(How = How.XPath, Using = "")]
            public IWebElement firstNameSavedText { get; set; }

            [FindsBy(How = How.XPath, Using = "")]
            public IWebElement bookingId { get; set; }

            [FindsBy(How = How.XPath, Using = "")]
            public IWebElement deleteButton { get; set; }


            public bool pageHeaderDisplayed()
            {

                var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Hotel booking form']")));
                return pageHeader.Displayed;
            }


            public void enterFirstName(string firstNameText)
            {
                firstName.SendKeys(firstNameText);
            }

            public void enterLastname(string lastNameText)
            {
                lastName.SendKeys(lastNameText);
            }

            public void enterTotalPrice(string totalPriceText)
            {
                totalPrice.SendKeys(totalPriceText);
            }

            public void selectDepositPaid(string depositPaidText)
            {
                var selectElement = new SelectElement(depositPaid);
                selectElement.SelectByText(depositPaidText);
            }

            public void enterCheckInDate(string checkInDate)
            {
                checkIn.SendKeys(checkInDate);
            }

            public void enterCheckOutDate(string checkOutDate)
            {
                checkOut.SendKeys(checkOutDate);
            }

            public void clickCreateBooking()
            {
                createBooking.Click();
            }

            public IWebElement firstNameDisplay(string firstNameText)
            {
                var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='" + firstNameText + "']")));
                firstNameSavedText = _driver.FindElement(By.XPath("//*[text()='" + firstNameText + "']"));
                return firstNameSavedText;
            }

            public string bookingIdCreated(string firstNameText)
            {
                bookingId = _driver.FindElement(By.XPath("//*[text()='" + firstNameText + "']/../.."));
                return bookingId.GetAttribute("id");
            }

            public void clickDeleteButton(string bookingId)
            {
                deleteButton = _driver.FindElement(By.XPath("//*[@id='" + bookingId + "']//input"));

                string buttonText = deleteButton.GetAttribute("value").ToString().Trim();
                bool deleteExits = buttonText.Equals("delete", StringComparison.OrdinalIgnoreCase);
                if (deleteExits)
                {
                    deleteButton.Click();
                }

            }

        }

    

}
