using Circulars.Application.Features.Circulars.Dto;

namespace Circulars.API.Controllers
{

    public class CircularController : BaseController
    {
        private readonly IMediator _mediator;
        public CircularController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Post
        [HttpPost]
        public async Task<ResponseDTO> PostCircular([FromForm] PostCircularCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put
        [HttpPut]
        public async Task<ResponseDTO> PutCircular([FromForm] PutCircularCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut, Route("PutArchiveCircular")]
        public async Task<ResponseDTO> PutArchiveCircular([FromForm] PutArchiveCircularCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDTO> DeleteCircular(Guid id)
        {
            return await _mediator.Send(new DeleteCircularCommand { Id = id });
        }

        [HttpDelete]
        [Route("DeleteConfidentialCircular")]
        public async Task<ResponseDTO> DeleteConfidentialCircular(Guid id, Guid userId)
        {
            return await _mediator.Send(new DeleteConfidentialCircularCommand { Id = id, UserId = userId });
        }

        [HttpDelete]
        [Route("DeletePrivateCircular")]
        public async Task<ResponseDTO> DeletePrivateCircular(Guid id, Guid orgId)
        {
            return await _mediator.Send(new DeletePrivateCircularCommand { Id = id, OrgId = orgId });
        }

        #endregion

        #region Get
        [HttpGet("{circularId}")]
        public Task<ResponseDTO> GetCircularById(Guid circularId)
        {
            return _mediator.Send(new GetCircularByIdQuery { CircularId = circularId });
        }

        //[HttpGet, Route("GetAllArchievedCircular")]
        //public Task<ResponseDTO> GetAllArchievedCircular()
        //{
        //    return _mediator.Send(new GetAllArchievedCircularQuery());
        //    #region GetAllArchievedCircular

        //}

        [HttpGet, Route("GetAllCircularIssuer")]
        public Task<ResponseDTO> GetAllCircularIssuer()
        {
            return _mediator.Send(new GetAllCircularIssuerQuery());
        }

        [HttpGet, Route("GetAllCircularNumbers")]
        public Task<ResponseDTO> GetAllCircularNumbers(Guid CircularId)
        {
            return _mediator.Send(new GetAllCircularNumbersQuery
            {
                CircularId = CircularId
            });
        }

        //[HttpGet, Route("GetAllCircularSource")]
        //public Task<ResponseDTO> GetAllCircularSource()
        //{
        //    return _mediator.Send(new GetAllCircularSourceQuery());
        //}

        [HttpGet, Route("GetAllCircularsPublic")]
        public Task<ResponseDTO> GetAllCircularsPublic( [FromQuery]GetAllCircularsRequest request
            )
        {
            return _mediator.Send(new GetAllCircularsQuery()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageNumber,
                IsArchived = request.IsArchived,
                Ispublished = request.IsPublished,
                SearchTerm = request.Search,
                AdvancedSearch = new AdvancedSearch  {Name = request.Name,
                    AccreditationDate = request.AccreditationDate,
                    Number = request.Number, IssuerId = request.IssuerId,
                    OrgConcerned = request.OrgConcerned,
                    TaggedWords = request.TaggedWords
                }
            });
        }
  
        [HttpPost, Route("GetAllCircularsPrivateOrg")]
        public Task<ResponseDTO> GetAllCircularsPrivate(int pageSize, int PageNumber, string? search, bool IsArchived, bool IsPublished,
            string? name = "",
            string? number = "",
            DateTime? accreditationDate = null,
            string? taggedWords = "",
            List<Guid>? orgConcerned = null,
            Guid? org = null,
            Guid? issuerId = null)
        {
            return _mediator.Send(new GetAllPrivateCircularsQuery()
            {
                PageSize = pageSize,
                PageIndex = PageNumber,
                SearchTerm=search,
                IsArchived = IsArchived,
                IsPublished = IsPublished,
                AdvancedSearch = new AdvancedSearch
                {
                    Name = name,
                    AccreditationDate = accreditationDate,
                    Number =number,
                    IssuerId =issuerId,
                    OrgConcerned = orgConcerned,
                    Org = org,
                    TaggedWords =taggedWords
                }
            });
        }

        [HttpPost, Route("GetAllConfidentialCirculars")]
        public Task<ResponseDTO> GetAllConfidentialCirculars(int pageSize, int PageNumber, string? search, bool IsArchived, bool IsPublished,
            string? name = "",
            string? number = "",
            DateTime? accreditationDate = null,
            string? taggedWords = "",
            List<Guid>? orgConcerned = null,
            Guid? user = null,
            Guid? issuerId = null)
        {
            return _mediator.Send(new GetAllConfidentialCircularsQuery()
            {
                PageSize = pageSize,
                PageIndex = PageNumber,
                SearchTerm = search,
                IsArchived = IsArchived,
                IsPublished = IsPublished,
                AdvancedSearch = new AdvancedSearch
                {
                    Name = name,
                    AccreditationDate = accreditationDate,
                    Number =number,
                    IssuerId =issuerId,
                    OrgConcerned = orgConcerned,
                    User = user,
                    TaggedWords =taggedWords
                }
            });
        }
        #endregion


    }
}
