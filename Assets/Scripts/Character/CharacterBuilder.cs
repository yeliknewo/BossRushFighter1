using UnityEngine;

namespace Character
{
	public abstract class CharacterBuilder<T> where T : CharacterBuilder<T>
	{
		public GameObject Build()
		{
			obj = new GameObject(GetName());
			AddCore().AddRenderer().AddRigidbody().AddCollider().AddStats().AddMoves();
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
		protected abstract T AddMoves();
	}
}