using System;
using System.Collections.Generic;
using System.Text;
using Comformation.IntrinsicFunctions;

namespace Comformation
{
    // TODO: Move to Comformation
    public interface ICustomResourceProperties
    {
        Union<string, IntrinsicFunction> ServiceToken { get; set; }
    }

    public abstract class CustomResourceBase<T> : ResourceBase where T : ICustomResourceProperties
    {
        public virtual string Type => $"Custom::{GetType().Name}";

        public T Properties { get; set; }
    }
}
