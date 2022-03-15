using DynamicData;
using DynamicData.Binding;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Tais.API;
using Tais.API.Def;
using Tais.Runtime.Buffers;

namespace Tais.Runtime
{
    public partial class Pop : IPop
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public string name => def.name;

        public IDepart depart { get; set; }

        public bool isRegister => def.isRegister;

        public int num { get; set; }

        public IPopDef def { get; private set; }

        public IPopTaxSource taxSource => _taxSource;

        public IBufferManager buffMgr { get; }

        public ILiveliHood liveliHood => _liveliHood;

        public int? farmTotal { get; set; }

        public int? farmAverage => farmTotal ?? farmTotal / num;

        public TaxLevel taxLevel { get; set; }

        private TaxSource _taxSource;

        private LiveliHood _liveliHood;

        private ISourceCache<IPopBuffer, IPopBuffer> buffers = new SourceCache<IPopBuffer, IPopBuffer>(x => x);


        public Pop(IDepart depart, IPopDef def, int num, int? farmAverage)
        {
            this.depart = depart;
            this.def = def;
            this.num = num;

            this.farmTotal = farmAverage?? farmAverage * num;

            buffMgr = new BufferManager(this);

            if(isRegister)
            {
                _taxSource = new TaxSource(this);

                _liveliHood = new LiveliHood();

                this.WhenValueChanged(x => x.taxLevel).Subscribe(level =>
                {
                    foreach (var effectDef in def.taxLevelEffect[level])
                    {
                        var effect = effectDef.Generate("POP_TAX_LEVEl");

                        effect.SetTarget(this);
                    }
                });

                if (farmAverage != null)
                {
                    this.WhenValueChanged(x => x.farmAverage).Subscribe(average =>
                    {
                        foreach (var effectDef in def.GetFarmAverageEffectLevel(average.Value))
                        {
                            var effect = effectDef.Generate("POP_FARM");

                            effect.SetTarget(this);
                        }
                    });
                }
            }

        }

        public void DayInc(IDate now)
        {
            if(def.CalcConvert != null)
            {
                var convert = def.CalcConvert(this);

                foreach (var elem in convert)
                {
                    var toPop = depart.pops.Items.Single(x => x.name == elem.to);

                    var changed = (int)(this.num * elem.thousandth / 1000);

                    this.num -= changed;
                    toPop.num += changed;
                }
            }

        }
    }
}