using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevelar;
       
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get { return oxygenLevelar; }
            private set 
            { 
                oxygenLevelar = value;
            }
        }

        public IReadOnlyCollection<string> Catch => throw new NotImplementedException();

        public double CompetitionPoints => throw new NotImplementedException();

        public bool HasHealthIssues => throw new NotImplementedException();

        public void Hit(IFish fish)
        {
            throw new NotImplementedException();
        }

        public void Miss(int TimeToCatch)
        {
            throw new NotImplementedException();
        }

        public void RenewOxy()
        {
            throw new NotImplementedException();
        }

        public void UpdateHealthStatus()
        {
            throw new NotImplementedException();
        }
    }
}
