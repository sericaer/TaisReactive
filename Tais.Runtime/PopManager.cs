using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tais.API;

namespace Tais.Runtime
{
    public class PopManager : IPopManager
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public IPop Create(string name, int count)
        {
            var pop = new Pop(name, count);

            _pops.Add(pop);

            return pop;
        }

        public void DayInc(IDate now)
        {
            foreach (var pop in pops.Items)
            {
                pop.DayInc(now);
            }
        }
    }
}
