using Comformation;
using Comformation.IntrinsicFunctions;
using RunTerraform;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comformation.CustomResources.RunLambda
{
    public class CodeBuildRunTerraformResource : CustomResourceBase<StartCodeBuildProperties<RunTerraformRequest>>
    {
    }
}
