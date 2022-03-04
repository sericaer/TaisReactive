using System;
using System.ComponentModel;
using Tais.API;

namespace Tais.Runtime
{
    public class Person : IPerson
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public string name { get ; private set; }

        public Person(string name)
        {
            this.name = name;
        }
    }
}
