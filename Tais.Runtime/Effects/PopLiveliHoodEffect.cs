using DynamicData;
using Tais.API;

namespace Tais.Runtime.Effects
{
    internal class PopLiveliHoodEffect : IEffect
    {
        public object from { get; }

        public int value { get; }

        public string desc => $"PopLiveliHood {value.ToString("+0;-#")}";

        public PopLiveliHoodEffect(int effectValue, object from)
        {
            this.from = from;
            this.value = effectValue;
        }

        public void AddOrUpdate(object target)
        {
            var pop = target as IPop;

            pop.liveliHood.effects.AddOrUpdate(this);
        }
    }
}