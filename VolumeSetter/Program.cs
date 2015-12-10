using System;
using System.Windows.Forms;

namespace VolumeSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                MessageBox.Show("Usage: VolumeSetter <num>", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
            int level;
            bool result = int.TryParse(args[0], out level);
            if (!result || level < 0 || level > 100)
            {
                MessageBox.Show("Volume level must be from 0 to 100", "Parameter error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            VolumeChanger volumeChanger = new VolumeChanger();
            volumeChanger.SetVolumeLevel(level);
        }
    }
}