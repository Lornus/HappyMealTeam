using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FirstTests
{
    public class SeleniumTest
    {
 
        
        [Test]
        static public void GoKpiSchedule()
        {
            bool found = false;
             IWebDriver CDriver = new ChromeDriver();
             IWebElement element;

            CDriver.Navigate().GoToUrl("http://google.com/");
            element = CDriver.FindElement(By.Name("q"));
            CDriver.Manage().Window.Maximize();

            
            element.SendKeys("Розклад КПІ");
            element.SendKeys(Keys.Enter);

            element = CDriver.FindElement(By.CssSelector("#rso > div > div:nth-child(1) > div > div.tF2Cxc > div.yuRUbf > a"));
            element.Click();

            element = CDriver.FindElement(By.Id("ctl00_lBtnSchedule"));
            element.Click();

            element = CDriver.FindElement(By.Id("ctl00_MainContent_ctl00_txtboxGroup"));
            element.SendKeys("КП-93");

            element = CDriver.FindElement(By.Id("ctl00_MainContent_ctl00_btnShowSchedule"));
            element.Click();

            IWebElement tableElement1 = CDriver.FindElement(By.Id("ctl00_MainContent_FirstScheduleTable"));
            IWebElement tableElement2 = CDriver.FindElement(By.Id("ctl00_MainContent_SecondScheduleTable"));

            IList<IWebElement> tableRow1 = tableElement1.FindElements(By.TagName("tr"));
            IList<IWebElement> tableRow2 = tableElement2.FindElements(By.TagName("tr"));
            var newList = tableRow1.Concat(tableRow2);
            IList<IWebElement> rowTD;

            foreach (IWebElement row in newList)
            {
                rowTD = row.FindElements(By.TagName("td"));

                if (rowTD.Count < 4)
                {
                    throw new Exception("Something with table");
                }
                else
                {
                    if(rowTD[3].Text.Contains("Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення"))
                    {
                       
                        found = true;
                    }
                }
            }
            Debug.Assert(found);


            System.Threading.Thread.Sleep(timeout: TimeSpan.FromSeconds(1));
            CDriver.Close();
        }

        [Test]
        static public void GoEpicenter()
        {
            IWebDriver CDriver = new ChromeDriver();
            IWebElement element;
            CDriver.Manage().Window.Maximize();

            CDriver.Navigate().GoToUrl("http://google.com/");
            element = CDriver.FindElement(By.Name("q"));
            element.SendKeys("Епіцентр");
            element.SendKeys(Keys.Enter);

            element = CDriver.FindElement(By.ClassName("Krnil"));
            element.Click();


            element = CDriver.FindElement(By.CssSelector("#footer-block > div.footer__info.container > div > div.footer__column.footer__column--xl > div:nth-child(1) > p.footer__block-info.footer__block-info--small"));
          

            Debug.Assert(element.Text.Contains("з 07:30 до 22:30"));

            System.Threading.Thread.Sleep(timeout: TimeSpan.FromSeconds(1));


            CDriver.Close();
        }

        //test for making sure that downloading link for The Internet Explorer Driver Server is enable
        [Test]
        static public void HappyMealTest()
        {
            IWebDriver CDriver = new ChromeDriver();
            IWebElement element;
            CDriver.Manage().Window.Maximize();

            CDriver.Navigate().GoToUrl("http://google.com/");
            element = CDriver.FindElement(By.Name("q"));
            element.SendKeys("Selenium");
            element.SendKeys(Keys.Enter);

            element = CDriver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > div.tF2Cxc > div.yuRUbf > a"));
            element.Click();

            element = CDriver.FindElement(By.CssSelector("body > section.getting-started.dark-background > div > div:nth-child(2) > div.download-button-container > a"));
            element.Click();

             element = CDriver.FindElement(By.LinkText("32 bit Windows IE"));
            Debug.Assert(element.Enabled);

            System.Threading.Thread.Sleep(timeout: TimeSpan.FromSeconds(1));

            CDriver.Close();
        }
    }
}
