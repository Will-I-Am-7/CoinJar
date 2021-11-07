using CoinJarGK.Application.CoinJar.Commands.AddCoinToJar;
using CoinJarGK.Application.CoinJar.Commands.ResetCoinJar;
using CoinJarGK.Application.CoinJar.Queries.GetCoinJarTotalAmount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinJarGK.WebAPI.Controllers
{
    public class CoinJarController : ApiControllerBase
    {
        /// <summary>
        /// Adds a coin to the jar
        /// </summary>
        /// <param name="command">New coin</param>
        /// <returns></returns>
        [HttpPost("coin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddCoinAction([FromBody] AddCoinToJarCommand command)
        {
            await Mediator.Send(command);

            return Created(nameof(GetTotalAmountAction), null);
        }

        /// <summary>
        /// Reset the coins
        /// </summary>
        /// <returns></returns>
        [HttpPut("reset")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ResetAction()
        {
            await Mediator.Send(new ResetCoinJarCommand());

            return NoContent();
        }

        /// <summary>
        /// Get the total amount of our coins
        /// </summary>
        /// <returns>Total amount of our coins</returns>
        [HttpGet("total/amount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetCoinJarTotalAmountDto>> GetTotalAmountAction() 
        {
            var totalAmountDto = await Mediator.Send(new GetCoinJarTotalAmountQuery());

            return totalAmountDto;
        }
    }
}
