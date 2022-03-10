using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais.API
{
    public interface ITaxSource : INotifyPropertyChanged
    {
        string label { get; }
        int value { get; }
    }

    public interface IDepartTaxSource : ITaxSource
    {
        IObservableList<ITaxSource> subSources { get; }
    }

    public interface IPopTaxSource : ITaxSource
    {
        ISourceList<IEffect> effects { get; }

        void AddEffect(IEffect effect);
        void RemoveEffect();

        void ReplaceEffect(IEffect old, IEffect curr);
    }
}
