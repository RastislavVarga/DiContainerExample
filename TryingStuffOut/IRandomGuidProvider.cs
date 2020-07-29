using System;
using System.Collections.Generic;
using System.Text;

namespace TryingStuffOut
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }

    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}
