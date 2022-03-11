using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using Tais.API;
using Tais.Runtime.Buffers;

namespace Tais.Runtime
{
    public partial class Depart : IDepart
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public string name { get; private set; }

        public int popCount { get; private set; }

        public DepartTaxLevel taxLevel
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
                    pop.buffMgr.AddOrUpdate(new PopTaxLevelBuffer(_taxLevel, pop));

                    //var old = pop.buffMgr.SingleOrDefault(x => x is PopTaxLevelBuffer) as PopTaxLevelBuffer;

                    //if (old == null)
                    //{
                    //    pop.buffMgr.Add(buff);
                    //}
                    //else
                    //{
                    //    pop.buffMgr.Replace(old, buff);
                    //}
                }
            }
        }

        public IDepartTaxSource taxSource => _taxSource;

        public IObservableList<IPop> pops => _pops;

        public SourceList<IDepartBuffer> buffers = new SourceList<IDepartBuffer>();

        private SourceList<IPop> _pops = new SourceList<IPop>();

        private IDisposable dispPopCountSubScrible;

        private DepartTaxLevel _taxLevel;

        private TaxSource _taxSource;

        public Depart(string name)
        {
            this.name = name;
            this._taxSource = new TaxSource(this);

            pops.Connect().Subscribe(changeds =>
            {
                dispPopCountSubScrible?.Dispose();
                dispPopCountSubScrible = pops.Connect().WhenValueChanged(x=>x.num).Subscribe(_ => popCount = pops.Items.Sum(x => x.num));

                foreach(var popAdded in changeds.Where(x=>x.Reason == ListChangeReason.Add).Select(x=>x.Item.Current))
                {
                    popAdded.buffMgr.AddOrUpdate(new PopTaxLevelBuffer(_taxLevel, popAdded));
                }
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