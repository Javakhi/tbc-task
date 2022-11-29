using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC.Domain.Entities;

namespace TBC.Persistence.Repositories
{
    public interface IPersonRepository
    {
        Task<PersonEntity> AddPersonAsync(PersonEntity entity, CancellationToken cancellationToken = default);
        Task<List<PersonEntity?>> GetPersonByIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<PersonEntity> UpdatePersonInformation(int id, PersonEntity person, CancellationToken cancellationToken = default);
        Task<PersonEntity> DeletePersonByIdAsync(int personId, CancellationToken cancellationToken = default);
    }
}
