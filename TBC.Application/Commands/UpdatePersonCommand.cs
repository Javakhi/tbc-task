using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TBC.Domain.Entities;
using TBC.Persistence.Repositories;

namespace TBC.Application.Commands
{
    public class UpdatePersonCommand : IRequest
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int City { get; set; }

        public List<PersonNumber> PeronNumbers { get; set; }    
        //public string Number { get; set; }
    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        public UpdatePersonCommandHandler(IPersonRepository personRepository) => _personRepository = personRepository;



        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
           
            var person = new PersonEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                CityId = request.City,
                PersonNumbers = request.PeronNumbers
                //Number = request.Number
            };

            await _personRepository.UpdatePersonInformation(request.PersonId, person, cancellationToken);
            return Unit.Value;
        }
    }
}
