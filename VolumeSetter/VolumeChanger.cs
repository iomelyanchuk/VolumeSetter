using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace VolumeSetter
{
    class VolumeChanger
    {
        private MMDevice _audioDevice;
        private bool _isInit;

        /// <summary>
        /// Инициализация основного аудио устройства
        /// </summary>
        private void InitDevice()
        {
            if (_isInit) return;
            try
            {
                var devEnum = new MMDeviceEnumerator();
                _audioDevice = devEnum.GetDefaultAudioEndpoint(0, (Role) 1);
                _isInit = true;
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
            if (!_isInit) return;
            if (level < 0 || level > 100)
            {
                MessageBox.Show("Volume level must be from 0 to 100", "Parameter error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        /// <summary>
        /// Получение уровня звука
        /// </summary>
        /// <returns>уровень звука от 0 до 100</returns>
        public int GetVolumeLevel()
        {
            if (!_isInit) return -1;
            try
            {
                return (int) (_audioDevice.AudioEndpointVolume.MasterVolumeLevelScalar*100.0f);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public VolumeChanger()
        {
            InitDevice();
        }
    }
}
