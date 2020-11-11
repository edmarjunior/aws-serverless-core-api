using Petz.Client.Requests;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AnimalModel = Petz.Business.Models.Animal;

namespace Petz.Business.Services.Animal
{
    public interface IAnimalService
    {
        IEnumerable<AnimalModel> GetAll();
        IEnumerable<AnimalModel> Get(Expression<Func<AnimalModel, bool>> predicate);
        AnimalModel FindById(int id);
        AnimalModel Add(AddAnimalRequest animal);
        void Update(AnimalModel animal);
        void Remove(int id);
    }
}
