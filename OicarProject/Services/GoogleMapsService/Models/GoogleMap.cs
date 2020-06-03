using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleMapsService.Models
{
    public class GoogleMap
    {

        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

    }
}
