using Circulars.Application.Features.RelatedDocuments.Command.Post;
using Circulars.Application.Features.RelatedDocuments.Command.Put;
using Circulars.Application.Features.RelatedDocuments.Dto;
using Circulars.Application.Features.RelatedDocuments.Query.GetAllByCircularId;
using Circulars.Application.Features.RelatedDocuments.Query.GetIssuerNumberSourceByDate;
using Circulars.Application.Features.RelatedDocuments.Query.GetIssuerSourceByCircularNumber;
using Circulars.Application.Features.RelatedDocuments.Query.GetSourceNumberByCircularIssuer;
using Circulars.Domain.Models;

namespace Circulars.API.Controllers
{

    public class RelatedDocumentsController : BaseController
    {
        private readonly IMediator _mediator;

        public RelatedDocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region post
        [HttpPost]
        public async Task<ResponseDTO> PostRelatedDouments(PostRelatedDoumentsCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put
        [HttpPut]
        public async Task<ResponseDTO> PutRelatedDocumnet([FromForm] PutRelatedDocumentCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Get
        [HttpGet("GetAllRelatedDocumentsByCircularId/{CircularId}")]
        public async Task<ResponseDTO> GetAllRelatedDocumentsByCircularId(Guid CircularId)
        {

            return await _mediator.Send(new GetAllRelatedDocumentsByCircIdQuery { CircularId = CircularId });
        }

        [HttpGet("GetIssuerSourceByCircularNumber/{CircularNumber}")]
        public async Task<ResponseDTO> GetIssuerSourceByCircularNumber(string CircularNumber, Guid CircularId)
        {

            return await _mediator.Send(new GetIssuerSourceByCircularNumberQuery 
            {
                CircularNumber =  CircularNumber, 
                CircularId=CircularId 
            });
        }

        [HttpGet("GetSourceNumberByCircularIssuerIdAndDate")]
        public async Task<ResponseDTO> GetSourceNumberByCircularIssuerAndDate([FromQuery] GetCircularNumberByIsserIdAndDateDto Dto)
        {
            return await _mediator.Send(new GetSourceNumberByCircularIssuerQuery
            {
                CircularIssuerId = Dto.CircularIssuerId,
                Date = Dto.Date,
                CircularId = Dto.CircularId
            });
        }

        [HttpGet, Route("GetIssuerNumberSourceByDate")]
        public Task<ResponseDTO> GetIssuerNumberSourceByDate(DateTime date, Guid circularId)
        {
            return _mediator.Send(new GetIssuerNumberSourceByDateQuery()
            {
                Date = date,
                CircularId = circularId
            });
        }
        #endregion
    }
}
