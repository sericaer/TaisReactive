using DynamicData;
using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;
using Tais.API.Def;

namespace Tais.GModders.Effects
{
    class PopTaxEffectDef : IEffectDef
    {
        public int effectValue { get; private set; }

        public PopTaxEffectDef(int value)
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

                pop.taxSource.effects.AddOrUpdate(effect);
            };

            return effect;
        }
    }
}
