using Microsoft.AspNetCore.Http;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public interface IQRCodeGenerator
    {

       Task<QRImage>  GetQRImage(XMLModel qRDataCatering);

    }
}
