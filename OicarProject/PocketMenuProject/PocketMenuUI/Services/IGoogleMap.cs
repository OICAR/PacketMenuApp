﻿using PocketMenuUI.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
   public interface IGoogleMap
    {
        Task<List<GoogleMapDTO>> GetAllLocations();

        Task<GoogleMapDTO> Add(GoogleMapDTO location);
    }
}
