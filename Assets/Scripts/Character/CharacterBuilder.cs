using Inputs.GPDXD;
using UnityEngine;

namespace Characters
{
	public abstract class CharacterBuilder<T> where T : CharacterBuilder<T>
	{
		public GameObject Build(KeyManager manager)
		{
			obj = new GameObject(GetName());
			AddCore().AddRenderer().AddRigidbody().AddCollider().AddStats().AddMoves(manager);
			return obj;
		}

		private GameObject obj;

		protected GameObject GetObj()
		{
			return obj;
		}

		protected abstract string GetName();
		protected abstract Sprite GetSprite();
		protected abstract T AddCore();
		protected abstract T AddRenderer();
		protected abstract T AddRigidbody();
		protected abstract T AddCollider();
		protected abstract T AddStats();
		protected abstract T AddMoves(KeyManager manager);
	}
}