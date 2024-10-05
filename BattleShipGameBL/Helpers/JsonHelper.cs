using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGameBL.Helpers
{
    public static class JsonHelper
    {
        public static string ConvertToJsonString(object input)
        {
            return JsonConvert.SerializeObject(input);
        }
       
    }
}
