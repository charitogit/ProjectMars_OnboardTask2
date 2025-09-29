using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace ProjectMars_OnboardTask2.Hooks
{
    [Binding]
    public sealed class DriverHooks 
    {

      private readonly IObjectContainer _objectContainer;
       
        
      public DriverHooks (IObjectContainer objectContainer)
        {
            _objectContainer= objectContainer;  

        }
       
        [BeforeScenario (Order = 0)]
        public void InitializeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // maximize window
          
            IWebDriver driver = new ChromeDriver(options);  // browser is set to Chrome
           // Register WebDriver instance with the container
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario(Order = 100)]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();
            driver.Dispose();

        }
    }
}