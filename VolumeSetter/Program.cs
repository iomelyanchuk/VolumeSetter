using NAudio.CoreAudioApi;

namespace VolumeSetter
{
    class Program
    {
        static void Main()
        {
            const int level50 = 50;
            SetVolumeLevel(level50);
        }

        private static void SetVolumeLevel(int value)
        {
            try
            {
                var devEnum = new MMDeviceEnumerator();
                MMDevice device = devEnum.GetDefaultAudioEndpoint(0, (Role) 1);

                device.AudioEndpointVolume.MasterVolumeLevelScalar = value/100.0f;
            }
            catch
            {
                // ignored
            }
        }
    }
}