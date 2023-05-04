using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Forms
{
    internal class CookiesFormPO : Form
    {
        private IButton AcceptCookieButton => ElementFactory.GetButton(By.XPath("//div[@class='cookies']//button[text()='Not really, no']"), "Hide help button");
        
        public CookiesFormPO() : base(By.ClassName("cookies"), "Accept Cookies form") { }

        public void AcceptCookie() => AcceptCookieButton.Click();
    }
}
