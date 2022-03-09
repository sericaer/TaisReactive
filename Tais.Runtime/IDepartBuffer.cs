namespace Tais.Runtime
{
    public interface IDepartBuffer
    {
        int? popTaxEffect { get; }

        void OnAdd();
    }

}