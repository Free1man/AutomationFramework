using OpenQA.Selenium;

namespace IntegrationTests.PageObjects
{
    public class NewAppointmentForm
    {
        private readonly IWebDriver _driver;
        private readonly By _appointmentNameField = By.Id("appointmentName");
        private readonly By _dateField = By.Id("date");
        private readonly By _timeField = By.Id("time");
        private readonly By _saveButton = By.Id("saveButton");
        private readonly By _cancelButton = By.Id("cancelButton");
        private readonly By _confirmationMessage = By.Id("confirmationMessage");

        public NewAppointmentForm(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterAppointmentDetails(string name, string date, string time)
        {
            _driver.FindElement(_appointmentNameField).SendKeys(name);
            _driver.FindElement(_dateField).SendKeys(date);
            _driver.FindElement(_timeField).SendKeys(time);
        }

        public void Save() => _driver.FindElement(_saveButton).Click();
        public void Cancel() => _driver.FindElement(_cancelButton).Click();
        public string GetConfirmationMessage() => _driver.FindElement(_confirmationMessage).Text;
    }
}
