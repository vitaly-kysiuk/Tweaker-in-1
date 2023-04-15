using System.Media;
using Tweaker_in_1.Properties;

namespace Tweaker_in_1
{
    internal class Sounds
    {
        internal static void PlaySound1()
        {
            if (Settings.Default.ProgramSounds)
                using (SoundPlayer sound1 = new SoundPlayer(Resources._1))
                    sound1.Play();
        }
        internal static void PlaySound2()
        {
            if (Settings.Default.ProgramSounds)
                using (SoundPlayer sound2 = new SoundPlayer(Resources._2))
                    sound2.Play();
        }
        internal static void PlaySound3()
        {
            if (Settings.Default.ProgramSounds)
                using (SoundPlayer sound3 = new SoundPlayer(Resources._3))
                    sound3.Play();
        }
    }
}
