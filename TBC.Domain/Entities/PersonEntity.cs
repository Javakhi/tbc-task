using TBC.Domain.Enums;

namespace TBC.Domain.Entities;

public class PersonEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public GenderType Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public int CityId { get; set; }
    public CityEntity? City { get; set; }
    //public NumberType NumberType { get; set; }
    //public string? Number { get; set; }
    public List<PersonNumber> PersonNumbers { get; set; }
    public string? Image { get; set; }
    //public List<int>? RelatedPersonId { get; set; }
    public List<RelatedPersonEntity>? RelatedPerson { get; set; }
}

public class RelatedPersonEntity 
{
    public int PersonId { get; set; }        
    public int RelatedPersonId { get; set; }
    public RelatedPersonType ? PersonType { get; set; }
}

public class PersonNumber
{
    public int PersonId { get; set; }
    public NumberType NumberType { get; set; }
    public string? Number { get; set; }
}