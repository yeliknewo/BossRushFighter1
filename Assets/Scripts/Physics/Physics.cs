using UnityEngine;

namespace Physics
{
	public class PhysicsObject : MonoBehaviour
	{
		[SerializeField]
		private Vector3 velocity;

		[SerializeField]
		private bool onGround;

		[SerializeField]
		private Vector3 gravity;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			HandleCollision(collision);
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			HandleCollision(collision);
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			onGround = false;
		}

		private void Update()
		{
			transform.position += velocity * Time.deltaTime;

			if (!onGround)
			{
				velocity += gravity * Time.deltaTime;
			}
		}

		public void SetGravity(Vector3 newGravity)
		{
			gravity = newGravity;
		}

		public void SetVelocity(Vector3 newVelocity)
		{
			velocity = newVelocity;
		}

		public void SetVelocityX(float x)
		{
			velocity.x = x;
		}

		public void SetVelocityY(float y)
		{
			velocity.y = y;
		}

		private void HandleCollision(Collision2D collision)
		{
			foreach (ContactPoint2D point in collision.contacts)
			{
				velocity = Vector3.zero;
				Vector3 delta = new Vector3(point.normal.x, point.normal.y) * -point.separation;
				onGround = Vector3.Dot(gravity, delta) <= 0;
				transform.position += delta;
			}
		}
	}
}