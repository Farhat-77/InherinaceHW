using System;
using System.Collections.Generic;
using System.Text;

namespace InheritnaceHW
{
    public class HDD
    {
        private double _speedUsb20;
        private double _volumeSection;
        private double _quantitySection;
        public HDD()
        {
            SpeedUsb20 = 500;
            volumeSection = 10000;
            volumeSection = (int)_quantitySection;
            Name = "HDD";
            Model = String.Format("{0}GB USB2.0", _volumeSection / 10000);
        }
        public double SpeedUsb20
        {
            get { return _speedUsb20; }
            set { _speedUsb20 = value; }
        }
        private int volumeSection;

        public string Name { get; }
        public string Model { get; }

        public double VolumeSection
        {
            get { return _volumeSection; }
            set { _volumeSection = value; }
        }
        public double FreeSpace
        {
            get { return _quantitySection; }
            set { _quantitySection = value; }
        }
        public override void CopyDataToDevice(File[] files, out double timeSpend, out File[] remainingFiles)
        {
            double filesSize = 0;

            int i = 0;
            while (filesSize < VolumeSection)
                filesSize += files[i++].Size;

            timeSpend = filesSize / SpeedUsb20;
            FreeSpace = VolumeSection - filesSize;

            remainingFiles = new File[files.Length - i];
            int j = 0;
            while (i < files.Length)
                remainingFiles[j++] = files[i];
        }
        public override string GetDeviceInfo()
        {
            return String.Format("{0}{1}\nSpeed - {2}\nStorage Value - {3}\nFree Space - {4}\n", Name, Model, SpeedUsb20, VolumeSection, _quantitySection);
        }
        public override double GetFreeSpaceValue()
        {
            throw new NotImplementedException();
        }
        public override double GetStorageValue()
        {
            return VolumeSection;
        }
    }
}

