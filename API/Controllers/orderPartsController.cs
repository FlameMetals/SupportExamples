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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FFM.API.Controllers
{
    /// <summary>
    /// OrderParts Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class orderPartsController : ControllerBase
    {

        private readonly FFM_DbContext _FFM_DbContext;

        /// <summary>
        /// OrderParts Controller Constructor
        /// </summary>
        /// <param name="httpClientFactory">IHttpClientFactory</param>
        /// <param name="configuration">Configuration properties</param>
        /// <param name="FFM_DbContext">FFM DB Context</param>
        /// <param name="VS_DbContext">Visual Shop DB Context</param>
        /// <param name="mapper">Automapper Interface</param>
        public orderPartsController(FFM_DbContext FFM_DbContext)
        {
            _FFM_DbContext = FFM_DbContext;
        }

        /// <summary>
        /// Get an orderPart by ID.
        /// </summary>
        /// <param name="id">Guid ID of the Header - 5AB4CB69-7982-44FA-97CD-03E1D386E5E6</param>
        /// <returns>orderPartsHeaderDto</returns>
        /// <response code="200">Returns the Header info with the newest child dto</response>
        /// <response code="400">If ID is not formatted correctly.</response>
        /// <response code="404">If ID is not found.</response>
        [HttpGet("{id?}", Name = "GetOrderPart")]
        [ProducesResponseType(typeof(orderPartsHeader), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<orderPartsHeader>> GetOrderPart([FromRoute] Guid? id)
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    AllowTrailingCommas = true,
                    MaxDepth = 32,
                    //IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    WriteIndented = true,
                    //Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                if (id == null) id = Guid.Parse("5AB4CB69-7982-44FA-97CD-03E1D386E5E6");
                FFM.DataAccessModels.App.orderPartsHeader _modelHeader = 
                                            await _FFM_DbContext.orderPartsHeader
                                            .Where(m => m.id == id)
                                            //.AsSplitQuery()
                                            .Include(x => x.orderParts.OrderByDescending(x => x.createdOnDate).Take(1))
                                            .ThenInclude(x => x.customerParts.customerPartsHeader.customerParts.OrderByDescending(x => x.createdOnDate).Take(1))
                                            .FirstOrDefaultAsync(m => m.id == id)
                                            ;
                //var results = JsonSerializer.Serialize(_modelHeader, options);
                
                return Content(JsonSerializer.Serialize(_modelHeader, options), "application/json");

                //return StatusCode(200, JsonSerializer.Serialize(_modelHeader, options).ToString());
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception);
            }
        }

    }
}