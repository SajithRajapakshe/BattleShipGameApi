using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGameBL.Models
{
    /// <summary>
    /// Gets and Sets the properties of the status of the game board
    /// </summary>
    public class GameBoardStatus
    {
        public int[,] GameBoardGrid { get; set; }
        public List<BattleShip> Ships { get; set; }
        public List<(int, int)> Successes { get; set; }
        public List<(int, int)> Failures { get; set; }
    }
}
