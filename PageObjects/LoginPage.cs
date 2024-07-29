using OpenQA.Selenium;

namespace IntegrationTests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly By _emailField = By.Id("email");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("loginButton");
        private readonly By _forgotPasswordLink = By.LinkText("Forgot your password");
        private readonly By _signUpLink = By.LinkText("Sign up");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string email, string password)
        {
            _driver.FindElement(_emailField).SendKeys(email);
            _driver.FindElement(_passwordField).SendKeys(password);
            _driver.FindElement(_loginButton).Click();
        }

        public void ClickForgotPassword() => _driver.FindElement(_forgotPasswordLink).Click();
        public void ClickSignUp() => _driver.FindElement(_signUpLink).Click();
    }
}
