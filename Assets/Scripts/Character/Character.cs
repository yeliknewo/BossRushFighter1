using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public abstract class Character : MonoBehaviour
	{
		private Dictionary<StatType, Stat> stats;

		internal void Init()
		{
			this.stats = new Dictionary<StatType, Stat>();
		}

		public Stat GetStat(StatType statType)
		{
			Stat stat;
			this.stats.TryGetValue(statType, out stat);
			return stat;
		}

		internal void SetBaseStat(StatType statType, Stat stat)
		{
			if (!this.stats.ContainsKey(statType))
			{
				this.stats.Add(statType, stat);
			}
			else
			{
				Debug.LogException(new System.Exception(string.Format("Stat ({0}) was already in stats for ({1})", statType, this.name)));
			}
		}
	}
}