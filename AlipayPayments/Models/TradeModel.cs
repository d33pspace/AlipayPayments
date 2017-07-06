using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlipayPayments.Models
{
    public class TradeModel
    {
        public string service{get; set;}
        public string partner{get; set;}
        public string _input_charset{get; set;}
        public string notify_url{get; set;}
        public string return_url{get; set;}
		public string currency{get; set;}
        public string out_trade_no{get; set;}
        public string subject{get; set;}
        public double total_fee{get; set;}
        public string body{get; set;}
    }
}
