using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Com.Alipay;
using System.ComponentModel;
using AlipayPayments.Models;

namespace AlipayPayments.Controllers
{
    public class AlipayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pay(TradeModel trade)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(trade))
            {
                object value = property.GetValue(trade);
                if (value != null)
                    sParaTemp.Add(property.Name, value.ToString());
            }
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("partner", Config.partner);
            sParaTemp.Add("_input_charset", Config.input_charset);
            sParaTemp.Add("notify_url", Config.notify_url);
            sParaTemp.Add("return_url", Config.return_url);
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            ViewBag.HtmlText = sHtmlText;
            return View();
        }

        [HttpGet]
        public IActionResult Success(TradeModel trade)
        {
            SortedDictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.VerifyReturn(sPara, Request.Query["sign"]);

                if (verifyResult)
                {
                    string out_trade_no = Request.Query["out_trade_no"];
                    string trade_no = Request.Query["trade_no"];

                    string trade_status = Request.Query["trade_status"];
                    if (Request.Query["trade_status"] == "TRADE_FINISHED" || Request.Query["trade_status"] == "TRADE_SUCCESS")
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Notify()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();
            if (sPara.Count > 0)
            {
                Notify aliNotify = new Notify();
                bool verifyResult = await aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
                if (verifyResult)
                {
                    string out_trade_no = Request.Form["out_trade_no"];
                    string trade_no = Request.Form["trade_no"];
                    string trade_status = Request.Form["trade_status"];

                    if (Request.Form["trade_status"] == "TRADE_FINISHED")
                    {
                        
                    }
                    else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        
                    }
                    else
                    {
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                
            }
            return View();
        }

        [HttpGet]
        public IActionResult Redirect()
        {
            return Ok(Request.Query["echostr"]);   
        }

        public IActionResult Error()
        {
            return View();
        }

        public SortedDictionary<string, string> GetRequestPost()
        {
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            Microsoft.AspNetCore.Http.IFormCollection coll;
            coll = Request.Form;
            ICollection<string> requestKeys = coll.Keys;
            foreach (string key in requestKeys)
            {
                sArray.Add(key, Request.Form[key]);
            }
            return sArray;
        }

        public SortedDictionary<string, string> GetRequestGet()
        {
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            Microsoft.AspNetCore.Http.IQueryCollection coll = Request.Query;
            ICollection<string> keys = coll.Keys;
            foreach (string key in keys)
            {
                sArray.Add(key, Request.Query[key]);
            }
            return sArray;
        }
    }
}
