using AngleSharp.Common;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Forms
{
    internal class HomePagePO : Form
    {
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//div[@class='login-form__field-row']//input"), "Password input");
        private ITextBox EmailTextBox => ElementFactory.GetTextBox(By.XPath("//form//input[contains(@placeholder,'email')]"), "Email input");
        private ITextBox DomainTextBox => ElementFactory.GetTextBox(By.XPath("//form//input[contains(@placeholder,'Domain')]"), "Domain input");
        private IButton DomainDropDown => ElementFactory.GetButton(By.XPath("//div[@class='dropdown__header']"), "Drop Down selector");
        private IButton AcceptTermsButton => ElementFactory.GetButton(By.XPath("//span[@class='checkbox__box']"), "CheckBox accept Terms");
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//a[@class='button--secondary']"), "Next page button");
        private ILabel Timer => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'timer')]"), "Timer");
        private IList<ILabel> Domains => ElementFactory.FindElements<ILabel>(By.XPath("//div[@class='dropdown__list']//div[text()!='other']"));

        public HomePagePO() : base(By.ClassName("login-form"), "Home Page") { }

        public int GetLengthOfListFirstLevelDomain() => Domains.Count();
        public void SelectDomain(int domainListIndex) => Domains.GetItemByIndex(domainListIndex).Click();
        public void OpenDropDownDomainsList() => DomainDropDown.Click();
        public void FillPassword(string password) => PasswordTextBox.ClearAndType(password);
        public void FillEmail(string email) => EmailTextBox.ClearAndType(email);
        public void FillDomain(string domain) => DomainTextBox.ClearAndType(domain);
        public string GetTimerValue() => Timer.GetElement().GetAttribute("innerText");
        public void AcceptTerms() => AcceptTermsButton.Click();
        public void ClickNextButton() => NextButton.Click();
    }
}
