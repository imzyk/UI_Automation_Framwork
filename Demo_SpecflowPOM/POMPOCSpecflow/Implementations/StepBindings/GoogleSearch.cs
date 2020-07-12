using NUnit.Framework;
using TechTalk.SpecFlow;
using POMPOCSpecflow.Implementations.PageFunctions;
using OpenQA.Selenium;

namespace POMPOCSpecflow.Implementations.StepBindings
{
    [Binding]
    public class GoogleSearch
    {
        private string info;
        private GooglePageFunctions _pageFunctions;
        private GooglePageResultFunctions _pageResultFunctions;

        public GoogleSearch(ScenarioContext context, IWebDriver driver)
        {
             _pageFunctions = new GooglePageFunctions(context, driver);
            _pageResultFunctions = new GooglePageResultFunctions(context, driver);
        }


        [Given(@"I navigate to Google site")]
        public void GivenINavigateToGoogleSite()
        {
            _pageFunctions.BrowseToPortal();
        }

        [When(@"I search with keyword '(.*)'")]
        public void WhenISearchWithKeyword(string keyword)
        {
            _pageFunctions.SearchWithKeyword(keyword);
            info = keyword;
        }

        [Then(@"I should see related citing")]
        public void ThenIShouldSeeRelatedCiting()
        {
            Assert.IsTrue(_pageResultFunctions.GetFirstCite().Contains(info));
        }
    }
}
