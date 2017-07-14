using UnityEngine;
using Characters.Hero.Kappa;
using Characters.Boss.Champ;
using Inputs.GPDXD;

namespace Scenes.Test1
{
	public class Spawner : MonoBehaviour
	{
		public void Start()
		{
			KeyManager manager = new KeyManager();

			GameObject kappaObj = KappaBuilder.Get().Build(manager);
			kappaObj.transform.position = Vector3.left;

			GameObject champObj = ChampBuilder.Get().Build(manager);
			champObj.transform.position = Vector3.right;
		}
	}
}
