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
#pragma warning disable 67
            public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

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