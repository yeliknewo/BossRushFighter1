using UnityEngine;
using Characters;

namespace Characters.Boss
{
	public abstract class Boss<A, C> : Character<A, C> where C : Character<A, C>
	{

	}
}