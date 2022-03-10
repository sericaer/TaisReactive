﻿using DynamicData;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Tais.API;
using Tais.API.Def;
using Tais.Runtime.Buffers;

namespace Tais.Runtime
{
    public partial class Pop : IPop
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public string name => def.name;

        public int num { get; private set; }

        public IPopDef def { get; private set; }

        public IPopTaxSource taxSource => _taxSource;

        public IBufferManager buffMgr => _buffMgr;

        public ILiveliHood liveliHood => _liveliHood;

        private TaxSource _taxSource;

        private LiveliHood _liveliHood = new LiveliHood();
        private BufferManager _buffMgr;

        public Pop(IPopDef def, int num)
        {
            this.def = def;
            this.num = num;

            _taxSource = new TaxSource(this);
            _buffMgr = new BufferManager(this);

        }

        public void DayInc(IDate now)
        {
            num += 10;
        }

        public class LiveliHood : ILiveliHood
        {
            public int value { get; }
            public IObservableList<IEffect> effects => _effects;

            private SourceList<IEffect> _effects = new SourceList<IEffect>();
        }
    }
}