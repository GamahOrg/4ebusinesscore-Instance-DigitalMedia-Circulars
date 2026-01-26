

using Circulars.Application.Features.LookUps.Lk_Enforcement.Command.Post;
using Circulars.Application.Features.LookUps.Lk_Issuer.Command.Post;

namespace Circulars.API.Controllers
{
    public class LookUpsController : BaseController
    {
        private readonly IMediator _mediator;
        public LookUpsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region LK_Approval

        [HttpPost("PostLkApproval")]
        public async Task<ResponseDTO> PostLkApproval([FromForm] PostApprovalCommand PostApprovalCommand)
        {
            return await _mediator.Send(PostApprovalCommand);
        }

        [HttpPut("PutLK_Approval")]
        public async Task<ResponseDTO> PutLK_Approval(PutApprovalCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("DeleteLK_Approval/{Id}")]
        public async Task<ResponseDTO> DeleteLkApproval(Guid Id)
        {
            return await _mediator.Send(new DeleteApprovalCommand { Id = Id });
        }

        [HttpGet("GetLkApproval")]
        public async Task<ResponseDTO> GetLkApproval(int pageSize, int pageNumber)
        {
            return await _mediator.Send(new GetAllLkApprovalQuery { PageIndex = pageNumber , PageSize =pageSize });

        }
        [HttpGet("GetLK_ApprovalById/{Id}")]
        public async Task<ResponseDTO> GetLK_ApprovalById(Guid Id)
        {
            return await _mediator.Send(new GetLkApprovalByIdQuery { Id = Id });
        }

        #endregion

        #region LK_Enforcement

        [HttpPost("PostLkEnforcement")]
        public async Task<ResponseDTO> PostLkEnforcement([FromForm] PostEnforcementCommand PostEnforcementCommand)
        {
            return await _mediator.Send(PostEnforcementCommand);
        }

        [HttpPut("PutLK_Enforcement")]
        public async Task<ResponseDTO> PutLK_Enforcement(PutEnforcementCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("DeleteLK_Enforcement/{Id}")]
        public async Task<ResponseDTO> DeleteLkEnforcement(Guid Id)
        {
            return await _mediator.Send(new DeleteEnforcementCommand { Id = Id });
        }

        [HttpGet("GetLkEnforcement")]
        public async Task<ResponseDTO> GetLkEnforcement(int pageSize, int pageNumber)
        {
            return await _mediator.Send(new GetAllLkEnforcementQuery { PageIndex = pageNumber , PageSize = pageSize });

        }
        [HttpGet("GetLK_EnforcementById/{Id}")]
        public async Task<ResponseDTO> GetLK_EnforcementById(Guid Id)
        {
            return await _mediator.Send(new GetLkEnforcementByIdQuery { Id = Id });
        }

        #endregion

        #region LK_Issuer

        [HttpPost("PostLkIssuer")]
        public async Task<ResponseDTO> PostLkIssuer([FromForm] PostIssuerCommand PostIssuerCommand)
        {
            return await _mediator.Send(PostIssuerCommand);
        }

        [HttpPut("PutLK_Issuer")]
        public async Task<ResponseDTO> PutLK_Issuer(PutIssuerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("DeleteLK_Issuer/{Id}")]
        public async Task<ResponseDTO> DeleteLkIssuer(Guid Id)
        {
            return await _mediator.Send(new DeleteIssuerCommand { Id = Id });
        }

        [HttpGet("GetLkIssuer")]
        public async Task<ResponseDTO> GetLkIssuer(int pageSize, int pageNumber)
        {
            return await _mediator.Send(new GetAllLkIssuerQuery { PageIndex = pageNumber , PageSize = pageSize });

        }

        [HttpGet("GetLK_IssuerById/{Id}")]
        public async Task<ResponseDTO> GetLK_IssuerById(Guid Id)
        {
            return await _mediator.Send(new GetALkIssuerByIdQuery { Id = Id });
        }


        #endregion
    }
}
