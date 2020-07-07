using System.Linq;
using TechTalk.SpecFlow;
using POMPOCSpecflow.Implementations.PageObjects;

namespace POMPOCSpecflow.Implementations.PageFunctions
{
    public sealed class GooglePageResultFunctions: BasePageFunctions
    {
        public GooglePageResultFunctions(ScenarioContext context): base(context)
        {
        }

        public string GetFirstCite()
        {
            return CssLists(GoogleResultPage.textCite).First().Text;
        }
    }
}
