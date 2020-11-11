
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace Petz.Api.Lambdas
{
    public class BaseLambdaFunction
    {
    }
}
