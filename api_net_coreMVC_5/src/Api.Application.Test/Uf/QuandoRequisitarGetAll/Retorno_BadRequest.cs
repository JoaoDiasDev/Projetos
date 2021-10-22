using Application.Controllers;
using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possível realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUfService>();
            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<UfDto>
                {
                    new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "São Paulo",
                        Sigla = "SP",
                    },
                    new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Amazonas",
                        Sigla = "AM",
                    }
                }
            );

            _controller = new UfsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
