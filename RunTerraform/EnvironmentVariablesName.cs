using System;
using System.Collections.Generic;
using System.Text;

namespace RunTerraform
{
    public static class TerraformEnvironmentVariables
    {
        public const string TerraformVersion = "TF_VERSION";


    }

    public static class CfnEnvironmentVariables
    {
        public const string RequestType = "CFN_RequestType";
        public const string StackId = "CFN_StackId";
        public const string RequestId = "CFN_RequestId";
        public const string LogicalResourceId = "CFN_LogicalResourceId";
        public const string ResponseURL = "CFN_ResponseURL";
    }
}
