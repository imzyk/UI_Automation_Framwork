using OpenQA.Selenium.Chrome;
using System.IO;
using NUnit.Framework;
using System.Reflection;
using TechTalk.SpecFlow;
using POMPOCSpecflow.Implementations.PageFunctions;

namespace POMPOCSpecflow.Implementations.StepBindings
{
    [Binding]
    public class GoogleSearch
    {
        private string info;
        private GooglePageFunctions _pageFunctions;
        private GooglePageResultFunctions _pageResultFunctions;

        public GoogleSearch(ScenarioContext context)
        {
            context.Add("driver", new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
             _pageFunctions = new GooglePageFunctions(context);
            _pageResultFunctions = new GooglePageResultFunctions(context);
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
