using Comformation.IntrinsicFunctions;

namespace Comformation.CustomResources
{
    public class StartCodeBuildProperties<TEnv> : ICustomResourceProperties
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
        public TEnv Environment { get; set; }
    }
}
