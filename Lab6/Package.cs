using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
	class Package
	{
		public int ID;
		public string address;
		public string city;
		public string state;
		public int zip;
		public string arrive;
		public int stateIndex;


		public Package(int ID, string address, int zip, string city, string state, int stateIndex, string arrive)
		{
			this.ID = ID;
			this.address = address;
			this.zip = zip;
			this.city = city;
			this.state = state;
			this.arrive = arrive;
			this.stateIndex = stateIndex;
		}
	}
}
