using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlipayPayments.Models
{
    public class FormModel
    {
        public string url{get; set;}
        public string token{get; set;}
        public string random{get; set;}
        public string action{get; set;}
    }
}
