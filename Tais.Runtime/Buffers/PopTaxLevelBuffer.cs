//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using Tais.API;
//using Tais.API.Def;
//using Tais.Runtime.Effects;

//namespace Tais.Runtime.Buffers
//{

//    public class PopTaxLevelBuffer : IPopBuffer
//    {
//        //public class TaxLevelDef
//        //{
//        //    public Dictionary<DepartTaxLevel, (int taxEffect, int liveliHoodEffect)> dict = new Dictionary<DepartTaxLevel, (int taxEffect, int liveliHoodEffect)>()
//        //    {
//        //        { DepartTaxLevel.VeryLow, (taxEffect:-80, liveliHoodEffect:-1)},
//        //        { DepartTaxLevel.Low, (taxEffect:-30, liveliHoodEffect:-5)},
//        //        { DepartTaxLevel.Mid, (taxEffect:00,  liveliHoodEffect:-15)},
//        //        { DepartTaxLevel.High, (taxEffect:20,  liveliHoodEffect:-35)},
//        //        { DepartTaxLevel.VeryHigh, (taxEffect:60,  liveliHoodEffect:-60)}
//        //    };
//        //}

//        public static ITaxLevelDef def { get; set; }

//        public DepartTaxLevel taxLevel
//        {
//            get
//            {
//                return _taxLevel;
//            }
//            set
//            {
//                _taxLevel = value;

//                effects = def.dict[_taxLevel].Select(p => EffectBuilder.Build(p.Key, p.Value, this));
//            }
//        }

//        public IPop owner { get; }

//        //private TaxLevelDef def = new TaxLevelDef();

//        public IEnumerable<IEffect> effects { get; private set; }

//        public string desc 
//        { 
//            get
//            {
//                return string.Join("\n", effects.Select(x => x.desc));
//            }
//        }

//        private DepartTaxLevel _taxLevel;


//        public PopTaxLevelBuffer(DepartTaxLevel taxLevel, IPop owner)
//        {
//            this.taxLevel = taxLevel;
//            this.owner = owner;
//        }

//        public override bool Equals(object obj)
//        {
//            if(obj is PopTaxLevelBuffer peer)
//            {
//                return peer.owner == owner;
//            }

//            return false;
//        }

//        public override int GetHashCode()
//        {
//            return owner.GetHashCode();
//        }
//    }

//}