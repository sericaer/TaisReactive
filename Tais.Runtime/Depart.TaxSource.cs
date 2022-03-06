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

            public event PropertyChangedEventHandler PropertyChanged;

            public string label { get; private set; }

            public int value { get; private set; }

            private IDisposable dispSubscribeVale;
            public TaxSource(Depart depart)
            {
                this.label = depart.name;

                depart.pops.Connect().Subscribe(changes =>
                {
                    dispSubscribeVale?.Dispose();
                    dispSubscribeVale = depart.pops.Connect().WhenValueChanged(x => x.taxSource.value)
                                                .Subscribe(_ => value = depart.pops.Items.Sum(x => x.taxSource.value));
                });
            }
        }
    }
}