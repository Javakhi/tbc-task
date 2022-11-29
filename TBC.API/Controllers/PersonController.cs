using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Commands;
using TBC.Application.Queries;
using TBC.Domain.Entities;

namespace TBC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ISender _sender;

        public PersonController(ISender sender) => _sender = sender;

        [HttpGet("GetPerson")]
        public async Task<IActionResult> GetPersonById(int personId, CancellationToken cancellationToken)
        {
            var query = new GetPersonQuery() { PersonId = personId };
            var response = await _sender.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson(AddPersonCommand command, CancellationToken cancellationToken)
        {
            await _sender.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPut("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson(PersonEntity person, CancellationToken cancellationToken)
        {
            var query = new UpdatePersonCommand()
            {
                PersonId = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                PeronNumbers = person.PersonNumbers,
            };

            var response = await _sender.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("DeletePerson")]
        public async Task<IActionResult> DeletePerson(int person, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(new DeletePersonCommand{PersonId = person}, cancellationToken);
            return Ok(response);
        }
    }
}
