using Character;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public void Start()
	{

		GameObject kappaObj = KappaBuilder.Get().Build();
		kappaObj.transform.position = Vector3.left;

		GameObject champObj = ChampBuilder.Get().Build();
		champObj.transform.position = Vector3.right;

	}
}