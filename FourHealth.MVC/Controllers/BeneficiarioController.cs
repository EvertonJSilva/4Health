using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using FourHealth.Domain.Results;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FourHealth.MVC.Controllers
{
    [Route("api/[controller]")]
    public class BeneficiarioController : Controller
    {
        private readonly IBeneficiarioAppService appService;

        public BeneficiarioController(IBeneficiarioAppService appService)
        {
            this.appService = appService;
      
        }      

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BeneficiarioDTO> Get([FromQuery]BeneficiarioFilterDTO filter)
        {
            return appService.List(filter);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public BeneficiarioDTO Get(int id)
        {
            return appService.getById(id);
        }

        //public IActionResult Criar()
        //{
        //    return NotFound( )
        //}

        // POST api/<controller>
        [HttpPost]
        public GenericResult<BeneficiarioDTO> Post([FromBody]BeneficiarioDTO beneficiario)
        {
            return appService.Create(beneficiario);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]BeneficiarioDTO beneficiario)
        {
            return appService.Update(beneficiario);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return appService.Delete(id);
        }
    }
}
