using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Pop : IPop
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }

        public int num { get; private set; }

        public ITaxSource taxSource => _taxSource;

        private TaxSource _taxSource;

        public Pop(string name, int num)
        {
            this.name = name;
            this.num = num;

            _taxSource = new TaxSource(this);
        }

    }
}