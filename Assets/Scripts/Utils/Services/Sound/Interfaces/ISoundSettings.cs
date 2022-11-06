using System.Collections.Generic;

namespace Utils.Services.Sound.Interfaces
{
    public interface ISoundSettings
    {
        IEnumerable<SoundSource> Sources
        {
            get;
        }
    }
}