using UnityEngine;

namespace Characters.Hero
{
	public abstract class Hero<A, C> : Character<A, C> where C : Character<A, C>
	{

	}
}