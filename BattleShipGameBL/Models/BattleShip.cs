using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGameBL.Models
{
    /// <summary>
    /// Properties of the battleship
    /// </summary>
    public class BattleShip
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Size { get; set; }
        public List<(int, int)> Spots { get; set; }
        public bool IsSunk { get; set; }


    }
}
