using Newtonsoft.Json;
using RaceApp.Helpers;
using RaceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;

namespace RaceApp.Controllers
{
    public class ParseController : ApiController
    {
        private XmlDocument document;

        // GET api/parse
        public JsonResult Get(bool isAsc = false, bool isDesc = false)
        {
            document = new XmlDocument();
            JsonResult json = new JsonResult();
            document.Load(Constants.XmlFilePath);
            XmlElement root = document.DocumentElement;
            IEnumerable<RaceEventViewModel> model =
                XMLParser.ParseAllChildChild(root, isAsc, isDesc);

            json.Data = JsonConvert.SerializeObject(model);
            json.ContentType = "application/json";
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }
    }
}
