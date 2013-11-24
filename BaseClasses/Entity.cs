using System;

namespace BaseClasses {
	/*
	 * <summary>
	 * This class provides the base class for much of the game, allowing 
	 * objects of different types to be stored together, such as items and
	 * characters residing on a tile space.
	 * 
	 * Allows provides the name and description attribute for all game entities
	 * </summary>
	 */
	public abstract class Entity {
		/// <summary>
		/// The name of this entity
		/// </summary>
		/// <value>The name of this entity</value>
		public virtual string Name{ get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>A description of this entity.</value>
		public virtual string Description{ get; set; }
		/// <summary>
		/// Gets or sets the present location of this entity on the map.
		/// </summary>
		/// <value>The present location of the entity on the map.</value>
		public Levels.Tile PresentLocation{ get; set; }
		/// <summary>
		/// Move to the specified destination.
		/// </summary>
		/// <param name="destination">Where this entity will be located on the map after the move</param>
		public virtual void Move (Levels.Tile destination) {
			destination.Contents.Add (this);
			PresentLocation.Contents.Remove (this);
			PresentLocation = destination;
		}
		/// <summary>
		/// Pathfind towards a destination
		/// </summary>
		/// <param name="destination">The location that the entity will be closer to after the move</param>
		public virtual void MoveToward (Levels.Tile destination) {
			//pathfinding logic here
		}
	}
}

