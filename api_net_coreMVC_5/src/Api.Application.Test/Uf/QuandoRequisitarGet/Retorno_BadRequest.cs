using Application.Controllers;
using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitarGet
{
    public class Retorno_BadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possível realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUfService>();

            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    Sigla = "SP"
                });

            _controller = new UfsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
