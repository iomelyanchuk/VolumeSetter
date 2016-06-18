using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace VolumeSetter
{
    class VolumeChanger
    {
        private MMDevice _audioDevice;

        /// <summary>
        /// Инициализация основного аудио устройства
        /// </summary>
        private void InitDevice()
        {
            try
            {
                var devEnum = new MMDeviceEnumerator();
                _audioDevice = devEnum.GetDefaultAudioEndpoint(0, (Role) 1);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установка уровня звука
        /// </summary>
        /// <param name="level">уровень звука от 0 до 100</param>
        public void SetVolumeLevel(int level)
        {
            if (_audioDevice == null)
            {
                MessageBox.Show("Can't get audiodevice", "Error", MessageBoxButtons.OK);
                return;
            }
            if (level < 0 || level > 100)
            {
                MessageBox.Show("Volume level must be from 0 to 100", "Parameter error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _audioDevice.AudioEndpointVolume.MasterVolumeLevelScalar = level / 100.0f;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public VolumeChanger()
        {
            InitDevice();
        }
    }
}
