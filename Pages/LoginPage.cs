using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Sauce_Demo.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement usernameTxt => wait.Until(d=>d.FindElement(By.Id("user-name")));
        private IWebElement passwordTxt => wait.Until(d=>d.FindElement(By.Id("password")));
        private IWebElement loginButton => wait.Until(d=>d.FindElement(By.Id("login-button")));
        private IWebElement errorMessage => wait.Until(d => d.FindElement(By.CssSelector("[data-test='error']")));



        public void Login(string username, string password)
        {
            TestContext.Progress.WriteLine($"Typing username: {username}");
            usernameTxt.SendKeys(username);
            passwordTxt.SendKeys(password);
            loginButton.Click();
        }

        public string GetErrorMessage()
        {
            TestContext.Progress.WriteLine("Fetching error message text");
            return errorMessage.Text;
        }

    }
}
