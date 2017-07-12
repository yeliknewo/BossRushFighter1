using System;
using UnityEngine;
using System.Collections.Generic;

namespace GPDXD
{
	public class KeyManager
	{
		private List<KeyHistory> keyHistories;

		public KeyManager()
		{
			keyHistories = new List<KeyHistory>();
		}

		public KeyHistoryId AddKeyHistory(KeyHistory keyHistory)
		{
			int count = keyHistories.Count;
			keyHistories.Add(keyHistory);
			return new KeyHistoryId(count);
		}

		internal KeyHistory GetKeyHistory(KeyHistoryId keyHistoryId)
		{
			int id = keyHistoryId.GetId();

			if (id < keyHistories.Count)
			{
				return keyHistories[id];
			}
			else
			{
				return null;
			}
		}
	}

	public class KeyHistoryId
	{
		private int id;

		internal KeyHistoryId(int newId)
		{
			id = newId;
		}

		internal int GetId()
		{
			return id;
		}
	}

	public class KeyCombo
	{
		private KeyManager keyManager;
		private List<KeyHistory> keyCombos;

		private int keyHistoryCurrent;
		private bool comboReady;
		private bool comboDone;

		public KeyCombo(KeyManager newKeyManager)
		{
			keyManager = newKeyManager;
			keyCombos = new List<KeyHistory>();
			comboReady = false;
			comboDone = true;
		}

		public void RegisterKeyHistory(KeyHistoryId keyHistoryId)
		{
			keyCombos.Add(keyManager.GetKeyHistory(keyHistoryId));
		}

		public void Update()
		{
			comboReady = false;

			foreach (KeyHistory keyHistory in keyCombos)
			{
				keyHistory.Update();
			}

			if (comboDone)
			{
				KeyHistory keyHistory = keyCombos[keyHistoryCurrent];

				if (keyHistory.IsActive())
				{
					keyHistoryCurrent++;
					if (keyHistoryCurrent == keyCombos.Count)
					{
						keyHistoryCurrent = 0;
						comboReady = true;
						comboDone = false;
					}
				}
			}

		}

		public bool IsComboTriggered()
		{
			return comboReady;
		}

		public void SetComboDone()
		{ 
			comboDone = true;
		}
	}

	public class ButtonHistory : KeyHistory
	{
		private ButtonEventType buttonEventType;

		public ButtonHistory(ButtonEventType newButtonEventType, KeyStroke newKeyStroke, float newOffsetTime) : base(newKeyStroke, newOffsetTime)
		{
			buttonEventType = newButtonEventType;
		}

		internal override void Update()
		{
			switch (buttonEventType)
			{
				case ButtonEventType.ButtonDown:
					if (GetKeyStroke().GetButtonDown())
					{
						Press();
					}
					break;

				case ButtonEventType.ButtonHeld:
					if (GetKeyStroke().GetButtonHeld())
					{
						Press();
					}
					break;

				case ButtonEventType.ButtonUp:
					if (GetKeyStroke().GetButtonUp())
					{
						Press();
					}
					break;
			}
		}
	}

	public class AxisHistory : KeyHistory
	{
		private float axisThresholdMin;
		private float axisThresholdMax;

		public AxisHistory(KeyStroke keyStroke, float offsetTime, float newAxisThresholdMin, float newAxisThresholdMax) : base(keyStroke, offsetTime)
		{
			axisThresholdMin = newAxisThresholdMin;
			axisThresholdMax = newAxisThresholdMax;
		}

		internal override void Update()
		{
			float axis = GetKeyStroke().GetAxis();

			if (axis >= axisThresholdMin && axis <= axisThresholdMax)
			{
				Press();
			}
		}
	}

	public abstract class KeyHistory
	{
		private KeyStroke keyStroke;
		private float lastPressTime;
		private float offsetTime;
		private float nextPressThreshold;

		public KeyHistory(KeyStroke newKeyStroke, float newOffsetTime)
		{
			keyStroke = newKeyStroke;
			offsetTime = newOffsetTime;
		}

		internal bool IsActive()
		{
			return nextPressThreshold >= Time.time;
		}

		internal abstract void Update();

		protected KeyStroke GetKeyStroke()
		{
			return keyStroke;
		}

		protected void Press()
		{
			lastPressTime = Time.time;
			nextPressThreshold = lastPressTime + offsetTime;
		}
	}

	public enum ButtonEventType
	{
		ButtonDown,
		ButtonUp,
		ButtonHeld,
	}
}