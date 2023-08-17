using CalculadoraCDB.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraCDB.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CalculoCdbController : ControllerBase { 
        [HttpPost]
        public IActionResult CalcularInvestimento([FromBody] CalculoCdbInput input) {
            if (input.ValorInicial < 0 || input.PrazoEmMeses <= 0) {
                return BadRequest("Valor inicial e prazo devem ser positivos.");
            }
            decimal cdi = 0.009m; // CDI de 0,9%
            decimal tb = 1.08m;   // TB de 108%

            decimal vf = input.ValorInicial;

            for (int i = 0; i < input.PrazoEmMeses; i++) {
                vf *= 1 + (cdi * tb);
            }

            decimal imposto = 0;

            if (input.PrazoEmMeses <= 6) {
                imposto = vf * 0.225m;
            }
            else if (input.PrazoEmMeses <= 12) {
                imposto = vf * 0.20m;
            }
            else if (input.PrazoEmMeses <= 24) {
                imposto = vf * 0.175m;
            }
            else {
                imposto = vf * 0.15m;
            }

            CalculoCdbOutput output = new CalculoCdbOutput {
                ResultadoBruto = vf,
                ResultadoLiquido = vf - imposto
            };

            return Ok(output);
        }
    }
}