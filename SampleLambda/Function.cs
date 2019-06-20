using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Comformation.CustomResources.SampleLambda
{
    public class CustomResourceFunction
    {
        public async Task<CloudFormationResponse> FunctionHandler(CloudFormationEvent<StartCodeBuild> @event, ILambdaContext context)
        {
            var json = JsonConvert.SerializeObject(@event, Formatting.Indented);
            context.Logger.LogLine(json);
            object data;
            try
            {
                switch (@event.RequestType)
                {
                    case RequestType.Create:
                        data = await Create(@event, context);
                        break;
                    case RequestType.Update:
                        data = await Update(@event, context);
                        break;
                    case RequestType.Delete:
                        data = await Delete(@event, context);
                        break;
                }

                return await CloudFormationResponse.CompleteCloudFormationResponse(new { SomeData = "some data" }, @event, context);
            }
            catch (Exception ex)
            {
                return await CloudFormationResponse.CompleteCloudFormationResponse(new { Error = ex.ToString() }, @event, context);
            }
        }

        private Task<object> Delete(CloudFormationEvent<StartCodeBuild> @event, ILambdaContext context)
        {
            return Task.FromResult<object>(new { SomeData = "some data", Step = "Delete" });
        }

        private Task<object> Update(CloudFormationEvent<StartCodeBuild> @event, ILambdaContext context)
        {
            return Task.FromResult<object>(new { SomeData = "some data", Step = "Update" });
        }

        private Task<object> Create(CloudFormationEvent<StartCodeBuild> @event, ILambdaContext context)
        {
            return Task.FromResult<object>(new { SomeData = "some data", Step = "Create" });
        }
    }
}
