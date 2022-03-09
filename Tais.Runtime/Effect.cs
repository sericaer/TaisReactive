using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime
{
    public class Effect : IEffect
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Effect(object key, int value)
        {
            this.key = key;
            this.value = value;
        }

        public object key { get; }
        public int value { get; set; }
    }

}