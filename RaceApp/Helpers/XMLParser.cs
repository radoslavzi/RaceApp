using RaceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;

namespace RaceApp.Models
{
    public static class XMLParser
    {
        public static IEnumerable<RaceEventViewModel> ParseAllChildChild(XmlElement root, bool isAsc, bool isDesc)
        {
            IList<RaceEventViewModel> list = new List<RaceEventViewModel>();

            foreach (XmlNode node in root.ChildNodes)
            {
                RaceEventViewModel model = new RaceEventViewModel();
                model.RaceEvent = ParseAttributeOfANode(node);
                model.RaceEventEntries = ParseEntrysOfANode(node);
                list.Add(model);
            }

            if (isAsc)
            {
                list =list.Select(re => new RaceEventViewModel(){ RaceEvent = re.RaceEvent,RaceEventEntries = re.RaceEventEntries.OrderBy(d => d.Name).ThenBy(d => d.OddsDecimal)}).ToList();
            }else if (isDesc)
            {
                list = list.Select(re => new RaceEventViewModel() { RaceEvent = re.RaceEvent, RaceEventEntries = re.RaceEventEntries.OrderByDescending(d => d.Name).ThenBy(d => d.OddsDecimal) }).ToList();
            }
           
             
            return list;
        }

        private static RaceEvent ParseAttributeOfANode(XmlNode node)
        {
            RaceEvent model = new RaceEvent();
            foreach (XmlAttribute attr in node.Attributes)
            {
                SetRaceEventAttributes(attr, model);
            }

            return model;
        }

        private static IEnumerable<RaceEventEntry> ParseEntrysOfANode(XmlNode node)
        {
            IList<RaceEventEntry> models = new List<RaceEventEntry>();
            foreach (XmlNode child in node.ChildNodes)
            {
                RaceEventEntry model = new RaceEventEntry();
                foreach (XmlAttribute attr in child.Attributes)
                {

                    SetRaceEventEntryAttributes(attr, model);
                }

                models.Add(model);
            }

            return models;
        }

        private static void SetRaceEventEntryAttributes(XmlAttribute attr, RaceEventEntry model)
        {
            switch (attr.Name.ToLowerInvariant())
            {
                case Constants.Id:
                    {
                        model.Id = int.Parse(attr.Value);
                        return;
                    }
                case Constants.Name:
                    {
                        model.Name = attr.Value;
                        return;
                    }
                case Constants.OddsDecimal:
                    {
                        model.OddsDecimal = decimal.Parse(attr.Value, CultureInfo.InvariantCulture);
                        return;
                    }
                default:
                    break;
            }
        }

        private static void SetRaceEventAttributes(XmlAttribute attr, RaceEvent model)
        {
            switch (attr.Name.ToLowerInvariant())
            {
                case Constants.Id:
                    {
                        model.Id = int.Parse(attr.Value);
                        return;
                    }
                case Constants.EventNumber:
                    {
                        model.EventNumber = int.Parse(attr.Value);
                        return;
                    }
                case Constants.FinishTime:
                    {
                        model.FinishTime = DateTime.Parse(attr.Value, CultureInfo.InvariantCulture);
                        return;
                    }
                case Constants.Distance:
                    {
                        model.Distance = uint.Parse(attr.Value);
                        return;
                    }
                case Constants.Name:
                    {
                        model.Name = attr.Value;
                        return;
                    }
                default:
                    break;
            }
        }
    }
}