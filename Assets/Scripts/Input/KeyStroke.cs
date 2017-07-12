﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPDXD
{
	public class KeyStroke
	{
		private KeyType keyType;

		private bool flagButton;

		private bool flagInvertAxis;

		private string buttonName;

		private string axisName;

		public KeyStroke(KeyType newKeyType)
		{
			keyType = newKeyType;
			flagButton = IsButton(keyType);
			if (flagButton)
			{
				buttonName = GetAxisName(keyType);
			}
			else
			{
				flagInvertAxis = IsInvertAxis(keyType);
			}
			axisName = GetAxisName(keyType);
		}

		public bool IsButton()
		{
			return flagButton;
		}

		public bool GetButtonDown()
		{
			if (flagButton)
			{
				return Input.GetButtonDown(buttonName);
			}
			else
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was not a button in GetButtonDown", keyType));
				return false;
			}
		}

		public bool GetButtonUp()
		{
			if (flagButton)
			{
				return Input.GetButtonUp(buttonName);
			}
			else
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was not a button in GetButtonUp", keyType));
				return false;
			}
		}

		public bool GetButtonHeld()
		{
			if (flagButton)
			{
				return Input.GetButton(buttonName);
			}
			else
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was not a button in GetButton", keyType));
				return false;
			}
		}

		public float GetAxis()
		{
			if (flagButton)
			{
				Debug.LogError(string.Format("KeyStroke ({0}) was a button in GetAxis", keyType));
			}
			if (flagInvertAxis)
			{
				return -Input.GetAxis(axisName);
			}
			else
			{
				return Input.GetAxis(axisName);
			}

		}

		//private const string BUTTON_A = "joystick button 0";
		//private const string BUTTON_B = "joystick button 1";
		//private const string BUTTON_X = "joystick button 2";
		//private const string BUTTON_Y = "joystick button 3";
		//private const string BUTTON_L1 = "joystick button 4";
		//private const string BUTTON_R1 = "joystick button 5";
		//private const string BUTTON_L2 = "joystick button 6";
		//private const string BUTTON_R2 = "joystick button 7";
		//private const string BUTTON_L3 = "joystick button 8";
		//private const string BUTTON_R3 = "joystick button 9";
		//private const string BUTTON_START = "joystick button 10";
		//private const string BUTTON_SELECT = "joystick button 11";

		private static bool IsButton(KeyType keyType)
		{
			return keyType == KeyType.A || keyType == KeyType.B || keyType == KeyType.X || keyType == KeyType.Y || keyType == KeyType.L1 || keyType == KeyType.R1 || keyType == KeyType.L2 || keyType == KeyType.R2 || keyType == KeyType.L3 || keyType == KeyType.R3 || keyType == KeyType.Start || keyType == KeyType.Select;
		}

		private static bool IsInvertAxis(KeyType keyType)
		{
			return (keyType == KeyType.DPadY || keyType == KeyType.LeftJoyY || keyType == KeyType.RightJoyY);
		}

		//private static string GetButtonName(KeyType keyType)
		//{
		//	switch (keyType)
		//	{

		//		case KeyType.A:
		//			return BUTTON_A;

		//		case KeyType.B:
		//			return BUTTON_B;

		//		case KeyType.X:
		//			return BUTTON_X;

		//		case KeyType.Y:
		//			return BUTTON_Y;

		//		case KeyType.L1:
		//			return BUTTON_L1;

		//		case KeyType.R1:
		//			return BUTTON_R1;

		//		case KeyType.L2:
		//			return BUTTON_L2;

		//		case KeyType.R2:
		//			return BUTTON_R2;

		//		case KeyType.L3:
		//			return BUTTON_L3;

		//		case KeyType.R3:
		//			return BUTTON_R3;

		//		case KeyType.Start:
		//			return BUTTON_START;

		//		case KeyType.Select:
		//			return BUTTON_SELECT;

		//		default:
		//			return "";
		//	}
		//}

		private static string GetAxisName(KeyType keyType)
		{
			switch (keyType)
			{
				case KeyType.LeftJoyX:
					return "LeftJoyX";

				case KeyType.LeftJoyY:
					return "LeftJoyY";

				case KeyType.RightJoyX:
					return "RightJoyX";

				case KeyType.RightJoyY:
					return "RightJoyY";

				case KeyType.DPadX:
					return "DPadX";

				case KeyType.DPadY:
					return "DPadY";

				case KeyType.A:
					return "A";

				case KeyType.B:
					return "B";

				case KeyType.X:
					return "X";

				case KeyType.Y:
					return "Y";

				case KeyType.L1:
					return "L1";

				case KeyType.R1:
					return "R1";

				case KeyType.L2:
					return "L2";

				case KeyType.R2:
					return "R2";

				case KeyType.L3:
					return "L3";

				case KeyType.R3:
					return "R3";

				case KeyType.Start:
					return "Start";

				case KeyType.Select:
					return "Select";

				default:
					return "";
			}
		}
	}

	public enum KeyType
	{
		LeftJoyX,
		LeftJoyY,
		RightJoyX,
		RightJoyY,
		DPadX,
		DPadY,
		A,
		B,
		X,
		Y,
		L1,
		R1,
		L2,
		R2,
		L3,
		R3,
		Start,
		Select,
	}
}

