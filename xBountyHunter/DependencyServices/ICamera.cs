using System;
using System.Threading.Tasks;

namespace xBountyHunter.DependencyServices
{
    public interface ICamera
    {
        Task<string> takePhoto();
    }
}
