using System;

namespace GPDXD
{
	public class KeyCombo
	{

	}

	internal class ButtonHistory : KeyHistory
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

	internal class AxisHistory : KeyHistory
	{
		private float axisThresholdMin;
		private float axisThresholdMax;

		internal AxisHistory(KeyStroke keyStroke, float offsetTime, float newAxisThresholdMin, float newAxisThresholdMax) : base(keyStroke, offsetTime)
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

	internal abstract class KeyHistory
	{
		private KeyStroke keyStroke;
		private float lastPressTime;
		private float offsetTime;
		private float nextPressThreshold;

		internal KeyHistory(KeyStroke newKeyStroke, float newOffsetTime)
		{
			keyStroke = newKeyStroke;
			offsetTime = newOffsetTime;
		}

		internal bool IsActive()
		{
			return nextPressThreshold > UnityEngine.Time.time;
		}

		internal abstract void Update();

		protected KeyStroke GetKeyStroke()
		{
			return keyStroke;
		}

		protected void Press()
		{
			lastPressTime = UnityEngine.Time.time;
			nextPressThreshold = lastPressTime + offsetTime;
		}
	}

	internal enum ButtonEventType
	{
		ButtonDown,
		ButtonUp,
		ButtonHeld,
	}

}