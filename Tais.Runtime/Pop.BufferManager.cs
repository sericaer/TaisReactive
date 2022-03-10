using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Tais.API;
using Tais.API.Def;
using Tais.Runtime.Buffers;

namespace Tais.Runtime
{
    public partial class Pop : IPop
    {

        class BufferManager : AbstractBufferManager
        {
            private Pop owner;

            public BufferManager(Pop pop)
            {
                owner = pop;
            }

            public override void OnAdded(IPopBuffer buffer)
            {
                if(buffer.taxEffect != null)
                {
                    owner.taxSource.effects.Add(new Effect(buffer, buffer.taxEffect.Value));
                }
            }

            public override void OnRemoved(IPopBuffer buffer)
            {
                throw new NotImplementedException();
            }

            public override void OnReplaced(IPopBuffer old, IPopBuffer curr)
            {
                if (old.taxEffect != null && curr.taxEffect != null)
                {
                    var oldEffect = owner.taxSource.effects.Items.Single(x => x.key == old);

                    owner.taxSource.effects.Replace(oldEffect, new Effect(curr, curr.taxEffect.Value));
                    return;
                }
            }
        }
    }
}