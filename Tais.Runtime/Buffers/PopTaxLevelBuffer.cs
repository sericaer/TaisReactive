using System;
using Tais.API;

namespace Tais.Runtime.Buffers
{
    public class PopTaxLevelBuffer : IPopBuffer
    {
        public int? taxEffect { get; private set; }

        public DepartTaxLevel taxLevel
        {
            get
            {
                return _taxLevel;
            }
            set
            {
                _taxLevel = value;
                switch(_taxLevel)
                {
                    case DepartTaxLevel.VeryLow:
                        taxEffect = -80;
                        break;
                    case DepartTaxLevel.Low:
                        taxEffect = -30;
                        break;
                    case DepartTaxLevel.Mid:
                        taxEffect = 00;
                        break;
                    case DepartTaxLevel.High:
                        taxEffect = +20;
                        break;
                    case DepartTaxLevel.VeryHigh:
                        taxEffect = +60;
                        break;
                    default:
                        throw new Exception();
                }
            }
        }


        private DepartTaxLevel _taxLevel;

        public PopTaxLevelBuffer(DepartTaxLevel taxLevel)
        {
            this.taxLevel = taxLevel;
        }

        public void OnAdd()
        {
            foreach(var pop in depart.pops.Items)
            {
                pop.taxSource.AddOrUpdateEffect(new Effect(this, taxEffect.Value));
            }
        }

        public void OnRemove()
        {
            throw new Exception();
        }

        public void ChangeLevel(DepartTaxLevel taxLevel)
        {
            this.taxLevel = taxLevel;

            foreach (var pop in depart.pops.Items)
            {
                pop.taxSource.AddOrUpdateEffect(new Effect(this, taxEffect.Value));
            }
        }
    }

}