using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Budjettilaskuri
{
    public class Budjetti
    {
        public int tulot { get; set; }
        public int menot { get; set;}
        public float veroprosentti { get; set; }
        public string date { get; set; }
    }
}
