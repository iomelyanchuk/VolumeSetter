using System;
using System.Windows.Forms;

namespace VolumeSetter
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                MessageBox.Show("Usage: VolumeSetter <num>", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
            else
            {
                int level;
                if (!int.TryParse(args[0], out level))
                {
                    MessageBox.Show("Volume level must be from 0 to 100", "Parameter error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                new VolumeChanger().SetVolumeLevel(level);
            }
        }
    }
}