using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Other
{
	public class Utility
	{
		public static Sprite LoadSprite(string path, string errorMessage)
		{
			Sprite sprite = Resources.Load<Sprite>(path);
			Debug.Assert(sprite != null, errorMessage);
			return sprite;
		}
	}
}

