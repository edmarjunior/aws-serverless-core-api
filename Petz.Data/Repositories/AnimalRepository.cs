using Petz.Business.Models;
using Petz.Business.Services.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Petz.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationContext _context;

        public AnimalRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAll() => _context.Animals.ToList();

        public IEnumerable<Animal> Get(Expression<Func<Animal, bool>> predicate) => _context.Animals.Where(predicate).ToList();

        public Animal FindById(int id) => _context.Animals.Find(id);

        public Animal Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
            return animal;
        }

        public void Update(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
