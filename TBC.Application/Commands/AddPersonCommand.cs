using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.Entities;
using TBC.Domain.Enums;
using TBC.Persistence.Repositories;

namespace TBC.Application.Commands;

public class AddPersonCommand : IRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public GenderType Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public int CityId { get; set; }
    //public NumberType NumberType { get; set; }
    //public string? Number { get; set; }
    public List<PersonNumber>PersonNumbers { get; set; }
    public string? Image { get; set; }
    public List<RelatedPersonEntity> RelatedPersonId { get; set; }
}

public  class AddPersonCommandHandlers : IRequestHandler<AddPersonCommand>
{
    private readonly IPersonRepository _personRepository;
    public AddPersonCommandHandlers(IPersonRepository personRepository)=> _personRepository = personRepository;

    public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        var entity = new PersonEntity()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Gender = request.Gender,
            PersonalNumber = request.PersonalNumber,
            DateOfBirth = request.DateOfBirth,
            CityId = request.CityId,
            PersonNumbers = request.PersonNumbers,
            //NumberType = request.NumberType,
            //Number = request.Number,
            Image = request.Image,
            RelatedPerson = request.RelatedPersonId
        };
        await _personRepository.AddPersonAsync(entity, cancellationToken);
        return Unit.Value;
    }
}