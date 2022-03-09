using ReactiveMarbles.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tais.API;
using DynamicData;
using System.Reactive.Linq;
using System.Linq;

namespace Tais.Runtime
{
    public class TaxManager : ITaxManager
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int stock { get; set; }

        public int taxPerMonth { get; private set; }

        public IObservableList<ITaxSource> taxSourcesPerMonth { get; private set; }

        private SourceList<ITaxSource> _taxSourcesPerMonth = new SourceList<ITaxSource>();

        private IDisposable totalTaxSubscribe;
        public TaxManager(int stock)
        {
            this.stock = stock;

            taxSourcesPerMonth = _taxSourcesPerMonth.Connect().AsObservableList();

            taxSourcesPerMonth.Connect().Subscribe(changeds =>
            {
                totalTaxSubscribe?.Dispose();

                totalTaxSubscribe = taxSourcesPerMonth.Connect().WhenValueChanged(x => x.value).Subscribe(_ => taxPerMonth = taxSourcesPerMonth.Items.Sum(e=>e.value));
            });
        }

        public void DayInc(int year, int month, int day)
        {
            if(day == 30)
            {
                stock += taxPerMonth;
            }
        }

        public void AddTaxSourcePerMonth(IDepartTaxSource departTax)
        {
            _taxSourcesPerMonth.Add(departTax);
        }
    }
}