using DynamicData;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Depart : IDepart
    {
        public string name { get; private set; }
        public ITaxSourcePerMonth taxSource { get; private set; }

        public IObservableList<IPop> pops => _pops;

        private SourceList<IPop> _pops = new SourceList<IPop>();

        public Depart(string name)
        {
            this.name = name;
            this.taxSource = new TaxSource(this);
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