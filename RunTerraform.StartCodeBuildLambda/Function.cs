using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using RunTerraform;
using Comformation.CustomResources;
using Newtonsoft.Json;
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RunTerraform.StartCodeBuildLambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(CloudFormationEvent<RunTerraformRequest> input, ILambdaContext context)
        {
            var json = JsonConvert.SerializeObject(input, Formatting.Indented);
            context.Logger.LogLine(json);
            object data;
            try
            {
                switch (input.RequestType)
                {
                    case RequestType.Create:
                        data = await Create(input, context);
                        break;
                    case RequestType.Update:
                        data = await Update(input, context);
                        break;
                    case RequestType.Delete:
                        data = await Delete(input, context);
                        break;
                }

                //return await CloudFormationResponse.CompleteCloudFormationResponse(new { SomeData = "some data" }, input, context);
            }
            catch (Exception ex)
            {
                //return await CloudFormationResponse.CompleteCloudFormationResponse(new { Error = ex.ToString() }, input, context);
            }
        }

        private Task<object> Delete(CloudFormationEvent<RunTerraformRequest> input, ILambdaContext context)
        {
            throw new NotImplementedException();
        }

        private Task<object> Update(CloudFormationEvent<RunTerraformRequest> input, ILambdaContext context)
        {
            throw new NotImplementedException();
        }

        private async Task<object> Create(CloudFormationEvent<RunTerraformRequest> input, ILambdaContext context)
        {
            var client = new AmazonCodeBuildClient();
            var request = new StartBuildRequest
            {
                EnvironmentVariablesOverride = BuildEnvironmentVariables(input)
            };

            var response = await client.StartBuildAsync(request);
            return null;
        }

        private List<EnvironmentVariable> BuildEnvironmentVariables(CloudFormationEvent<RunTerraformRequest> input)
        {
            var list = new List<EnvironmentVariable>
            {
                //new EnvironmentVariable { Name = "CFN_REQUEST", Value = JsonConvert.SerializeObject(input) }
                new EnvironmentVariable { Name = "CFN_CloudFormationRequest:RequestId", Value = input.RequestId },
                new EnvironmentVariable { Name = "CFN_CloudFormationRequest:RequestType", Value = input.RequestType.ToString() },
                new EnvironmentVariable { Name = "CFN_CloudFormationRequest:StackId", Value = input.StackId },
                new EnvironmentVariable { Name = "CFN_CloudFormationRequest:ResponseURL", Value = input.ResponseURL },
                new EnvironmentVariable { Name = "CFN_CloudFormationRequest:ResourceProperties:Version", Value = input.ResourceProperties.Version }
            };
            return list;
        }
    }
}
