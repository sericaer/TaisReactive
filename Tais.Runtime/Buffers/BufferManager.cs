using DynamicData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tais.API;

namespace Tais.Runtime.Buffers
{
    class BufferManager : IBufferManager
    {
        public object owner;

        public ISourceCache<IPopBuffer, IPopBuffer> buffers { get; } =  new SourceCache<IPopBuffer, IPopBuffer>(x => x);

        public BufferManager(object owner)
        {
            this.owner = owner;
        }

        public void AddOrUpdate(IPopBuffer buffer)
        {
            buffers.AddOrUpdate(buffer);

            foreach (var effect in buffer.effects)
            {
                effect.AddOrUpdate(owner);
            }
        }

        public void Remove(IPopBuffer buffer)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IPopBuffer> GetEnumerator()
        {
            return buffers.Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return buffers.Items.GetEnumerator();
        }
    }
}
