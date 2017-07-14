using System;
using UnityEngine;
using Stats;

namespace Characters.Boss
{
	public abstract class BossBuilder<T, C, A> : CharacterBuilder<T> where T : BossBuilder<T, C, A>
		where C : Boss<A, C>
	{

		protected override T AddStats()
		{
			Boss<A, C> boss = GetObj().GetComponent<C>();

			boss.InitStats();

			boss.SetBaseStat(StatType.Health, new Stat(GetHealthCurrentStarting(), GetHealthMaxStarting()));

			return (T)this;
		}

		protected abstract float GetHealthCurrentStarting();
		protected abstract float GetHealthMaxStarting();
	}
}