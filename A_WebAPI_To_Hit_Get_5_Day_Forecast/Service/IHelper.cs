using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_WebAPI_To_Hit_Get_5_Day_Forecast.Service
{
    public interface IHelper
    {
        bool IsValidZip(string zipCode);

        bool IsValidCity(string city);
    }
}
