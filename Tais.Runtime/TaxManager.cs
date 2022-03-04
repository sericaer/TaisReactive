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

        public int stock { get; private set; }

        public int taxPerMonth { get; private set; }

        public IObservableList<ITaxSource> taxSourcesPerMonth { get; private set; }

        private SourceList<ITaxSource> _taxSourcesPerMonth = new SourceList<ITaxSource>();

        private IDisposable totalTaxSubscribe;
        public TaxManager()
        {
            stock = 100;

            taxSourcesPerMonth = _taxSourcesPerMonth.Connect().AsObservableList();

            taxSourcesPerMonth.Connect().Subscribe(changeds =>
            {
                totalTaxSubscribe?.Dispose();

                totalTaxSubscribe = taxSourcesPerMonth.Connect().WhenValueChanged(x => x.value).Subscribe(_ => taxPerMonth = taxSourcesPerMonth.Items.Sum(e=>e.value));
            });

            for(int i=0; i<3; i++)
            {
                AddDepartTax(new DepartTax($"DepartTax{i}", i*10));
            }
        }

        public void DayInc(int year, int month, int day)
        {
            if(day == 30)
            {
                stock += taxPerMonth;
            }

            if (day % 10 == 0)
            {
                foreach (var source in _taxSourcesPerMonth.Items)
                {
                    var tax = source as DepartTax;
                    tax.value++;
                }
            }

        }

        public void AddDepartTax(IDepartTax departTax)
        {
            _taxSourcesPerMonth.Add(departTax);
        }
    }

    internal class DepartTax : IDepartTax
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DepartTax(string name, int value)
        {
            this.label = name;
            this.value = value;
        }

        public int value { get; set; }

        public string label { get; set; }

    }
}