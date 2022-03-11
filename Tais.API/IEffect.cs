using System.ComponentModel;

namespace Tais.API
{
    public interface IEffect
    {
        object from { get; }

        int value { get; }

        void AddOrUpdate(object target);
    }
}
