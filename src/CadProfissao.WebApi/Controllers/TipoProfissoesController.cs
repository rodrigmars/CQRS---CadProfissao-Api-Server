using System.Threading.Tasks;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadProfissao.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProfissoesController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IHandleNotification _notification;

        public TipoProfissoesController(IMediator mediator, IHandleNotification notification)
        {
            _mediator = mediator;
            _notification = notification;
        }

        // GET: api/TipoProfissoes
        [HttpGet]
        public async Task<ActionResult> GetAsync() => Ok(await _mediator.Send(new ListaTipoProfissaoQuery()));

    }
}
