using System;
using System.Collections.Generic;
using System.Text;

namespace TryingStuffOut
{
    public class SomeService : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeService(IRandomGuidProvider randomGuidProvider)
        {
            this._randomGuidProvider = randomGuidProvider;
        }

        public void PrintSomething()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}
