using UnityEngine;
using Moves;
using Movements;

namespace Characters.Hero.Kappa
{
	public class Kappa : Hero<KappaAction, Kappa>
	{
		private void MoveLeft(Move<KappaAction> move)
		{
			//Rigidbody2D rb = GetComponent<Rigidbody2D>();

			//rb.AddForce(Vector2.left * 100, ForceMode2D.Force);

			Movement<KappaAction, Kappa> movement = GetMovement();

			movement.MoveLeft(this);

			move.ActionDone();
		}

		private void MoveRight(Move<KappaAction> move)
		{
			//Rigidbody2D rb = GetComponent<Rigidbody2D>();

			//rb.AddForce(Vector2.right * 100, ForceMode2D.Force);

			Movement<KappaAction, Kappa> movement = GetMovement();
			movement.MoveRight(this);

			move.ActionDone();
		}

		protected override void DoMove(Move<KappaAction> move)
		{
			switch (move.GetAction())
			{
				case KappaAction.Left:
					MoveLeft(move);
					break;

				case KappaAction.Right:
					MoveRight(move);
					break;
			}
		}
	}
}