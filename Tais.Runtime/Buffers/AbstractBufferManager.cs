using DynamicData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tais.API;

namespace Tais.Runtime.Buffers
{
    abstract class AbstractBufferManager : IBufferManager
    {
        public IObservableList<IPopBuffer> buffers => _buffers;

        public abstract void OnAdded(IPopBuffer buffer);
        public abstract void OnRemoved(IPopBuffer buffer);
        public abstract void OnReplaced(IPopBuffer old, IPopBuffer curr);

        private SourceList<IPopBuffer> _buffers = new SourceList<IPopBuffer>();

        public void Add(IPopBuffer buffer)
        {
            _buffers.Add(buffer);

            OnAdded(buffer);
        }

        public void Remove(IPopBuffer buffer)
        {
            _buffers.Remove(buffer);
            OnRemoved(buffer);
        }

        public void Replace(IPopBuffer old, IPopBuffer curr)
        {
            _buffers.Replace(old, curr);
            OnReplaced(old, curr);
        }

        public IEnumerator<IPopBuffer> GetEnumerator()
        {
            return _buffers.Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _buffers.Items.GetEnumerator();
        }
    }
}
