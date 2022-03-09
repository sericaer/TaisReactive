using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Depart
    {
        private class TaxSource : IDepartTaxSource
        {

#pragma warning disable 67
            public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

            public string label => _depart.name;

            public int value { get; private set; }

            public IObservableList<ITaxSource> subSources { get; }

            private IDisposable dispSubscribeVale;

            private IDepart _depart;

            public TaxSource(Depart depart)
            {
                this._depart = depart;

                subSources = depart.pops.Connect().Transform<IPop, ITaxSource>(x => x.taxSource).AsObservableList();

                subSources.Connect().Subscribe(changes =>
                {
                    dispSubscribeVale?.Dispose();
                    dispSubscribeVale = subSources.Connect().WhenValueChanged(x => x.value)
                                                .Subscribe(_ => value = subSources.Items.Sum(x => x.value));
                });
            }
        }
    }
}