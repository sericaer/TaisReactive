using System;
using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime.Buffers
{

    public class PopTaxLevelBuffer : IPopBuffer
    {
        public int? taxEffect { get; private set; }

        public int? liveliHoodEffect { get; private set; }

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
                        liveliHoodEffect = -1;
                        break;
                    case DepartTaxLevel.Low:
                        taxEffect = -30;
                        liveliHoodEffect = -5;
                        break;
                    case DepartTaxLevel.Mid:
                        taxEffect = 00;
                        liveliHoodEffect = -15;
                        break;
                    case DepartTaxLevel.High:
                        taxEffect = +20;
                        liveliHoodEffect = -35;
                        break;
                    case DepartTaxLevel.VeryHigh:
                        taxEffect = +60;
                        liveliHoodEffect = -60;
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
    }

}