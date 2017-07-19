using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpGet]
        public IActionResult Success(TradeModel trade)
        {
            SortedDictionary<string, string> sPara = GetRequestGet();
            
            return View();
        }

        [HttpGet]
        public IActionResult Notify()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();
            return View();
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
