using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using InventoryManager.Database;
using InventoryManager.BLL.Services;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace InverntoryManager;

public class GetPalletFunction
{
    public APIGatewayProxyResponse GetPallet(APIGatewayProxyRequest request)
    {
        if(request.PathParameters != null && request.PathParameters.ContainsKey("palletId")
            && int.TryParse(request.PathParameters["palletId"], out var palletId))
        {
            var inventoryManagerContext = new InventoryManagerContext();
            var palletService = new PalletService(inventoryManagerContext);
            var getPalletResponse = palletService.GetPallet(palletId);

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(getPalletResponse)
            };
        }

        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.NotFound
        };
    }
}