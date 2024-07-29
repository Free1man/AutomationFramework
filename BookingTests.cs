using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IntegrationTests.PageObjects;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IntegrationTests.Models;

namespace IntegrationTests
{
    public class BookingTests
    {
        private IWebDriver _driver;
        private HttpClient _client;
        private string _baseUrl = "https://yourappurl.com";
        private string _apiBaseUrl = "https://yourapiurl.com";

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--headless"); 
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--window-size=1920,1080");

            // Specify the working directory explicitly
            var service = ChromeDriverService.CreateDefaultService("/workspaces/AutomationFramework/bin/Debug/net6.0", "chromedriver");
            service.EnableVerboseLogging = true;
            service.LogPath = "chromedriver.log";
            _driver = new ChromeDriver(service, chromeOptions);
            _client = new HttpClient();
        }

        [Test]
        public async Task CreateMerchantAndBookMeeting()
        {
            // Step 1: Create a new merchant and get credentials via HTTP request
            var merchantData = new { name = "Test Merchant", email = "test@merchant.com" };
            var response = await _client.PostAsJsonAsync($"{_apiBaseUrl}/api/merchants", merchantData);
            response.EnsureSuccessStatusCode();
        
            var credentials = await response.Content.ReadFromJsonAsync<MerchantCredentials>();
            Assert.IsNotNull(credentials, "Failed to retrieve merchant credentials");

            // Step 2: Log in to the application using the retrieved credentials
            _driver.Navigate().GoToUrl($"{_baseUrl}/login");
            var loginPage = new LoginPage(_driver);
            loginPage.Login(credentials.Username, credentials.Password);

            // Verify login and navigate to the booking page
            var bookingPage = new BookingPage(_driver);
            Assert.AreEqual(credentials.Username, bookingPage.GetUsername());

            // Step 3: Book a meeting
            bookingPage.ClickNewAppointment();
            var newAppointmentForm = new NewAppointmentForm(_driver);
            newAppointmentForm.EnterAppointmentDetails("Example appointment", "2024-07-30", "10:00 AM");
            newAppointmentForm.Save();

            // Verify appointment is displayed in the calendar
            Assert.IsTrue(bookingPage.IsAppointmentDisplayed("Example appointment"));
            Assert.AreEqual("Appointment saved!", newAppointmentForm.GetConfirmationMessage());
        }

        [TearDown]
        public void Teardown()
        {
            _driver?.Quit();
            _client?.Dispose();
        }
    }
}
