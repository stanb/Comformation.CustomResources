using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using RunTerraform.StartCodeBuildLambda;
using Comformation.CustomResources;

namespace RunTerraform.StartCodeBuildLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task TestToUpperFunction()
        {
            var function = new Function();
            var context = new TestLambdaContext();
            var request = new CloudFormationEvent<RunTerraformRequest>
            {

            };

            await function.FunctionHandler(request, context);
        }
    }
}
