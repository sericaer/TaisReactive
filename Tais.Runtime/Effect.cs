using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime
{
    public class Effect : IEffect
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public Effect(object key, int value)
        {
            this.key = key;
            this.value = value;
        }

        public object key { get; }
        public int value { get; set; }
    }

}