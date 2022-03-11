using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tais.API;
using Tais.API.Def;

namespace Tais.Runtime
{
    public class PopManager : IPopManager
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int totalCount { get; private set; }

        public IObservableList<IPop> pops => _pops;

        private SourceList<IPop> _pops = new SourceList<IPop>();

        private IDisposable dispTotalCountSubscribe;

        public PopManager()
        {
            pops.Connect().Subscribe(changes =>
            {
                dispTotalCountSubscribe?.Dispose();

                dispTotalCountSubscribe = pops.Connect().WhenValueChanged(x => x.num).Subscribe(_=> totalCount = pops.Items.Sum(x => x.num));
            });
        }

        public void DayInc(IDate now)
        {
            foreach (var pop in pops.Items)
            {
                pop.DayInc(now);
            }
        }

        public IPop Create(PopInit popInit)
        {
            var pop = new Pop(popInit.pop, popInit.num, popInit.farmAverage);

            _pops.Add(pop);

            return pop;
        }
    }
}
