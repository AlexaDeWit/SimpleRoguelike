using System;

namespace BaseClasses
{
	/*
	 * <summary>
	 * This class provides the base class for much of the game, allowing 
	 * objects of different types to be stored together, such as items and
	 * characters residing on a tile space.
	 * 
	 * Allows provides the name and description attribute for all game entities
	 * </summary>
	 */

	public abstract class Entity
	{
		public virtual string Name{get;set;}
		public virtual string Description{get;set;}


		public virtual void Move(Levels.Tile destination){
			destination.Contents.Add (this);
			PresentLocation.Contents.Remove (this);
			PresentLocation = destination;
		}
		/*note to self, learn pathfinding*/
		public virtual void MoveToward(Levels.Tile destination){
			//pathfinding logic here
		}
		public Levels.Tile PresentLocation{ get; set; }
	}
}

