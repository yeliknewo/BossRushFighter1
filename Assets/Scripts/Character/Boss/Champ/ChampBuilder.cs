using Inputs.GPDXD;
using UnityEngine;
using Other;

namespace Characters.Boss.Champ
{
	public class ChampBuilder : BossBuilder<ChampBuilder, Champ, ChampAction>
	{
		private static ChampBuilder builder;

		public static ChampBuilder Get()
		{
			if (builder == null)
			{
				builder = new ChampBuilder();
			}
			return builder;
		}

		private const float HEALTH_CURRENT_STARTING = 100;

		private const float HEALTH_MAX_STARTING = 100;

		private const string NAME = "Champ";

		private const string ASSET_PATH_SPRITE = "Sprites\\TestArt1";

		protected override float GetHealthCurrentStarting()
		{
			return HEALTH_CURRENT_STARTING;
		}

		protected override float GetHealthMaxStarting()
		{
			return HEALTH_MAX_STARTING;
		}

		protected override string GetName()
		{
			return NAME;
		}

		protected override Sprite GetSprite()
		{
			return Utility.LoadSprite(ASSET_PATH_SPRITE, "Unable to load Champ Sprite");
		}

		protected override ChampBuilder AddCore()
		{
			GetObj().AddComponent<Champ>();

			return this;
		}

		protected override ChampBuilder AddRenderer()
		{
			SpriteRenderer renderer = GetObj().AddComponent<SpriteRenderer>();
			renderer.sprite = GetSprite();

			return this;
		}

		protected override ChampBuilder AddRigidbody()
		{
			Rigidbody2D rb = GetObj().AddComponent<Rigidbody2D>();
			rb.isKinematic = true;

			return this;
		}

		protected override ChampBuilder AddCollider()
		{
			GetObj().AddComponent<BoxCollider2D>();

			return this;
		}

		protected override ChampBuilder AddMoves(KeyManager manager)
		{

			return this;
		}
	}
}