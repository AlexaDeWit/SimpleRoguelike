using System;

namespace BaseClasses
{
	public class Entity
	{
		public string Name{ get; set; }
		public string Description { get; set; }
		public override string ToString ()
		{
			return this.Name;
		}
	}
}

