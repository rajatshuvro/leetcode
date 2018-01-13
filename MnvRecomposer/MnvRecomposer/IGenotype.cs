namespace MnvComposer
{
    public interface IGenotype
    {
        bool IsPhased { get; }
        short FirstAlleleIndex { get; }
        short SecondAlleleIndex { get; }
    }
}