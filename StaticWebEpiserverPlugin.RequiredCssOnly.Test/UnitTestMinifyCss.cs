using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticWebEpiserverPlugin.RequiredCssOnly.Services;

namespace StaticWebEpiserverPlugin.RequiredCssOnly.Test
{
    [TestClass]
    public class UnitTestMinifyCss
    {
        [TestMethod("No space in Result")]
        public void NoSpaceInResult()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "body {\r\nbackground-color: white; color: black;\r\n} .card + h1 { font-size: 20px }\r\n";
            var htmlContent = "";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsFalse(result.Contains(" "));
        }

        [TestMethod("No newline in Result")]
        public void NoNewLineResult()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "body {\r\nbackground-color: white; color: black;\r\n} .card + h1\r\n{ font-size: 20px }\r\n";
            var htmlContent = "";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsFalse(result.Contains("\r") && result.Contains("\n"));
        }


        [TestMethod("No comments in Result")]
        public void NoCommentsResult()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "/*\r\n * # TESTING MULTILINE COMMENT #  \r\n */\r\nbody {\r\nbackground-color: white; color: black;\r\n} /* We don't know what this should illustrate */ .card + h1\r\n{ font-size: 20px }\r\n";
            var htmlContent = "";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsFalse(result.Contains("/*") && result.Contains("*/"));
        }

    }
}
