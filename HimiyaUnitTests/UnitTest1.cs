using System;
using System.Web.Mvc;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Himiya.Helpers;
using Himiya;

namespace HimiyaUnitTests
{
    [TestClass]
    public class HelpersTests
    {
        [TestMethod]
        public void VerifiedTextIfMultilang()
        {
            string res = Helpers.VerifiedAnswer(null, "vsбutін").ToHtmlString();
            Assert.AreEqual("v<span style='color: #f56; background: #000;'>sб</span>utін", res);
        }
        [TestMethod]
        public void VerifiedTextIfNotMultilang()
        {
            string res = Helpers.VerifiedAnswer(null, "vso").ToHtmlString();
            Assert.AreEqual("vso", res);
        }
        [TestMethod]
        public void EnContainsIfMultilang()
        {
            bool actual = Helpers.EnContains("erс");
            Assert.AreEqual(true, actual);
        }
        [TestMethod]
        public void UkContainsIfMultilang()
        {
            bool actual = Helpers.UkContains("мoї");
            Assert.AreEqual(true, actual);
        }
    }
}
