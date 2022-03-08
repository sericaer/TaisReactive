using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Depart : IDepart
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public string name { get; private set; }

        public int popCount { get; private set; }

        public ITaxSourcePerMonth taxSource { get; private set; }

        public IObservableList<IPop> pops => _pops;

        private SourceList<IPop> _pops = new SourceList<IPop>();

        private IDisposable dispPopCountSubScrible;
        public Depart(string name)
        {
            this.name = name;
            this.taxSource = new TaxSource(this);

            pops.Connect().Subscribe(changed =>
            {
                dispPopCountSubScrible?.Dispose();
                dispPopCountSubScrible = pops.Connect().WhenValueChanged(x=>x.num).Subscribe(_ => popCount = pops.Items.Sum(x => x.num));
            });
        }

        public void AddPop(IPop pop)
        {
            _pops.Add(pop);
        }

        public void DayInc()
        {

        }
    }
}