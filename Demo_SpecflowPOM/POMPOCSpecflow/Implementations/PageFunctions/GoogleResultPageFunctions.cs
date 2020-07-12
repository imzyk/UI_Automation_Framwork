using System.Linq;
using TechTalk.SpecFlow;
using POMPOCSpecflow.Implementations.PageObjects;
using OpenQA.Selenium;

namespace POMPOCSpecflow.Implementations.PageFunctions
{
    public sealed class GooglePageResultFunctions: BasePageFunctions
    {
        public GooglePageResultFunctions(ScenarioContext context, IWebDriver driver) : base(context, driver)
        {
        }

        public string GetFirstCite()
        {
            return CssLists(GoogleResultPage.textCite).First().Text;
        }
    }
}
