using OpenQA.Selenium;
using TechTalk.SpecFlow;
using POMPOCSpecflow.Implementations.PageObjects;

namespace POMPOCSpecflow.Implementations.PageFunctions
{
    public sealed class GooglePageFunctions: BasePageFunctions
    {
        public GooglePageFunctions(ScenarioContext context): base(context)
        {
        }

        public void BrowseToPortal()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        public void SearchWithKeyword(string keyword)
        {
            IWebElement inputOrgName = TextInput(GooglePage.btnSearch);
            inputOrgName.SendKeys(keyword + "\n");
        }
    }
}
