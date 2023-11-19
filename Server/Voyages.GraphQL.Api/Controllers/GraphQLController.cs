using System;
using System.Threading.Tasks;
using Voyages.GraphQL.Api.GraphqlCore;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using Microsoft.AspNetCore.Cors;

namespace Voyages.GraphQL.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [DisableCors]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphqlQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
