using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealTimeCurrency.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft;
using Newtonsoft.Json.Linq;


namespace RealTimeCurrency.Controllers
{
    public class CurrencyController : Controller
    {
        //gets the list of all currencies
        //http://apilayer.net/api/list?access_key=e12142a4f9287a273d390f43bf080985

        //gets the current value of all currencies 
        //http://apilayer.net/api/live?access_key=e12142a4f9287a273d390f43bf080985  

        //gets select currency values
        //http://apilayer.net/api/live?access_key=e12142a4f9287a273d390f43bf080985&currencies=AUD,EUR,GBP,PLN,USD

        //gets the selected values for that data
        //http://apilayer.net/api/historical?access_key=e12142a4f9287a273d390f43bf080985&date=2005-02-01&format=1&currencies=AUD,EUR,GBP,PLN,USD

        //gets the selected values for a between time data cant use due to subscription level
        //http://apilayer.net/api/timeframe?access_key=e12142a4f9287a273d390f43bf080985&start_date=2012-01-01&end_date=2017-01-01&currencies=AUD,EUR,GBP,PLN,USD

        public ActionResult GetCurrent()
        {
            HttpWebRequest request = WebRequest.Create("http://apilayer.net/api/live?access_key=e12142a4f9287a273d390f43bf080985") as HttpWebRequest;
            request.Method = "GET";
            request.Proxy = null;
            request.ContentType = "application/json";
            request.UserAgent = "RealTimeCurrency";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                var content1 = reader.ReadToEnd();

                JObject o = JObject.Parse(content1);

                //paste the json objects into the viewbag and allow them to be used in my view for all 5 currencies
                ViewBag.AUD = o["quotes"]["USDAUD"];
                ViewBag.EUR = o["quotes"]["USDEUR"];
                ViewBag.GBP = o["quotes"]["USDGBP"];
                ViewBag.PLN = o["quotes"]["USDPLN"];
                ViewBag.USD = o["quotes"]["USDUSD"];
                ViewBag.RUS = o["quotes"]["USDRUB"];
                ViewBag.CHI = o["quotes"]["USDCNY"];
                ViewBag.CAN = o["quotes"]["USDCAD"];
                ViewBag.MEX = o["quotes"]["USDMXN"];
            }

            return View();
        }

    }
}