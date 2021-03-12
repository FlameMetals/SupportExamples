using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FFM.DataAccess.App;
using FFM.DataAccessModels.App;

namespace FFM.API.Controllers
{
    /// <summary>
    /// CustomerParts Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class customerPartsController : ControllerBase
    {

        private readonly FFM_DbContext _FFM_DbContext;

        /// <summary>
        /// CustomerParts Controller Constructor
        /// </summary>
        /// <param name="httpClientFactory">IHttpClientFactory</param>
        /// <param name="configuration">Configuration properties</param>
        /// <param name="FFM_DbContext">FFM DB Context</param>
        /// <param name="VS_DbContext">Visual Shop DB Context</param>
        /// <param name="mapper">Automapper Interface</param>
        public customerPartsController(FFM_DbContext FFM_DbContext)
        {
            _FFM_DbContext = FFM_DbContext;
        }

        /// <summary>
        /// Get an customerPart by ID.
        /// </summary>
        /// <param name="id">Guid ID of the Header</param>
        /// <returns>customerPartsHeaderDto</returns>
        /// <response code="200">Returns the Header info with the newest child dto</response>
        /// <response code="400">If ID is not formatted correctly.</response>
        /// <response code="404">If ID is not found.</response>
        [HttpGet("{id}", Name = "GetCustomerPart")]
        [ProducesResponseType(typeof(customerPartsHeader), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<customerPartsHeader>> GetCustomerPart([FromRoute] Guid id)
        {
            try
            {
                var _modelHeader = await (from tblHeader in _FFM_DbContext.customerPartsHeader
                                          .AsNoTracking()
                                          .Include(x => x.customerParts.OrderByDescending(x => x.createdOnDate).Take(1))
                                          where tblHeader.id == id
                                          select tblHeader).FirstOrDefaultAsync();

                return StatusCode(200, _modelHeader);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception);
            }
        }

    }
}