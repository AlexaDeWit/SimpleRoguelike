using System;

namespace ItemComponents
{
	public class HasMass : IItemComponent
	{
		public double Mass{get; private set;}
		public HasMass(double mass){
			Mass=mass;
		}
	}
}

