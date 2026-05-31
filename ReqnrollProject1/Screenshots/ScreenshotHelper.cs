using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Screenshots
{
    public class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;

            Screenshot screenshot = ts.GetScreenshot();

            string folderPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Screenshots");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(
                folderPath,
                screenshotName + ".png");

            screenshot.SaveAsFile(filePath);

            return filePath;
        }
    }
}
