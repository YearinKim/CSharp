using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Unit04
{
    public class Car:Notifier
    {
        private double speed;
        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public Color Coler { get; set; }
        public string Driver { get; set; }

    }
}
