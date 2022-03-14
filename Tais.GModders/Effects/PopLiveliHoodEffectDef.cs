using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tais.API;
using Tais.API.Def;
using DynamicData;

namespace Tais.GModders.Effects
{
    public class Effect : IEffect
    {
        public object from { get; }

        public IEffectDef def { get; }

        public int value => def.effectValue;

        public string desc => def.GetType().Name;

        public Action<object> SetTarget { get; set; }

        public Effect(IEffectDef def, object from)
        {
            this.def = def;
            this.from = from;
        }
    }

    public class PopLiveliHoodEffectDef : IEffectDef
    {
        public int effectValue { get; private set; }

        public PopLiveliHoodEffectDef(int value)
        {
            effectValue = value;
        }

        public IEffect Generate(object from)
        {
            var effect = new Effect(this, from);
            effect.SetTarget = (target) =>
            {
                var pop = target as IPop;
                if (pop == null)
                {
                    throw new Exception();
                }

                pop.liveliHood.effects.AddOrUpdate(effect);
            };

            return effect;
        }
    }
}
