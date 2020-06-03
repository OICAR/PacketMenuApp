using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleMapsService.Models
{
    public interface IGoogleMapsRepository
    {
        IEnumerable<GoogleMap> GetAllLocations();
        GoogleMap Add(GoogleMap employee);
    }
}
