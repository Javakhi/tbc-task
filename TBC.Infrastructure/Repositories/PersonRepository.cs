using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBC.Domain.Entities;
using TBC.Domain.Exceptions;
using TBC.Infrastructure.DbContexts;
using TBC.Persistence.Repositories;

namespace TBC.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;
        public PersonRepository(PersonDbContext dbContext) => _dbContext = dbContext;


        public async Task<List<PersonEntity>> GetByPersonByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<PersonEntity>().Where(x => x.Id == userId).ToListAsync(cancellationToken);
        }

        public async Task<PersonEntity> AddPersonAsync(PersonEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<PersonEntity>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<PersonEntity> UpdatePersonInformation(int id, PersonEntity person, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<PersonEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null) throw new EntityNotFoundException();

            entity.FirstName = person.FirstName;
            entity.LastName = person.LastName;
            entity.Gender = person.Gender;
            entity.DateOfBirth = person.DateOfBirth;
            entity.City = person.City;
            entity.Number = person.Number;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }


        public async Task<PersonEntity> DeletePersonByIdAsync(int id, PersonEntity person, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<PersonEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null) throw new EntityNotFoundException();

            _dbContext.Set<PersonEntity>().Remove(person);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
