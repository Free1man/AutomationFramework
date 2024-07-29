using OpenQA.Selenium;

namespace IntegrationTests.PageObjects
{
    public class BookMeetingPage
    {
        private readonly IWebDriver _driver;
        private readonly By _meetingDateField = By.Id("meetingDate");
        private readonly By _meetingTimeField = By.Id("meetingTime");
        private readonly By _bookButton = By.Id("bookButton");
        private readonly By _confirmationMessage = By.Id("confirmationMessage");

        public BookMeetingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void BookMeeting(string date, string time)
        {
            _driver.FindElement(_meetingDateField).SendKeys(date);
            _driver.FindElement(_meetingTimeField).SendKeys(time);
            _driver.FindElement(_bookButton).Click();
        }

        public string GetConfirmationMessage()
        {
            return _driver.FindElement(_confirmationMessage).Text;
        }
    }
}
