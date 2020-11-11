using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Petz.Data;
using Petz.Business.Services.Animal;
using Petz.Data.Repositories;
using Newtonsoft.Json;

namespace Petz.Api.Lambdas
{
    public class GetAnimalsFunction : BaseLambdaFunction
    {
        private readonly IAnimalRepository animalRepository;
        private readonly IAnimalService animalService;

        public GetAnimalsFunction()
        {
            animalRepository = new AnimalRepository(new ApplicationContext());
            animalService = new AnimalService(animalRepository);
        }

        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var name = request.QueryStringParameters?["name"]?.ToLower();

            var animals = !string.IsNullOrEmpty(name)
                    ? animalService.Get(x => x.Name == name)
                    : animalService.GetAll();

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(animals)
            };

            return response;
        }
    }
}
