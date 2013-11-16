using System;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Defines an item has having some mass, and not being weightless.
	 * Items such as scrolls or jewelry will be treated as weightless.
	 * </summary>
	 */
	public class HasMass : IItemComponent
	{
		public double Mass{get; private set;}
		public HasMass(double mass){
			Mass=mass;
		}
	}
}

