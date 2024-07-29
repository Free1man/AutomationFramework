using OpenQA.Selenium;

namespace IntegrationTests.PageObjects
{
    public class BookingPage
    {
        private readonly IWebDriver _driver;
        private readonly By _newAppointmentButton = By.Id("newAppointmentButton");
        private readonly By _usernameDisplay = By.Id("usernameDisplay");
        private readonly By _calendar = By.Id("calendar");

        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickNewAppointment() => _driver.FindElement(_newAppointmentButton).Click();
        public string GetUsername() => _driver.FindElement(_usernameDisplay).Text;
        public bool IsAppointmentDisplayed(string appointmentDetails) => _driver.FindElement(_calendar).Text.Contains(appointmentDetails);
    }
}
