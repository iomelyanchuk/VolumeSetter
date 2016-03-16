using System;
using System.Windows.Forms;

namespace VolumeSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            int level;
            if (args.Length < 1)
            {
                //MessageBox.Show("Usage: VolumeSetter <num>", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Environment.Exit(1);
                level = Properties.Settings.Default.DefaultVolume;
            }
            else
            {
                bool result = int.TryParse(args[0], out level);
                if (!result)
                {
                    MessageBox.Show("Volume level must be from 0 to 100", "Parameter error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
            }
            VolumeChanger volumeChanger = new VolumeChanger();
            volumeChanger.SetVolumeLevel(level);
        }
    }
}