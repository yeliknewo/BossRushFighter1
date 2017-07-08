using System;
using UnityEngine;

namespace Character
{
	public abstract class HeroBuilder<T, C> : CharacterBuilder<T> where T : HeroBuilder<T, C>
		where C : Hero
	{
		protected override T AddStats()
		{
			Hero hero = GetObj().GetComponent<C>();
			hero.Init();
			hero.SetBaseStat(StatType.Health, new Stat(GetHealthCurrentStarting(), GetHealthMaxStarting()));

			return (T)this;
		}

		protected abstract float GetHealthCurrentStarting();
		protected abstract float GetHealthMaxStarting();
	}
}