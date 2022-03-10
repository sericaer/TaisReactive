using System.ComponentModel;

namespace Tais.API
{
    public interface IPopBuffer
    {
        int? taxEffect { get; }
        int? liveliHoodEffect { get; }
    }
}