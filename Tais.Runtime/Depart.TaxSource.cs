using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Depart
    {
        private class TaxSource : ITaxSourcePerMonth
        {

            public event PropertyChangedEventHandler PropertyChanged;

            public string label { get; private set; }

            public int value { get; private set; }


            public TaxSource(Depart depart)
            {
                this.label = depart.name;
                this.value = 10;
            }
        }
    }
}