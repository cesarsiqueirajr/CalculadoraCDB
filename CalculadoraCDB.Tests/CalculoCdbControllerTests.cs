using CalculadoraCDB.Controllers;
using CalculadoraCDB.Modelos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CalculadoraCDB.Tests {
    public class CalculoCdbControllerTests {
        [Fact]
        public void TestCalcularInvestimento() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 1000,
                PrazoEmMeses = 12
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

        }
        [Fact]
        public void TestCalcularInvestimento_ValorNegativo() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = -100, // Valor negativo
                PrazoEmMeses = 0
            });
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Valor inicial e prazo devem ser positivos.", badRequestResult.Value);
        }

        [Fact]
        public void TestCalcularInvestimento_Prazo_Menor_1() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 100, 
                PrazoEmMeses = 0 //prazo menor que 1
            });
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Valor inicial e prazo devem ser positivos.", badRequestResult.Value);
        }

        [Fact]
        public void TestCalcularInvestimento_Prazo6m() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 5000,
                PrazoEmMeses = 3 // Menos de 6 meses
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

            // Verificar o imposto
            var expectedImposto = output.ResultadoBruto * 0.225m;
            Assert.Equal(expectedImposto, output.ResultadoBruto - output.ResultadoLiquido, 2); // Aceitar margem de erro de 2 casas decimais
            Assert.Equal(output.ResultadoBruto, output.ResultadoLiquido + expectedImposto, 2);
            Assert.True(output.ResultadoLiquido < output.ResultadoBruto); // Valor líquido deve ser menor que valor bruto
            Assert.Equal(output.ResultadoBruto - expectedImposto, output.ResultadoLiquido, 2); // Valor líquido é valor bruto menos o imposto
        }



        [Fact]
        public void TestCalcularInvestimento_Prazo_12_e_24m() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 10000,
                PrazoEmMeses = 24 // Entre 12 e 24 meses
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

            // Verificar o imposto
            var expectedImposto = output.ResultadoBruto * 0.175m;
            Assert.Equal(expectedImposto, output.ResultadoBruto - output.ResultadoLiquido, 2); // Aceitar margem de erro de 2 casas decimais
            Assert.Equal(output.ResultadoBruto, output.ResultadoLiquido + expectedImposto, 2);
            Assert.True(output.ResultadoLiquido < output.ResultadoBruto); // Valor líquido deve ser menor que valor bruto
            Assert.Equal(output.ResultadoBruto - expectedImposto, output.ResultadoLiquido, 2); // Valor líquido é valor bruto menos o imposto
        }

        [Fact]
        public void TestCalcularInvestimento_6M() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 3000,
                PrazoEmMeses = 6
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

            // Verificar o imposto
            var expectedImposto = output.ResultadoBruto * 0.225m;
            Assert.Equal(output.ResultadoBruto - expectedImposto, output.ResultadoLiquido, 2); // Valor líquido é valor bruto menos o imposto
            Assert.True(output.ResultadoLiquido < output.ResultadoBruto); // Valor líquido deve ser menor que valor bruto
        }

        [Fact]
        public void TestCalcularInvestimento_12M() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 5000,
                PrazoEmMeses = 12
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

            // Verificar o imposto
            var expectedImposto = output.ResultadoBruto * 0.20m;
            Assert.Equal(output.ResultadoBruto - expectedImposto, output.ResultadoLiquido, 2); // Valor líquido é valor bruto menos o imposto
            Assert.True(output.ResultadoLiquido < output.ResultadoBruto); // Valor líquido deve ser menor que valor bruto
        }

        [Fact]
        public void TestCalcularInvestimento_18M() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 7500,
                PrazoEmMeses = 18
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

            // Verificar o imposto
            var expectedImposto = output.ResultadoBruto * 0.175m;
            Assert.Equal(output.ResultadoBruto - expectedImposto, output.ResultadoLiquido, 2); // Valor líquido é valor bruto menos o imposto
            Assert.True(output.ResultadoLiquido < output.ResultadoBruto); // Valor líquido deve ser menor que valor bruto
        }

        [Fact]
        public void TestCalcularInvestimento_36() {
            // Arrange
            var controller = new CalculoCdbController();

            // Act
            var result = controller.CalcularInvestimento(new CalculoCdbInput {
                ValorInicial = 10000,
                PrazoEmMeses = 36
            });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<CalculoCdbOutput>(okResult.Value);

            // Verificar o imposto
            var expectedImposto = output.ResultadoBruto * 0.15m;
            Assert.Equal(output.ResultadoBruto - expectedImposto, output.ResultadoLiquido, 2); // Valor líquido é valor bruto menos o imposto
            Assert.True(output.ResultadoLiquido < output.ResultadoBruto); // Valor líquido deve ser menor que valor bruto
        }
    }
}
