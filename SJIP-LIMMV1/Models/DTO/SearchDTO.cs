using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJIP_LIMMV1.Models
{
    public class SearchDTO 
    {       
        public string TownCouncil { get; set; }
        public string BlockNo { get; set; }        
        public string SIMCard { get; set; }
        public string LMPD { get; set; }
    }
}