using System.Collections.Generic;
using ReactiveMarbles.PropertyChanged;
using System;
using System.ComponentModel;
using Tais.API;
using DynamicData;
using System.Reactive.Linq;
using System.Linq;

namespace Tais.Runtime
{
    public partial class Pop
    {
        private class TaxSource : IPopTaxSource
        {
#pragma warning disable 67
            public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

            public int baseValue
            {
                get
                {
                    return _baseValue;
                }
                set
                {
                    _baseValue = value;

                    this.value = CalcValue();
                }
            }

            public string label { get; private set; }

            public int value { get; private set; }

            private SourceCache<IEffect, object> effects = new SourceCache<IEffect, object>(x=>x.key);

            private IDisposable dispEffectSubscribe;

            private int _baseValue;

            public TaxSource(Pop pop)
            {
                this.label = pop.name;

                pop.WhenChanged(x => x.num).Subscribe(num => baseValue = num / 100);

                effects.Connect().Subscribe(changeds =>
                {
                    dispEffectSubscribe?.Dispose();
                    dispEffectSubscribe = effects.Connect().WhenValueChanged(x => x.value).Subscribe(_ => value = CalcValue());
                });
            }

            private int CalcValue()
            {
                return baseValue * (100 + effects.Items.Sum(x => x.value)) / 100;
            }

            public void AddOrUpdateEffect(IEffect effect)
            {
                effects.AddOrUpdate(effect);
            }
        }
    }
}