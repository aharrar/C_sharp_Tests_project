using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using BE;

namespace Location
{
    public class location
    {
        private static Thread gMapsThread;
        private static bool isRun;

        public static double PrintDrivingDistanceInMiles(string _origin, string _destenation)
        {
            string origin = _origin;
            string destination = _destenation;
            string KEY = @"yFgF2JUlmDgo3vOXtJK9gX0vLweMXXU6";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + origin +
             @"&to=" + destination +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response;
            Stream dataStream;
            try
            {
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
            }
            catch (Exception)
            {
                return 999999999;
            }
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");

                //double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);

                string[] distInMiles1 = distance[0].ChildNodes[0].InnerText.Split('.');
                double distInMiles = Convert.ToDouble(distInMiles1[0]) + Convert.ToDouble(distInMiles1[1]) / (10 ^ Convert.ToInt32(distInMiles1[1].Length));

                return ((int)(distInMiles * 1.609344));
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                throw (new Exception("אחת הכתובות לא נמצאת."));
            }
            else  //busy network or other error...
            {
                Random r = new Random();
                return r.Next(100);
            }
        }
    }
}