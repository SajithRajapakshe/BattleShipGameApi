using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BattleShipGameBL.Models;

namespace BattleShipGameBL.Services
{
    /// <summary>
    /// Battleship Game service - Facilitates all actions , properties related to the game.
    /// </summary>
    public class BattleShipGameService : IBattleShipGameService
    {
        private readonly GameBoardStatus _gameBoardStatus;
        Random _random = new Random();

        /// <summary>
        /// Constructor to inilialize the properties of the class.
        /// </summary>
        public BattleShipGameService()
        {
            _gameBoardStatus = new GameBoardStatus();
            InitializeGameBoardStatus();
            LocateBattleShip(InitBattleShip());
            for (int i = 0; i < 2; i++)
                LocateDestroyers(InitDestroyer());
        }

        /// <summary>
        /// Initializes the status of the Game board. 10 * 10 grid, list of ships and type of hits
        /// </summary>
        private void InitializeGameBoardStatus()
        {
            _gameBoardStatus.GameBoardGrid = new int[10, 10];
            _gameBoardStatus.Ships = new List<BattleShip>();
            _gameBoardStatus.Successes = new List<(int, int)>();
            _gameBoardStatus.Failures = new List<(int, int)>();
        }

        /// <summary>
        /// Executes the operations when a shoot has happened.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public async Task<string> FireCannon(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return Constants.INVALID_INPUTS;
            }
            if (_gameBoardStatus.Successes.Contains((row, col)) || _gameBoardStatus.Failures.Contains((row, col)))
            {
                return Constants.ALREADY_HIT_MESSAGE;
            }
            if (_gameBoardStatus.GameBoardGrid[row, col] == 1)
            {
                return await RecordSuccessfulHit(row, col);
            }
            else
            {
                _gameBoardStatus.Failures.Add((row, col));
                return Constants.MIS_HIT;
            }
        }

        private Task<string> RecordSuccessfulHit(int row, int col)
        {

            List<string> sunkShips = new List<string>();
            _gameBoardStatus.Successes.Add((row, col));

            var hitShips = _gameBoardStatus.Ships.Where(p => p.Spots.Contains((row, col))).ToList();

            foreach (var ship in hitShips)
            {
                ship.Spots.Remove((row, col));
                ship.IsSunk = !ship.Spots.Any(s => s.Item1 > 0);

                if (ship.IsSunk)
                {
                    sunkShips.Add(ship.Name);
                }
            }

            var returnMessage = sunkShips.Count > 0 ?
                string.Format(Constants.SUNK_SHIPS, sunkShips.FirstOrDefault()) :
                Constants.HEAD_SHOT;

            return Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Returns the Current game board status. This will contain all properties related to available grid, misses, successes and sunk ships.
        /// </summary>
        /// <returns></returns>
        public async Task<GameBoardStatus> GetGameBoardStatus()
        {
            return _gameBoardStatus;
        }


        /// <summary>
        /// Randomly locates the battleship inside the grid.
        /// </summary>
        /// <param name="battleShip"></param>
        public void LocateBattleShip(BattleShip battleShip)
        {

            List<(int, int)> positions;

            do
            {
                positions = CreateRandomSpots(battleShip.Size);
            }
            while (positions.Any(p => _gameBoardStatus.GameBoardGrid[p.Item1, p.Item2] != 0));

            foreach (var pos in positions)
            {
                _gameBoardStatus.GameBoardGrid[pos.Item1, pos.Item2] = 1;
            }

            _gameBoardStatus.Ships.Add(new BattleShip { Name = battleShip.Name, Spots = positions });

        }

        /// <summary>
        /// Creating random spots using the System.Random class
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private List<(int, int)> CreateRandomSpots(int size)
        {
            var isHorisontal = _random.Next(2) == 0;
            var spots = new List<(int, int)>();

            int row;
            int col;

            if (isHorisontal)
            {
                row = _random.Next(10);
                col = _random.Next(10 - size + 1);
                for (int i = 0; i < size; i++)
                    spots.Add((row, col + i));
            }
            else
            {
                row = _random.Next(10 - size + 1);
                col = _random.Next(10);
                for (int i = 0; i < size; i++)
                    spots.Add((row + i, col));
            }

            return spots;
        }

        /// <summary>
        /// Locates the position of the destroyer.
        /// </summary>
        /// <param name="battleShip"></param>
        public void LocateDestroyers(BattleShip battleShip)
        {
            List<(int, int)> positions;

            do
            {
                positions = CreateRandomSpots(battleShip.Size);
            }
            while (positions.Any(p => _gameBoardStatus.GameBoardGrid[p.Item1, p.Item2] != 0));

            foreach (var pos in positions)
            {
                _gameBoardStatus.GameBoardGrid[pos.Item1, pos.Item2] = 1;
            }

            _gameBoardStatus.Ships.Add(new BattleShip { Name = battleShip.Name, Spots = positions });
        }

        /// <summary>
        /// Init properties of Battleship
        /// </summary>
        /// <returns></returns>
        private BattleShip InitBattleShip()
        {
            return new BattleShip { Name = "BattleShip", Type = 1, Size = 5 };
        }

        /// <summary>
        /// Init properties of Destroyer
        /// </summary>
        /// <returns></returns>
        private BattleShip InitDestroyer()
        {
            return new BattleShip { Name = "Destroyer", Type = 2, Size = 4 };
        }
    }
}
