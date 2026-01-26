using Circulars.Application.Features.LookUps.Lk_Message.Command.Delete;
using Circulars.Application.Features.LookUps.Lk_Message.Command.Put;
using Circulars.Application.Features.LookUps.Lk_Message.Query.GetAll;
using Circulars.Application.Features.LookUps.Lk_Message.Query.GetById;

namespace Circulars.API.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<ResponseDTO> Put(PutLK_MessageCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseDTO> Delete(Guid Id)
        {
            return await _mediator.Send(new DeleteLK_MessageCommand { Id = Id });
        }

        [HttpGet]
        public async Task<ResponseDTO> Get(int pageSize, int pageNumber)
        {
            return await _mediator.Send(new GetAllLK_MessageQuery { PageIndex = pageNumber, PageSize = pageSize });

        }
        [HttpGet("GetLastMessage")]
        public async Task<ResponseDTO> GetLastMessage()
        {
            return await _mediator.Send(new GetLastMessageQuery {});
        }


    }

}
