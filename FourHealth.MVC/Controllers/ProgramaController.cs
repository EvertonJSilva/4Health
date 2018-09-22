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
    /// Controle de cadastro de programas
    /// </summary>
    [Route("api/[controller]")]
    public class ProgramaController : Controller
    {
        private readonly IProgramaAppService appService;

        public ProgramaController(IProgramaAppService appService)
        {
            this.appService = appService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ProgramaDTO> Get([FromQuery]ProgramaFilterDTO filter)
        {
            return appService.List(filter);
        }

        // GET api/<controller>/5
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var programa = appService.getById(id);

            if (programa == null)
            {
                return NotFound();
            }

            return Ok(programa);
        }


        // POST api/<controller>
        [HttpPost]
        public GenericResult<ProgramaDTO> Post([FromBody]ProgramaDTO programa)
        {
            return appService.Create(programa);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]ProgramaDTO programa )
        {
            return appService.Update(programa);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return appService.Delete(id);
        }
    }
}
