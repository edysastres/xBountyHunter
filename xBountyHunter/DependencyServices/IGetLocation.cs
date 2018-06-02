using System;
using System.Collections.Generic;

namespace xBountyHunter.DependencyServices
{
    public interface IGetLocation
    {
        Dictionary<string, string> getLocation();
        void activarGPS();
        void apagarGPS();
    }
}
