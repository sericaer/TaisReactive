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

        private TaxSource _taxSource;

        public Pop(IPopDef def, int num)
        {
            this.def = def;
            this.num = num;

            _taxSource = new TaxSource(this);
        }

        public void DayInc(IDate now)
        {
            num += 10;
        }
    }
}