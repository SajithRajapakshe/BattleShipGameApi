using BattleShipGameBL.Helpers;
using BattleShipGameBL.Models;
using BattleShipGameBL.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace BattleShipGameApi.Controllers
{
    /// <summary>
    /// Api for handle operations of the battleship game
    /// </summary>
    
    public class BattleShipGameController : ControllerBase
    {

        private static IBattleShipGameService _battleShipGameService= new BattleShipGameService();

        /// <summary>
        /// Returns the current status of the game board.
        /// </summary>
        /// <returns></returns>
        /// 
        
        [HttpGet]
        [Route("BattleShipGameApi/GetGameBoardStatus")]
        public async Task<string> GetGameBoardStatus()
        {
            return JsonHelper.ConvertToJsonString(await _battleShipGameService.GetGameBoardStatus());
        }

        /// <summary>
        /// Post action to handle the shooting
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BattleShipGameApi/FireCannon")]
        public async Task<string> FireCannon(int row, int col)
        {
            return JsonHelper.ConvertToJsonString(await _battleShipGameService.FireCannon(row, col));
        }
    }
}
