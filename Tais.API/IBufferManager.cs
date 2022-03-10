using DynamicData;
using System.Collections.Generic;

namespace Tais.API
{
    public interface IBufferManager : IEnumerable<IPopBuffer>
    {
        IObservableList<IPopBuffer> buffers { get; }

        void Add(IPopBuffer buffer);
        void Remove(IPopBuffer buffer);
        void Replace(IPopBuffer old, IPopBuffer curr);
    }
}