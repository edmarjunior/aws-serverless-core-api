
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using Petz.Business.Services.Animal;
using Petz.Client.Requests;
using Petz.Data;
using Petz.Data.Repositories;
using System.Net;

namespace Petz.Api.Lambdas
{
    public class PostAnimalsFunction : BaseLambdaFunction
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalService _animalService;

        public PostAnimalsFunction()
        {
            _animalRepository = new AnimalRepository(new ApplicationContext());
            _animalService = new AnimalService(_animalRepository);
        }

        public APIGatewayProxyResponse Post(LambdaRequest request)
        {
            var animalRequest = JsonConvert.DeserializeObject<AddAnimalRequest>(request.Body);

            var animalModel = _animalService.Add(animalRequest);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.Created,
                Body = JsonConvert.SerializeObject(animalModel)
            };

            return response;
        }
    }
}
