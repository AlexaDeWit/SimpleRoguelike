using System;

namespace ItemComponents
{
	/// <summary>
	/// Flags an item as being possible to destroy
	/// </summary>
	public interface IDestructible : IItemComponent
	{
		/// <summary>
		/// Gets a value indicating whether this <see cref="ItemComponents.IDestructible"/> destroy condition is met.
		/// </summary>
		/// <value><c>true</c> if destroy condition is met; otherwise, <c>false</c>.</value>
		bool DestroyConditionMet{ get;}
	}
}

