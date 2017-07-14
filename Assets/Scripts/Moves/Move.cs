using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs.GPDXD;
using System;

namespace Moves
{
	public class Move<T>
	{
		private KeyCombo combo;
		private T action;
		private int priority;

		public Move(KeyCombo newCombo, T newAction, int newPriority)
		{
			combo = newCombo;
			action = newAction;
			priority = newPriority;
		}

		public bool IsActive()
		{
			return combo.IsComboTriggered();
		}

		public void Update()
		{
			combo.Update();
		}

		public void ActionDone()
		{
			combo.SetComboDone();
		}

		public T GetAction()
		{
			return action;
		}

		internal int GetPriority()
		{
			return priority;
		}
	}

}
