using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGameBL
{

    /// <summary>
    /// Constant class for adding specific constant values in the program
    /// </summary>
    public static class Constants
    {

        public static string ALREADY_HIT_MESSAGE = "This place is already hit";

        public static string MIS_HIT = "Oh! you just missed it, try again";

        public static string HEAD_SHOT = "Head shot, well done";

        public static string SUNK_SHIPS = "Ship {0} already sunk";

        public static string INVALID_INPUTS = "Invalid spot inputs, please try again";

    }
}
