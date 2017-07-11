using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPDXD
{
	public class KeyStroke
	{
		public static float GetAxis(KeyType keyType)
		{
			return Input.GetAxis(GetAxisName(keyType));
		}

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

				case KeyType.L2:
					return "L2";

				case KeyType.R2:
					return "R2";

				case KeyType.A:
					return "0";

				case KeyType.B:
					return "1";

				case KeyType.X:
					return "2";

				case KeyType.Y:
					return "3";

				case KeyType.L1:
					return "4";

				case KeyType.R1:
					return "5";

				case KeyType.L3:
					return "8";

				case KeyType.R3:
					return "9";

				case KeyType.Start:
					return "10";

				case KeyType.Select:
					return "11";

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
		L2,
		R2,
		A,
		B,
		X,
		Y,
		L1,
		R1,
		L3,
		R3,
		Start,
		Select,
	}
}

