using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.Entities;
using TBC.Domain.Exceptions;
using TBC.Persistence.Repositories;

namespace TBC.Application.Queries
{
    public class GetPersonQuery : IRequest<List<PersonEntity>>
    {
        public int PersonId { get; set; }
    }

    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, List<PersonEntity>>
    {
        private readonly IPersonRepository _personRepository;
        public GetPersonQueryHandler(IPersonRepository personRepository) => _personRepository = personRepository;
        

        public async Task<List<PersonEntity>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            return (await _personRepository.GetPersonByIdAsync(request.PersonId, cancellationToken))!;
        }
    }
}
