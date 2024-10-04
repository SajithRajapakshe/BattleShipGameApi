using BattleShipGameBL;
using BattleShipGameBL.Services;
using NUnit.Framework;
using System.Runtime.CompilerServices;

namespace BattleShipGameTests
{

    /// <summary>
    /// Executes unit tests for functions inside the BattleShipGame service.
    /// </summary>
    public class BattleShipGameTests
    {

        private IBattleShipGameService _battleShipService;
        [SetUp]
        public void SetUp()
        {
            _battleShipService = new BattleShipGameService();
        }

        /// <summary>
        /// Check whether the api service giving the head shot message in a success hit.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>

        [Test]
        [TestCase(1, 2)]
        public void FireCannon_Hit_Success(int row, int col)
        {
            Assert.That(_battleShipService.FireCannon(row, col).Result == Constants.HEAD_SHOT, Is.True);
        }

        /// <summary>
        /// Checking whether the api service NOT giving the head shot message in a success hit.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        [Test]
        [TestCase(1, 2)]
        public void FireCannon_Hit_Failure(int row, int col)
        {
            Assert.That(_battleShipService.FireCannon(row, col).Result != Constants.HEAD_SHOT, Is.True);
        }

        /// <summary>
        /// Check whether the api service giving the mis hit message in a miss hit.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        [Test]
        [TestCase(1, 2)]
        public void FireCannon_Miss_Hit_Success(int row, int col)
        {
            Assert.That(_battleShipService.FireCannon(row, col).Result == Constants.MIS_HIT, Is.True);
        }

        /// <summary>
        /// Check whether the api service NOT giving the miss hit message in a mis hit.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        [Test]
        [TestCase(1, 2)]
        public void FireCannon_Miss_Hit_Failure(int row, int col)
        {
            Assert.That(_battleShipService.FireCannon(row, col).Result != Constants.MIS_HIT, Is.False);
        }

        /// <summary>
        /// Check whether the api service giving the input invalid message when providing invalid inputs
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        [Test]
        [TestCase(-1, -2)]
        public void Invalid_Input_Success(int row, int col)
        {
            Assert.That(_battleShipService.FireCannon(row, col).Result == Constants.INVALID_INPUTS, Is.True);
        }


        /// <summary>
        /// Check whether the api service is NOT giving the input invalid message when providing invalid inputs
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        [Test]
        [TestCase(-1, -2)]
        public void Invalid_Input_Failure(int row, int col)
        {
            Assert.That(_battleShipService.FireCannon(row, col).Result != Constants.INVALID_INPUTS, Is.False);
        }




    }
}
