using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Composite2
{
    public class MarvelHero
    {
        public string Name { get; private set; }
        private int _power;
        public ArtefactContainer artefacts { get; private set; } = new ArtefactContainer();
        public List<MarvelHero> friends { get; private set; } = new List<MarvelHero>();

        public MarvelHero(string name, int power)
        {
            this.Name = name;
            this._power = power;
        }

        public void AddFriend(MarvelHero friend)
        {
            friends.Add(friend);
        }

        public void Strike()
        {
            int totalPower = artefacts.Artefacts.Aggregate(this._power, (sum, next) => sum += next.GetPowerBuf());
            Console.WriteLine($"{this.Name} hits with power {totalPower}");
        }

        public void CalculateArtefactsWeight()
        {
            int totalArtefactsWeight = artefacts.Artefacts.Aggregate(0, (sum, next) => sum += next.GetWeight());
            Console.WriteLine($"Total artefacts weight: {totalArtefactsWeight}");
        }

        public void CountArtefacts()
        {
            int totalArtefactCount = artefacts.GetTotalCount();
            Console.WriteLine($"{this.Name} has {totalArtefactCount} artefacts");
        }
    }
}
