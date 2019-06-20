using System;
using System.Collections.Generic;

namespace RunTerraform
{
    public class RunTerraformRequest
    {
        /// <summary>
        /// Logical name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Terraform version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Terraform module location
        /// </summary>
        public string FromModule { get; set; }

        /// <summary>
        /// Relative path to variables file
        /// </summary>
        public string VarFile { get; set; }

        /// <summary>
        /// Variables
        /// </summary>
        public IDictionary<string, string> Vars { get; set; }

        /// <summary>
        /// Terraform backend configuration
        /// </summary>
        public IBackend Backend { get; set; }

    }

    public interface IBackend
    {
        string Type { get; }
    }

    public class BackendS3 : IBackend
    {
        public string Type => "s3";
        public string Bucket { get; set; }
        public string Key { get; set; }
        public string Region { get; set; }
    }
}
