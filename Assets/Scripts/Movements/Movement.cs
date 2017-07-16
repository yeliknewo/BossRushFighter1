using Characters;
using UnityEngine;
using Physics;

namespace Movements
{
	public class Movement<A, C> where C : Character<A, C>
	{
		public void MoveLeft(Character<A, C> character, PhysicsObject physics)
		{
			physics.SetVelocity(Vector3.left);
		}

		public void MoveRight(Character<A, C> character, PhysicsObject physics)
		{
			physics.SetVelocity(Vector3.right);
		}

		public void StandStill(Character<A, C> character, PhysicsObject physics)
		{
			physics.SetVelocityX(0);
		}
	}
}
