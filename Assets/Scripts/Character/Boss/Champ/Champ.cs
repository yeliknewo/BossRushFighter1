using System;
using Moves;

namespace Characters.Boss.Champ
{
	public class Champ : Boss<ChampAction, Champ>
	{
		protected override void DoMove(Move<ChampAction> move)
		{
			throw new NotImplementedException();
		}
	}
}