using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Composite2
{
    public class ArtefactContainer
    {
        public List<Artefact> Artefacts { get; private set; } = new List<Artefact>();

        public void AddArtefact(Artefact artefact)
        {
            Artefacts.Add(artefact);
        }

        public void RemoveArtefact(Artefact artefact)
        {
            Artefacts.Remove(artefact);
        }

        public int GetTotalCount()
        {
            return Artefacts.Sum(a => a.GetCount());
        }
    }
}
