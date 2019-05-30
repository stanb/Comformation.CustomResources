using Amazon;
using Amazon.CloudFormation;
using Comformation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaFunction = Comformation.Lambda.Function;

namespace Comformation.CustomResources.RunLambda
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var region = RegionEndpoint.EUWest1;
            var sandboxId = Guid.NewGuid().ToString();

            var runService1 = new StartCodeBuildResource
            {
                LogicalId = "RunService1",
                Properties = new StartCodeBuildProperties
                {
                    ServiceToken = "arn:aws:lambda:eu-west-1:394351388697:function:CustomResourceSampleLambda",
                    ProjectArn = "<service1 codebuild project arn>",
                    Environment = new Dictionary<string, Union<string, Comformation.IntrinsicFunctions.IntrinsicFunction>>
                    {
                        { "TF_VERSION", "0.12.0" },
                        { "TF_SERVICE", "Service1" },
                    }
                }
            };

            var runService2 = new StartCodeBuildResource
            {
                LogicalId = "RunService2",
                DependsOn = runService1.LogicalId,
                Properties = new StartCodeBuildProperties
                {
                    ServiceToken = "arn:aws:lambda:eu-west-1:394351388697:function:CustomResourceSampleLambda",
                    ProjectArn = "<service2 codebuild project arn>",
                    Environment = new Dictionary<string, Union<string, Comformation.IntrinsicFunctions.IntrinsicFunction>>
                    {
                        { "TF_VERSION", "0.12.0" },
                        { "TF_SERVICE", "Service2" },
                    }
                }
            };

            var template = new Template
            {
                Resources = new Resources
                {
                    runService1,
                    runService2
                }
            };

            var request = new Amazon.CloudFormation.Model.CreateStackRequest
            {
                StackName = $"test-lambda-{sandboxId}",
                TemplateBody = template.ToString(),
                Capabilities = new List<string> { "CAPABILITY_NAMED_IAM" }
            };

            var cloudformation = new AmazonCloudFormationClient(region);
            var createResponse = await cloudformation.CreateStackAsync(request);
        }
    }
}
