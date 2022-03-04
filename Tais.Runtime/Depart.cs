using Tais.API;

namespace Tais.Runtime
{
    public partial class Depart : IDepart
    {
        public string name { get; private set; }
        public ITaxSourcePerMonth taxSource { get; private set; }

        public Depart(string name)
        {
            this.name = name;
            this.taxSource = new TaxSource(this);
        }
    }
}