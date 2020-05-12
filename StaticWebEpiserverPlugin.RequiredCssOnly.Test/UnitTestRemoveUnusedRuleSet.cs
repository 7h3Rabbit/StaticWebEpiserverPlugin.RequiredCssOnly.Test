using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticWebEpiserverPlugin.RequiredCssOnly.Services;

namespace StaticWebEpiserverPlugin.RequiredCssOnly.Test
{
    [TestClass]
    public class UnitTestRemoveUnusedRuleSet
    {
        [TestMethod("Don't remove used rule in Result - only class")]
        public void DontRemoveUsedRuleInResultWhenOnlyClass()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "body {\r\nbackground-color: white; color: black;\r\n} .card { border:solid 1px green; }\r\n";
            var htmlContent = @"<div class=""card""><h1>Card header</h1><p>this is a card</h1></div>";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsTrue(result.Contains(".card{"));
        }

        [TestMethod("Don't remove used rule in Result - first class")]
        public void DontRemoveUsedRuleInResultWhenFirstClass()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "body {\r\nbackground-color: white; color: black;\r\n} .card { border:solid 1px green; }\r\n";
            var htmlContent = @"<div class=""card card-primary""><h1>Card header</h1><p>this is a card</h1></div>";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsTrue(result.Contains(".card{"));
        }

        [TestMethod("Don't remove used rule in Result - last class")]
        public void DontRemoveUsedRuleInResultWhenLastClass()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "body {\r\nbackground-color: white; color: black;\r\n} .card { border:solid 1px green; }\r\n";
            var htmlContent = @"<div class=""bg-yellow card""><h1>Card header</h1><p>this is a card</h1></div>";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsTrue(result.Contains(".card{"));
        }

        [TestMethod("Remove unused rule in Result")]
        public void RemoveUnusedRuleInResult()
        {
            var service = new RequiredCssOnlyService();

            var cssContent = "body {\r\nbackground-color: white; color: black;\r\n} .card { border:solid 1px green; }\r\n";
            var htmlContent = @"<div class=""bg-yellow u-card""><h1>Card header</h1><p>this is a card</h1></div>";

            var result = service.RemoveUnusedRules(cssContent, htmlContent);
            Assert.IsFalse(result.Contains(".card{"));
        }

    }
}
