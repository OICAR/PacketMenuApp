using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.ViewModel
{
    public class CatererViewModel
    {

        public string CatererName { get; set; }

        public string CatererOIB { get; set; }

        public string CatererID { get; set; }


        public string CateringFacilitiName { get; set; }

        //public int? Rating { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public byte[] Document { get; set; }

        public IFormFile FormDocument { get; set; }

    }
}
