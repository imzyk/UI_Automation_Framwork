using System;
using System.IO;
using System.Reflection;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace POMPOCSpecflow.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            // Get browser to be used for testing from App.json
            var browser = AppSettings.Instance.GetConfigValue("Browser");
            if (_driver == null)
            {
                switch (browser)
                {
                    case "Chrome":
                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                        break;
                    default:
                        throw new Exception("Browser type not supported:" + browser);
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                _driver.Manage().Window.Maximize();
                _objectContainer.RegisterInstanceAs(_driver);
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            _driver?.Dispose();
        }
    }
}