using DynamicData;
using System.Collections.Generic;

namespace Tais.API
{
    public interface IBufferManager : IEnumerable<IPopBuffer>
    {
        ISourceCache<IPopBuffer, IPopBuffer> buffers { get; }

        void Remove(IPopBuffer buffer);

        void AddOrUpdate(IPopBuffer buffer);
    }
}