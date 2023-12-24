using Esoft.Documents.Dto;
using Esoft.Documents.Service.Interface.Services.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Esoft.Documents.DocumentsWebApi.Controllers
{
    //[Authorize]
    [ApiController]    
    [Route("api/test")]
    [ControllerName("Document")]
    [ApiVersionNeutral]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentQueryService _documentQueryService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentQueryService documentQueryService)
        {
            _logger = logger;
            _documentQueryService = documentQueryService;
        }

        /// <summary>
        /// Returns documents with statistics.
        /// </summary>
        /// <param name="x">Number of items param</param>
        /// <returns>Single DocumentResponse object</returns>
        /// <response code="200">OK with DocumentResponse</response>
        /// <response code="404">Documents not found</response>
        /// <response code="403">User is not authorized for getting documents with specified x</response>
        /// <response code="500">Any exception</response>
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status500InternalServerError)]
        [HttpPost("{x:int}", Name = "getDocumentInfo")]
        public async Task<ActionResult<DocumentResponse>> GetDocumentInfo(int x, IFormFile file)
        {
            _logger.LogInformation($"Hitting [{nameof(GetDocumentInfo)}] with param: [{nameof(x)}]={x}");
            
            var result = _documentQueryService.GetDocumentStatistics(file, x);
            return Ok(result);            
        }
    }
}
