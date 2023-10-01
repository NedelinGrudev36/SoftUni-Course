using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Engine_and_Tires
{
    class Tire
    {
		private int year;

		public int Year
		{
			get { return year; }
			set { year = value; }
		}

		private double pressure;

		public double Pressure
		{
			get { return pressure; }
			set { pressure = value; }
		}
		
		public Tire(int year,double pressure)
		{
			this.Year = year;
			this.Pressure = pressure;
		}

	}
}
