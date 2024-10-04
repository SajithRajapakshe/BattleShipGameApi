using BattleShipGameBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGameBL.Services
{
    /// <summary>
    /// Battle ship game service interface. Can be extended by the class.
    /// </summary>
    public interface IBattleShipGameService
    {
        /// <summary>
        /// Randomly locates the battleship inside the grid.
        /// </summary>
        /// <param name="battleShip"></param>
        void LocateBattleShip(BattleShip battleShip);

        /// <summary>
        /// Locates the position of the destroyer.
        /// </summary>
        /// <param name="battleShip"></param>
        void LocateDestroyers(BattleShip battleShip);

        /// <summary>
        /// Executes the operations when a shoot has happened.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        Task<string> FireCannon(int row, int col);

        /// <summary>
        /// Returns the Current game board status. This will contain all properties related to available grid, misses, successes and sunk ships.
        /// </summary>
        /// <returns></returns>
        Task<GameBoardStatus> GetGameBoardStatus();
    }
}
