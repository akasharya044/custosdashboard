using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models.DTO;
using custos.Models;

namespace custos.DAL.DataService
{
   public interface IHarddiskInformation
    {
            Task<Response> GetHarddiskInformation();
            Task<Response> AddHarddiskInformation(HarddiskDetailsDto data);
        }
    }
