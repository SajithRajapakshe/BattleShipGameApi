using BattleShipGameBL.Models;
using BattleShipGameBL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipGameApi.Controllers
{
    /// <summary>
    /// Api for handle operations of the battleship game
    /// </summary>
    [Route("api/[controller]")]
    public class BattleShipGameController : ControllerBase
    {

        private readonly IBattleShipGameService _battleShipGameService;

        /// <summary>
        /// Constructor which injects the dependency of the service
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public BattleShipGameController(IBattleShipGameService service)
        {
            _battleShipGameService = service;
        }

        /// <summary>
        /// Returns the current status of the game board.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetGameBoardStatus")]
        public async Task<GameBoardStatus> GetGameBoardStatus()
        {
            return await _battleShipGameService.GetGameBoardStatus();
            
        }

        /// <summary>
        /// Post action to handle the shooting
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> FireCannon(int row, int col)
        {
            return await _battleShipGameService.FireCannon(row, col);
        }
    }
}
