using System;
using UnityEngine;

namespace Character
{
	public class KappaBuilder : HeroBuilder<KappaBuilder, Kappa>
	{
		private static KappaBuilder builder;

		public static KappaBuilder Get()
		{
			if (builder == null)
			{
				builder = new KappaBuilder();
			}
			return builder;
		}

		private const float HEALTH_CURRENT_STARTING = 100;

		private const float HEALTH_MAX_STARTING = 100;

		private const string NAME = "Kappa";

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
			return Utility.LoadSprite(ASSET_PATH_SPRITE, "Unable to load Kappa Sprite");
		}

		protected override KappaBuilder AddCore()
		{
			GetObj().AddComponent<Kappa>();

			return this;
		}

		protected override KappaBuilder AddRenderer()
		{
			SpriteRenderer renderer = GetObj().AddComponent<SpriteRenderer>();
			renderer.sprite = GetSprite();

			return this;
		}

		protected override KappaBuilder AddRigidbody()
		{
			GetObj().AddComponent<Rigidbody2D>();

			return this;
		}

		protected override KappaBuilder AddCollider()
		{
			GetObj().AddComponent<BoxCollider2D>();

			return this;
		}

		protected override KappaBuilder AddMoves()
		{
			// TODO

			return this;
		}
	}
}