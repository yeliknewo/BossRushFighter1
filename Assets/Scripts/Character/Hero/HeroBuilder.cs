using Stats;

namespace Characters.Hero
{
	public abstract class HeroBuilder<T, C, A> : CharacterBuilder<T> where T : HeroBuilder<T, C, A>
		where C : Hero<A, C>
	{
		protected override T AddStats()
		{
			Hero<A, C> hero = GetObj().GetComponent<C>();

			hero.InitStats();

			hero.SetBaseStat(StatType.Health, new Stat(GetHealthCurrentStarting(), GetHealthMaxStarting()));

			return (T)this;
		}

		protected abstract float GetHealthCurrentStarting();
		protected abstract float GetHealthMaxStarting();
	}
}