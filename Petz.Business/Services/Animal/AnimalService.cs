using Petz.Client.Requests;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AnimalModel = Petz.Business.Models.Animal;

namespace Petz.Business.Services.Animal
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<AnimalModel> GetAll() => _animalRepository.GetAll();

        public IEnumerable<AnimalModel> Get(Expression<Func<AnimalModel, bool>> predicate) => _animalRepository.Get(predicate);

        public AnimalModel FindById(int id) => _animalRepository.FindById(id);

        public AnimalModel Add(AddAnimalRequest animal)
        {
            if (string.IsNullOrEmpty(animal?.Name))
            {
                throw new Exception("Missing parameter Name");
            }

            var animalModel = _animalRepository.Add(new AnimalModel { Name = animal.Name });

            return animalModel;
        }

        public void Update(AnimalModel animal)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
