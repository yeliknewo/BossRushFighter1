using System;
using UnityEngine;

namespace Character
{
	public abstract class BossBuilder<T, C> : CharacterBuilder<T> where T : BossBuilder<T, C>
		where C : Boss
	{

		protected override T AddStats()
		{
			Boss boss = GetObj().GetComponent<C>();
			boss.Init();
			boss.SetBaseStat(StatType.Health, new Stat(GetHealthCurrentStarting(), GetHealthMaxStarting()));

			return (T)this;
		}

		protected abstract float GetHealthCurrentStarting();
		protected abstract float GetHealthMaxStarting();
	}
}