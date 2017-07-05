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

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
