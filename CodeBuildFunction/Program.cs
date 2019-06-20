using Comformation.CustomResources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBuildFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface ICustomResourceCodeBuildProcess<TRequest, TResponse>
    {
        Task<CloudFormationResponse<TResponse>> Create(CloudFormationEvent<TRequest> request);
        Task<CloudFormationResponse<TResponse>> Update(CloudFormationEvent<TRequest> request);
        Task<CloudFormationResponse<TResponse>> Delete(CloudFormationEvent<TRequest> request);
    }
}
