using GPDXD;
using UnityEngine;

namespace Character
{
	public class Kappa : Hero
	{
		private KeyCombo keyCombo;
		private KeyCombo resetCombo;

		public void AddKeyCombo()
		{
			KeyManager manager = new KeyManager();
			keyCombo = new KeyCombo(manager);

			KeyHistoryId id = manager.AddKeyHistory(new ButtonHistory(ButtonEventType.ButtonDown, new KeyStroke(KeyType.A), 1f));
			keyCombo.RegisterKeyHistory(id);

			id = manager.AddKeyHistory(new ButtonHistory(ButtonEventType.ButtonDown, new KeyStroke(KeyType.B), 0f));
			keyCombo.RegisterKeyHistory(id);

			resetCombo = new KeyCombo(manager);

			id = manager.AddKeyHistory(new ButtonHistory(ButtonEventType.ButtonDown, new KeyStroke(KeyType.L1), 0f));
			resetCombo.RegisterKeyHistory(id);

			//KeyHistoryId id = manager.AddKeyHistory(new AxisHistory(new KeyStroke(KeyType.LeftJoyX), 10f, 0.5f, 1f));
			//keyCombo.RegisterKeyHistory(id);

			//id = manager.AddKeyHistory(new AxisHistory(new KeyStroke(KeyType.RightJoyX), 10f, -0.5f, -1f));
			//keyCombo.RegisterKeyHistory(id);
		}

		public void Update()
		{
			keyCombo.Update();
			resetCombo.Update();

			if(resetCombo.IsComboTriggered())
			{
				keyCombo.SetComboDone();
				resetCombo.SetComboDone();
			}

			if (keyCombo.IsComboTriggered())
			{
				transform.Rotate(Vector3.forward * 180);
			}
		}
	}
}