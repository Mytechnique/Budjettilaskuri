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
        public int income { get; set; }
        public int expenses { get; set;}
        public float taxPercent { get; set; }
        public string date { get; set; }
    }
}
