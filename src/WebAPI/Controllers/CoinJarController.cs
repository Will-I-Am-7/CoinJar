using CoinJarGK.Application.CoinJar.Commands.AddCoinToJar;
using CoinJarGK.Application.CoinJar.Commands.ResetCoinJar;
using CoinJarGK.Application.CoinJar.Queries.GetCoinJarTotalAmount;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinJarGK.WebAPI.Controllers
{
    public class CoinJarController : ApiControllerBase
    {
        [HttpPost("coin")]
        public async Task<IActionResult> AddCoinAction([FromBody] AddCoinToJarCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPut("reset")]
        public async Task<IActionResult> ResetAction()
        {
            await Mediator.Send(new ResetCoinJarCommand());

            return Ok();
        }

        [HttpGet("total/amount")]
        public async Task<ActionResult<GetCoinJarTotalAmountDto>> GetTotalAmountAction() 
        {
            var totalAmountDto = await Mediator.Send(new GetCoinJarTotalAmountQuery());

            return Ok(totalAmountDto);
        }
    }
}
