using System;
using System.Collections.Generic;

namespace Characters
{
	/*
	 * <summary>
	 * Represents a set of food types that are edible, to a certain entity.
	 * </summary>
	 */
	public class Diet
	{
		List<Items.Food> EdibleFoods;
		public Diet (List<Items.Food> foods)
		{
			EdibleFoods=foods;
		}
	}
	
}

