
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AnimalModel = Petz.Business.Models.Animal;

namespace Petz.Business.Services.Animal
{
    public interface IAnimalRepository
    {
        IEnumerable<AnimalModel> GetAll();
        IEnumerable<AnimalModel> Get(Expression<Func<AnimalModel, bool>> predicate);
        AnimalModel FindById(int id);
        AnimalModel Add(AnimalModel animal);
        void Update(AnimalModel animal);
        void Remove(int id);
    }
}
