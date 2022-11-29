using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.Entities;
using TBC.Domain.Exceptions;
using TBC.Persistence.Repositories;

namespace TBC.Application.Commands
{
    public class DeletePersonCommand : IRequest
    {
        public int PersonId { get; set; }
    }

    public  class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        public  DeletePersonCommandHandler(IPersonRepository personRepository) => _personRepository = personRepository;
        

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _personRepository.DeletePersonByIdAsync(request.PersonId, cancellationToken);
            return Unit.Value;
        }
    }
}
