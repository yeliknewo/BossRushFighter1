using Inputs.GPDXD;
using Moves;
using UnityEngine;
using Other;
using Movements;

namespace Characters.Hero.Kappa
{
	public class KappaBuilder : HeroBuilder<KappaBuilder, Kappa, KappaAction>
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

		private const float AXIS_X_DEADZONE = 0.1f;

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
			Rigidbody2D rb = GetObj().AddComponent<Rigidbody2D>();
			rb.isKinematic = true;

			return this;
		}

		protected override KappaBuilder AddCollider()
		{
			GetObj().AddComponent<BoxCollider2D>();

			return this;
		}

		protected override KappaBuilder AddMoves(KeyManager manager)
		{
			Kappa kappa = GetObj().GetComponent<Kappa>();

			Movement<KappaAction, Kappa> movement = new Movement<KappaAction, Kappa>();

			kappa.InitMoves(movement);

			KeyHistoryId moveLeft = manager.AddKeyHistory(new AxisHistory(new KeyStroke(KeyType.LeftJoyX), 0f, -1f, -AXIS_X_DEADZONE));
			KeyHistoryId moveRight = manager.AddKeyHistory(new AxisHistory(new KeyStroke(KeyType.LeftJoyX), 0f, AXIS_X_DEADZONE, 1f));

			{
				KeyCombo combo = new KeyCombo(manager);

				combo.RegisterKeyHistory(moveLeft);

				kappa.AddMove(new Move<KappaAction>(combo, KappaAction.Left, PriorityConstants.PRIORITY_MOVE_LEFT));
			}

			{
				KeyCombo combo = new KeyCombo(manager);

				combo.RegisterKeyHistory(moveRight);

				kappa.AddMove(new Move<KappaAction>(combo, KappaAction.Right, PriorityConstants.PRIORITY_MOVE_RIGHT));
			}

			return this;
		}
	}
}