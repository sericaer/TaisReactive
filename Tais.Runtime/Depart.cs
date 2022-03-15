using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using Tais.API;
using Tais.Runtime.Buffers;
using ReactiveMarbles.PropertyChanged;
using System.Collections.Generic;

namespace Tais.Runtime
{
    public partial class Depart : IDepart
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public string name { get; private set; }

        public int popCount { get; private set; }

        public TaxLevel taxLevel
        {
            get
            {
                return _taxLevel;
            }
            set
            {
                _taxLevel = value;

                foreach(var pop in pops.Items)
                {
                    pop.taxLevel = _taxLevel;
                }
            }
        }

        public IDepartTaxSource taxSource => _taxSource;

        public IObservableList<IPop> pops { get; set; }

        public int farmTotal { get; private set; }

        public SourceList<IDepartBuffer> buffers = new SourceList<IDepartBuffer>();

        private Dictionary<object, IDisposable> dictIDisposable = new Dictionary<object, IDisposable>();

        private TaxLevel _taxLevel;

        private TaxSource _taxSource;

        public Depart(string name, IObservableList<IPop> pops)
        {
            this.name = name;
            this.pops = pops;
            this._taxSource = new TaxSource(this);

            pops.Connect().OnItemAdded(OnPopAdd).Subscribe();
            pops.Connect().OnItemRemoved(OnPopRemove).Subscribe();
        }

        private void OnPopAdd(IPop pop)
        {
            pop.taxLevel = _taxLevel;

            if(pop.isRegister)
            {
                var disp = pop.WhenChanged(x => x.num).Subscribe(_=>
                {
                    popCount = pops.Items.Where(x => x.isRegister).Sum(x => x.num);
                });

                dictIDisposable.Add(pop, disp);
            }
        }

        private void OnPopRemove(IPop pop)
        {
            if(dictIDisposable.ContainsKey(pop))
            {
                dictIDisposable[pop].Dispose();
                dictIDisposable.Remove(pop);
            }
        }

        public void DayInc()
        {

        }
    }

}