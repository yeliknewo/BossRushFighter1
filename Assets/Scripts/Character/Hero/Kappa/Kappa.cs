using Moves;
using Movements;

namespace Characters.Hero.Kappa
{
	public class Kappa : Hero<KappaAction, Kappa>
	{
		private void MoveLeft(Move<KappaAction> move)
		{
			Movement<KappaAction, Kappa> movement = GetMovement();

			movement.MoveLeft(this, GetPhysics());

			move.ActionDone();
		}

		private void MoveRight(Move<KappaAction> move)
		{
			Movement<KappaAction, Kappa> movement = GetMovement();

			movement.MoveRight(this, GetPhysics());

			move.ActionDone();
		}

		private void StandStill(Move<KappaAction> move)
		{
			Movement<KappaAction, Kappa> movement = GetMovement();

			movement.StandStill(this, GetPhysics());

			move.ActionDone();
		}

		protected override void DoMove(Move<KappaAction> move)
		{
			switch (move.GetAction())
			{
				case KappaAction.Stand:
					StandStill(move);
					break;

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