using ReactiveMarbles.PropertyChanged;
using System;
using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime
{
    public partial class Pop
    {
        private class TaxSource : ITaxSource
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public string label { get; private set; }

            public int value { get; private set; }

            public TaxSource(Pop pop)
            {
                this.label = pop.name;

                pop.WhenChanged(x => x.num).Subscribe(num => value = num / 100);
            }



        }
    }
}