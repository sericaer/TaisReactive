using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Depart
    {
        private class TaxSource : ITaxSourcePerMonth
        {

#pragma warning disable 67
            public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

            public string label => _depart.name;

            public int value { get; private set; }

            private IDisposable dispSubscribeVale;


            private IDepart _depart;

            public TaxSource(Depart depart)
            {
                this._depart = depart;

                _depart.pops.Connect().Subscribe(changes =>
                {
                    dispSubscribeVale?.Dispose();
                    dispSubscribeVale = depart.pops.Connect().WhenValueChanged(x => x.taxSource.value)
                                                .Subscribe(_ => value = depart.pops.Items.Sum(x => x.taxSource.value));
                });
            }

            public void AddOrUpdateEffect(IEffect effect)
            {
                throw new NotImplementedException();
            }
        }
    }
}