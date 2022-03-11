using DynamicData;
using System;
using System.ComponentModel;
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

        public int num { get; private set; }

        public IPopDef def { get; private set; }

        public IPopTaxSource taxSource => _taxSource;

        public IBufferManager buffMgr { get; }

        public ILiveliHood liveliHood => _liveliHood;

        public int farmTotal { get; set; }

        public int farmAverage => farmTotal / num;

        private TaxSource _taxSource;

        private LiveliHood _liveliHood;

        private ISourceCache<IPopBuffer, IPopBuffer> buffers = new SourceCache<IPopBuffer, IPopBuffer>(x => x);

        public Pop(IPopDef def, int num, int farmAverage)
        {
            this.def = def;
            this.num = num;
            this.farmTotal = farmAverage * num;

            buffMgr = new BufferManager(this);

            _taxSource = new TaxSource(this);
            _liveliHood = new LiveliHood();
        }

        public void DayInc(IDate now)
        {
            num += 10;
        }
    }
}