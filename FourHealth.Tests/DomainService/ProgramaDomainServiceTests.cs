using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using FourHealth.DomainServices.Interfaces;
using FourHealth.DomainServices;
using FourHealth.Domain.Repositories;
using FourHealth.Domain.Entities;
using NSubstitute;
using Xunit;
using System.Runtime.CompilerServices;
using FakeItEasy;

namespace FourHealth.Tests.DomainService
{
    public class ProgramaDomainServiceTests : UnitTestsBase
    {
        private IProgramaDomainService programaDomainService;
        private IProgramaRepository repository;

        public ProgramaDomainServiceTests()
        {
            OverrideRegistration(x => Substitute.For<IProgramaRepository>());
            repository = InstanceOf<IProgramaRepository>();
           programaDomainService = new ProgramaDomainService(repository);

        }
        
        [Fact]
        public void InclusaoComSucesso()
        {
            var programa = new Programa
            {
                Nome = "Programa menos fumantes, mais saúde.",
                Descricao = "",
                Questionario = new Questionario()
              
            };

            repository.Create(Arg.Any<Programa>()).Returns(programa);

            var result = programaDomainService.Create(programa);

            Assert.NotNull(result);
            Assert.Equal( programa, result.Result);

        }

        [Fact]
        public void InclusaoComErro_NomeSemValorMinimo()
        {
            var programa = new Programa
            {
                Nome = "Fumantes",
                Descricao = "",
                Questionario = new Questionario()

    };

            repository.Create(Arg.Any<Programa>()).Returns(programa);

            var result = programaDomainService.Create(programa);

            Assert.NotNull(result);
            Assert.Equal("O campo 'Nome' deve ter pelo menos 10 caracteres", result.Errors[0]);
        }

        [Fact]
        public void InclusaoComErro_NomeComValorMaximo()
        {
            var programa = new Programa
            {
                Nome = "Programa menos fumantes, mais saúde.".PadLeft(300),
                Descricao = "",
                Questionario = new Questionario()

        };

            repository.Create(Arg.Any<Programa>()).Returns(programa);

            var result = programaDomainService.Create(programa);

            Assert.NotNull(result);
            Assert.Equal("O campo 'Nome' deve ter no máximo 150 caracteres", result.Errors[0]);
        }

        [Fact]
        public void InclusaoComErro_IdadeMinimaMaiorQueMaxima()
        {
            var programa = new Programa
            {
                Nome = "Programa menos fumantes, mais saúde.",
                Descricao = "",
                IdadeMaxima = 20,
                IdadeMinima = 51,
                Questionario = new Questionario()

        };

            repository.Create(Arg.Any<Programa>()).Returns(programa);

            var result = programaDomainService.Create(programa);

            Assert.NotNull(result);
            Assert.Equal("Idade mínima não pode maior que a máxima.", result.Errors[0]);
        }

        [Fact]
        public void InclusaoComErro_QuestionarioInvalido()
        {
            var programa = new Programa
            {
                Nome = "Programa menos fumantes, mais saúde.",
                Descricao = "",
                IdadeMaxima = 50,
                IdadeMinima = 49,
                Questionario = null

        };

            repository.Create(Arg.Any<Programa>()).Returns(programa);

            var result = programaDomainService.Create(programa);

            Assert.NotNull(result);
            Assert.Equal("Questionário informado é inválido.", result.Errors[0]);
        }
    }
}
