using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Mercator_CodingExercise_QA.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver Driver { get; private set; }


        [BeforeScenario]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
