using System;
using System.Collections.Generic;
using System.Text;

namespace InheritnaceHW
{
    public class DVD
    {
        private double _SpeedRead = 120;
        private double _speedRead;
        private double _SpeedRecord = 100;
        private double _speedRecord;
        private double _singleSided = 47;
        private double _doubleSided = 9;
        public DVD()
        {
            SpeedRead = 120;
            SpeedRecord = 100;
            SingleSided = 47;
            DoubleSided = 9;
            Name = "DVD";
            Model = String.Format("{0}GB SpeedRecord.120", "{0}GB SpeedRead.100", SingleSided / 4.7, DoubleSided / 9);
        }
        public double SpeedRead
        {
            get { return _speedRead }
            set { _speedRead = value; }
        }
        public double SpeedRecord
        {
            get { return _speedRecord }
            set { _speedRecord = value; }
        }
        public double SingleSided
        {
            get { return _singleSided; }
            set { _singleSided = value; }
        }
        public double DoubleSided
        {
            get { return _doubleSided; }
            set { _doubleSided = value; }
        }

        public string Name { get; }
        public string Model { get; }

        public override void CopyDataToDevice(File[] files, out double timeSpend, out File[] remainingFiles)
        {
            double filesSize = 0;

            int i = 0;
            while (filesSize < DoubleSided)
                filesSize += files[i++].Size;

            timeSpend = filesSize / SpeedRead;
            SpeedRecord = SpeedRead - filesSize;

            remainingFiles = new File[files.Length - i];
            int j = 0;
            while (i < files.Length)
                remainingFiles[j++] = files[i];
        }
        public override string GetDeviceInfo()
        {
            return String.Format("{0}{1}\nSpeed - {2}\nStorage Value - {3}\nFree Space - {4}\n", Name, Model, SpeedRead, SpeedRecord, SingleSided, DoubleSided);
        }
        public override double GetFreeSpaceValue()
        {
            throw new NotImplementedException();
        }
        public override double GetStorageValue()
        {
            return DoubleSided;
        }
    }
}
