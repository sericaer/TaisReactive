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
            public int value { get; private set; }

            public ISourceList<IEffect> effects { get; } = new SourceList<IEffect>();

            public LiveliHood()
            {
                effects.Connect().Subscribe(_ =>
                {
                    value = effects.Items.Sum(x => x.value);
                });
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}