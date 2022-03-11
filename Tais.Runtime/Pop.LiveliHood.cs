using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Pop
    {
        public class LiveliHood : ILiveliHood
        {

            public event PropertyChangedEventHandler PropertyChanged;

            public int value { get; private set; }

            public ISourceCache<IEffect, object> effects { get; } = new SourceCache<IEffect, object>(x=>x.from);

            public LiveliHood()
            {
                effects.Connect().Subscribe(_ =>
                {
                    value = effects.Items.Sum(x => x.value);
                });
            }

        }
    }
}