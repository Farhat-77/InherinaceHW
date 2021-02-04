using System;
using System.Collections.Generic;
using System.Text;

namespace InheritnaceHW
{
    public class File
    {
        private double _size;
        public File()
        {
            Size = 780;
        }
        public File(double size)
        {
            Size = size;
        }
        public double Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}
