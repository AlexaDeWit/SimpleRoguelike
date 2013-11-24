using System;

namespace Characters
{
	/// <summary>
	/// A race, ie humans/orcs/etc, and its associated base attributes
	/// </summary>
	public class Race
	{
		/// <summary>
		/// The name of the Race
		/// </summary>
		public string Name{ get; private set; }
		/// <summary>
		/// A description of the Race
		/// </summary>
		public string Description{get; private set;}
		/// <summary>
		/// Gets the base strenth.
		/// </summary>
		/// <value>The base strenth of the race.</value>
		public int BaseStrenth{ get;private set; }
		/// <summary>
		/// Gets the base agility.
		/// </summary>
		/// <value>The base agility of the race.</value>
		public int BaseAgility{ get;private set; }
		/// <summary>
		/// Gets the base endurance.
		/// </summary>
		/// <value>The base endurance of the race.</value>
		public int BaseEndurance{ get;private set; }
		/// <summary>
		/// Gets the base intelligence.
		/// </summary>
		/// <value>The base intelligence of the race.</value>
		public int BaseIntelligence{ get;private set; }
		/// <summary>
		/// Gets the base charisma.
		/// </summary>
		/// <value>The base charisma of the race.</value>
		public int BaseCharisma{ get;private set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="Characters.Race"/> class.
		/// </summary>
		/// <param name="name">The name of the Race</param>
		/// <param name="description">A description of the Race</param>
		/// <param name="strength">The base strength of the race.</param>
		/// <param name="agility">The base agility of the race.</param>
		/// <param name="endurance">The base endurance of the race.</param>
		/// <param name="intelligence">The base intelligence of the race.</param>
		/// <param name="charisma">The base charism of the race.</param>
		public Race(string name, string description,int strength, int agility, int endurance, int intelligence, int charisma){
			Name = name;
			Description = description;
			BaseStrenth=strength;
			BaseAgility=agility;
			BaseEndurance=endurance;
			BaseIntelligence=intelligence;
			BaseCharisma=charisma;
		}

	}
}

