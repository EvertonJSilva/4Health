using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using FourHealth.Domain.Results;
using Microsoft.AspNetCore.Authorization;

namespace FourHealth.MVC.Controllers
{
    /// <summary>
    /// Controle de cadastro de perguntas
    /// </summary>
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class PerguntaController : Controller
    {
        private readonly IPerguntaAppService appService;

        public PerguntaController(IPerguntaAppService appService)
        {
            this.appService = appService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PerguntaDTO> Get([FromQuery]PerguntaFilterDTO filter)
        {
            return appService.List(filter);
        }

        // GET api/<controller>/5
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pergunta = appService.getById(id);

            if (pergunta == null)
            {
                return NotFound();
            }

            return Ok(pergunta);
        }


        // POST api/<controller>
        [HttpPost]
        public GenericResult<PerguntaDTO> Post([FromBody]PerguntaDTO pergunta)
        {
            return appService.Create(pergunta);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]PerguntaDTO pergunta)
        {
            return appService.Update(pergunta);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return appService.Delete(id);
        }
    }
}
