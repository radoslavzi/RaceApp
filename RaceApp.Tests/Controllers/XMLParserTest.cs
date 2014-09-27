using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceApp;
using RaceApp.Controllers;
using RaceApp.Models;
using System.Xml;
using RaceApp.Helpers;

namespace RaceApp.Tests.Controllers
{
    [TestClass]
    public class XMLParserTest
    {
        private XmlDocument document = new XmlDocument();
        [TestMethod]
        public void XmlParserParseAllChildChildTest()
        {
            document.Load(Constants.XmlFilePath);
            XmlElement root = document.DocumentElement;
            IEnumerable<RaceEventViewModel> model =
                XMLParser.ParseAllChildChild(root);
            Assert.AreEqual(model.Count(), 1);
        }

        
    }
}
