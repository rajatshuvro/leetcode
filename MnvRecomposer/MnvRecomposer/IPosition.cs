using System.Collections;
using System.Collections.Generic;

namespace MnvComposer
{
    public interface IPosition
    {
        uint Start { get; }
        string RefAllele { get; }
        string[] AltAlleles { get; }

        IList<IGenotype> Genotypes { get; }
    }
}