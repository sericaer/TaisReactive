using DynamicData;
using Tais.API;

namespace Tais.Runtime.Effects
{
    class PopTaxEffect : IEffect
    {
        public object from { get; }

        public int value { get; }

        public PopTaxEffect(int effectValue, object from)
        {
            this.from = from;
            this.value = effectValue;
        }

        public void AddOrUpdate(object target)
        {
            var pop = target as IPop;

            pop.taxSource.effects.AddOrUpdate(this);
        }
    }
}
