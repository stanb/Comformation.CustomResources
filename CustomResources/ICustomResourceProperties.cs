using Comformation.IntrinsicFunctions;

namespace Comformation.CustomResources
{
    // TODO: Move to Comformation
    public interface ICustomResourceProperties
    {
        Union<string, IntrinsicFunction> ServiceToken { get; set; }
    }

}
