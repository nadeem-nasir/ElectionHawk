using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using model = ElectionHawk.Common.Models;
using System.Web;

namespace ElectionHawk.Web.Crawlers
{
    public class CrawlerConstituencyAndPollingsSheme
    {
        public string ECPBaseUrl = "https://www.ecp.gov.pk";
        /// <summary>
        /// It will download the polling scheme for one constituency
        /// </summary>
        /// <param name="pageURL"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public model.ConstituencyImportModel ScrapPollingsSheme(string pageURL, string className)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(pageURL);
                var constituency = new model.ConstituencyImportModel();
                var pollingScheme = new model.PollingSchemeImportModel();
                List<model.PollingSchemeStationImportModel> pollingSchemeStations = new List<model.PollingSchemeStationImportModel>();
                //constitueny
                var uri = new Uri(pageURL);
                var query = HttpUtility.ParseQueryString(uri.Query);
                constituency.ProvCode = int.Parse(query.Get("ProvCode"));
                constituency.ConstCode = int.Parse(query.Get("ConstCode"));
                constituency.ElectionType = query.Get("ElectionType"); //NA OR PA, constituency type in our db
              
                //pollingScheme
                var pollingSchemeNameNode = document.DocumentNode.SelectSingleNode("//*[@id='ContentPlaceHolder2_lblTitle']");
                pollingScheme.Type = constituency.ElectionType;
                if (pollingSchemeNameNode != null)
                {
                    pollingScheme.Title = pollingSchemeNameNode.InnerText;
                }
                if (!string.IsNullOrWhiteSpace(pollingScheme.Title))
                {
                    var splitString = pollingScheme.Title.Split('-');

                    constituency.DistrictName = splitString.Length >= 3 ? splitString[1] : string.Empty;
                }
                pollingScheme.ElectionId = 2; //Maybe get from db or use will enter ?

                constituency.PollingScheme = pollingScheme;
                
                
                
                //polling scheme stations
                var pollingSchemeHtml = document.DocumentNode.SelectSingleNode("//div[@class='" + className + "']")
                   .SelectSingleNode("//table").Descendants("tr");

                if (pollingSchemeHtml.ElementAtOrDefault(1) != null)
                {
                    constituency.ConstituencyNoAndName = pollingSchemeHtml.ElementAtOrDefault(1).SelectSingleNode("td").FirstChild.InnerText;

                    constituency.ConstituencyNoAndName = !string.IsNullOrWhiteSpace(constituency.ConstituencyNoAndName) ? constituency.ConstituencyNoAndName.Split(':')?[1] : string.Empty;
                }
                //Polling scheme name and title
                var pollingSchemeHtmlRows = document.DocumentNode.SelectSingleNode("//div[@class='" + className + "']")
                    .SelectSingleNode("//table").Descendants("tr").Skip(3); //skip first three rows

                foreach (var row in pollingSchemeHtmlRows)
                {
                    var cells = row.SelectNodes("td");
                    model.PollingSchemeStationImportModel pollingSchemeStation = new model.PollingSchemeStationImportModel();

                    if (cells.ElementAtOrDefault(1) != null)
                    {
                        //var pSNo = cells.ElementAtOrDefault(0).InnerText;
                        int stationdId = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(1).InnerText, out stationdId))
                        {
                            //pollingSchemeStation.StationId = stationdId;
                            pollingSchemeStation.ECPPSNo = stationdId;
                        }

                    }
                    if (cells.ElementAtOrDefault(2) != null)
                    {
                        pollingSchemeStation.StationName = cells.ElementAtOrDefault(2).InnerText;

                    }
                    if (cells.ElementAtOrDefault(3) != null)
                    {
                        int booth = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(3).InnerText, out booth))
                        {
                            pollingSchemeStation.MaleBooths = booth;
                        };
                    }
                    if (cells.ElementAtOrDefault(4) != null)
                    {
                        int booth = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(4).InnerText, out booth))
                        {
                            pollingSchemeStation.FemaleBooths = booth;
                        };
                    }
                    if (cells.ElementAtOrDefault(5) != null)
                    {
                        int booth = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(5).InnerText, out booth))
                        {
                            pollingSchemeStation.TotalBooths = booth;
                        };
                    }
                    if (cells.ElementAtOrDefault(6) != null)
                    {
                        int outValue = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(6).InnerText, out outValue))
                        {
                            pollingSchemeStation.MaleVoters = outValue;
                        };
                    }

                    if (cells.ElementAtOrDefault(7) != null)
                    {
                        int outValue = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(7).InnerText, out outValue))
                        {
                            pollingSchemeStation.FemaleVoters = outValue;
                        };
                    }
                    if (cells.ElementAtOrDefault(8) != null)
                    {
                        int outValue = 0;
                        if (int.TryParse(cells.ElementAtOrDefault(8).InnerText, out outValue))
                        {
                            pollingSchemeStation.TotalVoters = outValue;
                        };
                    }
                    if (cells.ElementAtOrDefault(9) != null)
                    {
                        decimal outValue = 0;
                        if (decimal.TryParse(cells.ElementAtOrDefault(9).InnerText, out outValue))
                        {
                            pollingSchemeStation.Latitude = outValue;
                        };
                    }
                    if (cells.ElementAtOrDefault(10) != null)
                    {
                        decimal outValue = 0;
                        if (decimal.TryParse(cells.ElementAtOrDefault(10).InnerText, out outValue))
                        {
                            pollingSchemeStation.Longitude = outValue;
                        };
                    }
                    if (cells.ElementAtOrDefault(11) != null)
                    {
                        pollingSchemeStation.PollingStationMapUrl =  string.Format("{0}/{1}" , ECPBaseUrl, cells.ElementAtOrDefault(11).FirstChild.Attributes["href"].Value);
                    }
                    if (cells.ElementAtOrDefault(12) != null)
                    {
                        pollingSchemeStation.PollingStationImageUrl = string.Format("{0}{1}", ECPBaseUrl, cells.ElementAtOrDefault(12).FirstChild.Attributes["href"].Value);
                    }
                    pollingSchemeStations.Add(pollingSchemeStation);
                }
                constituency.PollingScheme.pollingSchemeStations.AddRange(pollingSchemeStations);
                return constituency;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// It will download the all national assembly
        /// </summary>
        /// <param name="pageURL"></param>
        /// <returns></returns>
        public List<string> ScrapNationalAssemblyConstituencyUrl(string pageURL)
        {
            try
            {
                List<string> constituencyList = new List<string>();
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(pageURL);
                var constituencyListHtml = document.DocumentNode.SelectSingleNode("/html/body/form/div[3]/div[1]/div/section[1]/div/div/div[1]/div/div/ul/li/ul");
                foreach (var childNode in constituencyListHtml.ChildNodes)
                {
                    var firstChild = childNode.ChildNodes.FirstOrDefault();
                    if (firstChild != null)
                    {
                        var constituencyChild = firstChild.Descendants("a").FirstOrDefault();
                        if (constituencyChild != null && constituencyChild.Attributes.Count > 0)
                        {
                            var link = constituencyChild.Attributes["href"].Value;
                            if (!string.IsNullOrWhiteSpace(link))
                            {
                                constituencyList.Add(link);
                            }
                        }
                    }
                }
                return constituencyList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// It will download the all provincial assembly
        /// </summary>
        /// <param name="pageURL"></param>
        /// <returns></returns>
        public List<string> ScrapProvincialAssemblyConstituencyUrl(string pageURL)
        {
            try
            {
                List<string> constituencyList = new List<string>();
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(pageURL);
                var constituencyProvinceListHtml = document.DocumentNode.SelectSingleNode("/html/body/form/div[3]/div[1]/div/section[1]/div/div/div[1]/div/div/ul/li");
                var constituencyProvinceListAnchorTag = constituencyProvinceListHtml.Descendants("a");
                foreach (var constituencyTag in constituencyProvinceListAnchorTag)
                {
                    if (constituencyTag != null && constituencyTag.Attributes.Count > 0)
                    {
                        var link = constituencyTag.Attributes["href"].Value;
                        if (!string.IsNullOrWhiteSpace(link))
                        {
                            constituencyList.Add(link);
                        }
                    }
                }
                return constituencyList;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}


