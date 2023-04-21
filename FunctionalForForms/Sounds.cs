using System.Media;
using Tweaker_in_1.Properties;

namespace Tweaker_in_1
{
    internal class Sounds
    {
        internal static void PlaySound1()
        {
            if (Settings.Default.ProgramSounds)
                new SoundPlayer(Resources._1).Play();
        }
        internal static void PlaySound2()
        {
            if (Settings.Default.ProgramSounds)
                new SoundPlayer(Resources._2).Play();
        }
        internal static void PlaySound3()
        {
            if (Settings.Default.ProgramSounds)
                new SoundPlayer(Resources._3).Play();
        }
    }
}
