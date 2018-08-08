using System.Collections.Generic;
using System.Threading.Tasks;
using CadProfissao.Application.Commands;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadProfissao.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IHandleNotification _notification;

        public ProfissionaisController(IMediator mediator, IHandleNotification notification)
        {
            _mediator = mediator;
            _notification = notification;
        }

        // GET: api/Profissionais
        [HttpGet]
        public async Task<ActionResult> GetAsync() => Ok(await _mediator.Send(new ListaProfissionaisQuery()));

        // GET: api/Profissionais/Total
        [HttpGet("Total")]
        public async Task<ActionResult> ObtemTotal() => Ok(await _mediator.Send(new Query()));

        // GET: api/Profissionais/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id) => "value";

        // POST: api/Profissionais
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfissionalCommand command)
        {
            var response = await _mediator.Send(command);

            if (_notification.Status == HandlerStatus.Falha) return BadRequest(_notification.Erros);

            return Ok();
        }

        // PUT: api/Profissionais/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
