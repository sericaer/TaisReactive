using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tais.API;
using Tais.API.Def;
using ReactiveMarbles.PropertyChanged;

namespace Tais.Runtime
{
    public class PopManager : IPopManager
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int registerCount { get; private set; }

        public IObservableList<IPop> pops => _pops;

        private SourceList<IPop> _pops = new SourceList<IPop>();

        public PopManager()
        {
            
        }

        public void DayInc(IDate now)
        {
            foreach (var pop in pops.Items)
            {
                pop.DayInc(now);
            }
        }

        public IPop Create(IDepart depart, PopInit popInit)
        {
            var pop = new Pop(depart, popInit.pop, popInit.num, popInit.farmAverage);

            _pops.Add(pop);

            if(pop.isRegister)
            {
                pop.WhenChanged(x => x.num).Subscribe(_ => registerCount = pops.Items.Where(x => x.isRegister).Sum(x => x.num));
            }

            return pop;
        }
    }
}
