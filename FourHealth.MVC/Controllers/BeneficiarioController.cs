using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using FourHealth.Domain.Results;

namespace FourHealth.MVC.Controllers
{
    /// <summary>
    /// Controle de cadastro de beneficiários
    /// </summary>
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var beneficiario = appService.getById(id);

            if( beneficiario == null)
            {
                return NotFound();
            }

            return Ok(beneficiario);
        }

        
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
