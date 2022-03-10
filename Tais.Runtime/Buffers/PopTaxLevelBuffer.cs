﻿using System;
using System.ComponentModel;
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
    }

}