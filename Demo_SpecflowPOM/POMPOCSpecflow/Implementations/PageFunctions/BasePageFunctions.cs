using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace POMPOCSpecflow.Implementations.PageFunctions
{
    [Binding]
    public class BasePageFunctions
    {
        protected IWebDriver driver;
        public BasePageFunctions(ScenarioContext context, IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TextInput(string selector)
        {
            return driver.FindElement(By.CssSelector(selector));
        }

        public ICollection<IWebElement> CssLists(string selector)
        {
            return driver.FindElements(By.CssSelector(selector));
        }
    }
}
