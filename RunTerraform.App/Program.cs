using Comformation.CustomResources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RunTerraform.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "CFN_")
                .Build();

            var request = config.GetSection("CloudFormationRequest").Get<CloudFormationEvent<RunTerraformRequest>>();

            Console.WriteLine($"Install terraform {request.ResourceProperties.Version}");

            var install = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "./install.sh",
                    //UseShellExecute = true,
                    FileName = "sh",
                    //Arguments = request.ResourceProperties.Version,
                    Arguments = $"-c \"TF_VERSION={request.ResourceProperties.Version} ./install.sh\"",
                    //Arguments = "-c \"echo Hello World\"",
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true,
                }
            };
            //install.StartInfo.EnvironmentVariables.Add("TF_VERSION", request.ResourceProperties.Version);
            install.Start();
            install.WaitForExit();
            //var stdout = await install.StandardOutput.ReadToEndAsync();
            //var stderr = await install.StandardError.ReadToEndAsync();
        }
    }
}
