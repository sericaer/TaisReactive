using DynamicData;
using System;
using System.ComponentModel;
using Tais.API;
using Tais.API.Def;

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

        public ILiveliHood liveliHood { get; }

        public ISourceList<IPopBuffer> buffers { get; }

        private TaxSource _taxSource;

        public Pop(IPopDef def, int num)
        {
            this.def = def;
            this.num = num;
            
            buffers = new SourceList<IPopBuffer>();

            _taxSource = new TaxSource(this);

            buffers.Connect().Subscribe(changeds =>
            {
                buffers.Connect().WhenPropertyChanged(x => x.taxEffect).Subscribe();
            });
        }

        public void DayInc(IDate now)
        {
            num += 10;
        }
    }
}