using Comformation;
using Comformation.IntrinsicFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comformation.CustomResources.RunLambda
{
    public class StartCodeBuildProperties : ICustomResourceProperties
    {
        /// <summary>
        /// Service token (ARN) of lambda function that will start code build project
        /// </summary>
        public Union<string, IntrinsicFunction> ServiceToken { get; set; }

        /// <summary>
        /// CodeBuild Project ARN
        /// </summary>
        public Union<string, IntrinsicFunction> ProjectArn { get; set; }

        /// <summary>
        /// Environment variables that will be passed to CodeBuild Project
        /// </summary>
        public Dictionary<string, Union<string, IntrinsicFunction>> Environment { get; set; }
    }

    public class StartCodeBuildResource : CustomResourceBase<StartCodeBuildProperties>
    {
    }
}
