using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Municipios;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGet
{
    public class Retorno_OK
    {
        private MunicipiosController _controller;
        [Fact(DisplayName = "É Possível Realizar o Get")]
        public async Task E_Possivel_Invocar_A_Controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
            .ReturnsAsync(
                new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo"
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}