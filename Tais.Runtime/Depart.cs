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

                var Buff = buffers.Items.SingleOrDefault(x => x is TaxLevelBuffer) as TaxLevelBuffer;
                if(Buff == null)
                {
                    buffers.Add(new TaxLevelBuffer(this, _taxLevel));
                }
                else
                {
                    Buff.ChangeLevel(_taxLevel);
                }
            }
        }

        public ITaxSourcePerMonth taxSource => _taxSource;

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
                    foreach (var buff in buffers.Items.Where(x => x.popTaxEffect != null))
                    {
                        popAdded.taxSource.AddOrUpdateEffect(new Effect(buff, buff.popTaxEffect.Value));
                    }
                }
            });

            buffers.Connect().Subscribe(changeds =>
            {
                foreach(var changed in changeds.Select(x=>x.Item))
                {
                    switch(changed.Reason)
                    {
                        case ListChangeReason.Add:
                            changed.Current.OnAdd();
                            break;
                        default:
                            throw new Exception();
                    }
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