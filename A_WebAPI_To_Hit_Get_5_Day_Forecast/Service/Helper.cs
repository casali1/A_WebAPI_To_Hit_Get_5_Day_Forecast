using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A_WebAPI_To_Hit_Get_5_Day_Forecast.Service
{
    public class Helper : IHelper
    {
        public bool IsValidZip(string zipCode)
        {
            var _zipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

            var validZipCode = true;
            if (!Regex.Match(zipCode, _zipRegEx).Success)
            {
                validZipCode = false;
            }
            return validZipCode;
        }

        public bool IsValidCity(string city)
        {
            var _cityRegEx = @"^[a-zA-Z\- ]+$";

            var validCity = true;
            if (!Regex.Match(city, _cityRegEx).Success)
            {
                validCity = false;
            }
            return validCity;
        }
    }
}
