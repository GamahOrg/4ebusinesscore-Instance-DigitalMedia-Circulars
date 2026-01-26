
using Circulars.Application.Features.KPI.Query.QualityAndManagementIndicators;

namespace Circulars.API.Controllers
{
    public class KpiController : BaseController
    {
        private readonly IMediator _mediator;
        public KpiController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region Get
        [HttpGet("GeneralIndicatorsCirculars")]
        public Task<ResponseDTO> GeneralIndicatorsCirculars()
        {
            return _mediator.Send(new GeneralIndicatorsCircularsQuery { });
        }
        [HttpGet("UserAndOrgEngagementIndicators")]
        public Task<ResponseDTO> UserAndOrgEngagementIndicators()
        {
            return _mediator.Send(new UserAndOrgEngagementIndicatorsQuery { });
        }
        [HttpGet("ApprovalAndImplementationIndicators")]
        public Task<ResponseDTO> ApprovalAndImplementationIndicators()
        {
            return _mediator.Send(new ApprovalAndImplementationIndicatorsQuery { });
        }
        [HttpGet("InteractionIndicatorsAndAttachments")]
        public Task<ResponseDTO> InteractionIndicatorsAndAttachments()
        {
            return _mediator.Send(new InteractionIndicatorsAndAttachmentsQuery { });
        }
        [HttpGet("QualityAndManagementIndicators")]
        public Task<ResponseDTO> QualityAndManagementIndicators()
        {
            return _mediator.Send(new QualityAndManagementIndicatorsQuery { });
        }
        #endregion


    }

}
