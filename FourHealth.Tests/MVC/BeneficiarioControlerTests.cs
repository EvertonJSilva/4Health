using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using FourHealth.Domain.Repositories;
using FourHealth.Domain.Entities;
using NSubstitute;
using Xunit;

namespace FourHealth.Tests.MVC
{
    public class BeneficiarioControlerTests : UnitTestsBase
    {
        private FourHealth.MVC.Controllers.BeneficiarioController controller;

        public BeneficiarioControlerTests()
        {
            
            OverrideRegistration(x => Substitute.For<IBeneficiarioRepository>());
            
            controller = new FourHealth.MVC.Controllers.BeneficiarioController(InstanceOf<IBeneficiarioAppService>() );        
        }

        [Fact]
        public void ConsultaPorIdComSucesso()
        {
            var beneficiarioRepository = InstanceOf<IBeneficiarioRepository>();

            beneficiarioRepository.getById(Arg.Is(1)).Returns(new Beneficiario
            {
                Id = 1,
                Nome = "Teste"
            });


            var result = controller.Get(1);

            Assert.NotNull(result);        
            Assert.Equal(1, result.Id);
            Assert.Equal("Teste",result.Nome);
         
        }

        [Fact]
        public void InclusaoComSucesso()
        {

            var beneficiario = new Beneficiario
            {
                Nome = "teste da silva",
                Cpf = "02373492059"
            };

            var beneficiarioDto = new BeneficiarioDTO
            {
                Nome = "teste da silva",
                Cpf = "02373492059"
            };

            var beneficiarioRepository = InstanceOf<IBeneficiarioRepository>();
            beneficiarioRepository.Create(Arg.Any<Beneficiario>()).Returns(beneficiario);

            var result = controller.Post( beneficiarioDto);

            Assert.NotNull(result);
            Assert.True(result.Success);
        }

        [Fact]
        public void InclusaoComErro_NomeNaoInformado()
        {
            
            var beneficiario = new Beneficiario
            {
                Id = 1,
                Nome = "",
                Cpf = "02373492059"
            };
            var beneficiarioDto = new BeneficiarioDTO
            {
                Id = 1,
                Nome = "",
                Cpf = "02373492059"
            };

            var beneficiarioRepository = InstanceOf<IBeneficiarioRepository>();
            beneficiarioRepository.Create(Arg.Any<Beneficiario>()).Returns(beneficiario);

            var result = controller.Post(beneficiarioDto);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Contains("Nome", result.Errors[0]);
        }

        [Fact]
        public void InclusaoComErro_CpfInvalido()
        {

            var beneficiario = new Beneficiario
            {
                Id = 1,
                Nome = "teste da silva",
                Cpf = "0"
            };
            var beneficiarioDto = new BeneficiarioDTO
            {
                Id = 1,
                Nome = "teste da silva",
                Cpf = "0"
            };

            var beneficiarioRepository = InstanceOf<IBeneficiarioRepository>();
            beneficiarioRepository.Create(Arg.Any<Beneficiario>()).Returns(beneficiario);

            var result = controller.Post(beneficiarioDto);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Contains("Cpf", result.Errors[0]);
        }

        
    }
}
