using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLSample.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace GraphQLSample.Api.Controllers
{
    [ApiController]
    [Route("graphql/users")]
    public class UsersController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public UsersController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0 )
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
