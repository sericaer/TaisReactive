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
#pragma warning disable 0067 // No "Never used" warning
            public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067

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