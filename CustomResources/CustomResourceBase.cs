namespace Comformation.CustomResources
{
    public abstract class CustomResourceBase<T> : ResourceBase where T : ICustomResourceProperties
    {
        public virtual string Type => $"Custom::{GetType().Name}";

        public T Properties { get; set; }
    }
}
