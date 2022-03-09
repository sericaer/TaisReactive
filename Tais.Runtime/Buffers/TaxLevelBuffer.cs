using System;
using Tais.API;

namespace Tais.Runtime.Buffers
{
    public class TaxLevelBuffer : IDepartBuffer
    {
        public int? popTaxEffect { get; private set; }

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
                        popTaxEffect = -80;
                        break;
                    case DepartTaxLevel.Low:
                        popTaxEffect = -30;
                        break;
                    case DepartTaxLevel.Mid:
                        popTaxEffect = 00;
                        break;
                    case DepartTaxLevel.High:
                        popTaxEffect = +20;
                        break;
                    case DepartTaxLevel.VeryHigh:
                        popTaxEffect = +60;
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        private IDepart depart;

        private DepartTaxLevel _taxLevel;

        public TaxLevelBuffer(IDepart depart, DepartTaxLevel taxLevel)
        {
            this.depart = depart;
            this.taxLevel = taxLevel;
        }

        public void OnAdd()
        {
            foreach(var pop in depart.pops.Items)
            {
                pop.taxSource.AddOrUpdateEffect(new Effect(this, popTaxEffect.Value));
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
                pop.taxSource.AddOrUpdateEffect(new Effect(this, popTaxEffect.Value));
            }
        }
    }

}