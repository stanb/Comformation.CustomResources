using Amazon;
using Amazon.CloudFormation;
using RunTerraform;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comformation.CustomResources.RunLambda
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var region = RegionEndpoint.EUWest1;
            var sandboxId = Guid.NewGuid().ToString();

            var backendBucket = new S3.Bucket.BucketResource
            {
                LogicalId = "BackendBucket",
                Properties =
                {
                    BucketName = $"stan-test-{sandboxId}",
                }
            };

            var runService1 = new CodeBuildRunTerraformResource
            {
                LogicalId = "RunService1",
                DependsOn = backendBucket.LogicalId,
                Properties = new StartCodeBuildProperties<RunTerraformRequest>
                {
                    ServiceToken = "arn:aws:lambda:eu-west-1:394351388697:function:CustomResourceSampleLambda",
                    ProjectArn = "<service1 codebuild project arn>",
                    Environment = new RunTerraformRequest
                    {
                        Version = "0.12.2",
                        Backend = new BackendS3
                        {
                            Bucket = "stan-test-{sandboxId}",
                            Key = "Service1",
                            Region = region.SystemName
                        },
                        Vars = new Dictionary<string, string>
                        {
                            { "sandbox_id", sandboxId },
                            { "owner", "Stan" },
                            { "key_name", "" }
                        },
                        VarFile = null,
                        FromModule = "https://github.com/stanb/terraform-samples/tree/master/aws/single-instance"
                    }
                }
            };

            //var runService2 = new StartCodeBuildResource
            //{
            //    LogicalId = "RunService2",
            //    DependsOn = runService1.LogicalId,
            //    Properties = new StartCodeBuildProperties<RunTerraform>
            //    {
            //        ServiceToken = "arn:aws:lambda:eu-west-1:394351388697:function:CustomResourceSampleLambda",
            //        ProjectArn = "<service2 codebuild project arn>",
            //        //Environment = new Dictionary<string, Union<string, Comformation.IntrinsicFunctions.IntrinsicFunction>>
            //        //{
            //        //    { "TF_VERSION", "0.12.0" },
            //        //    { "TF_SERVICE", "Service2" },
            //        //}
            //    }
            //};

            var template = new Template
            {
                Resources = new Resources
                {
                    runService1,
                    //runService2
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
