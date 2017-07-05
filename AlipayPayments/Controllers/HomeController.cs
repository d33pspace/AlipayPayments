using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlipayPayments.Models;
using Com.Alipay;
using AlipayCore;
using System.ComponentModel;
using System.Net.Http;

namespace AlipayPayments.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}