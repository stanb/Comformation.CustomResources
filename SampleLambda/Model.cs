using System;
using System.Collections.Generic;
using System.Text;

namespace Comformation.CustomResources.SampleLambda
{
    public class StartCodeBuild
    {
        public string ProjectArn { get; set; }
        public IDictionary<string, string> Environment { get; set; }
    }
}
