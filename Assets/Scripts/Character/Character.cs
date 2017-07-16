using System.Collections.Generic;
using UnityEngine;
using Moves;
using Movements;
using Stats;
using Physics;

namespace Characters
{
	public abstract class Character<A, C> : MonoBehaviour where C: Character<A, C>
	{
		private Dictionary<StatType, Stat> stats;
		private List<Move<A>> moves;
		private Movement<A, C> movement;

		protected PhysicsObject GetPhysics()
		{
			return GetComponent<PhysicsObject>();
		}

		protected Movement<A, C> GetMovement()
		{
			return movement;
		}

		internal void InitStats()
		{
			stats = new Dictionary<StatType, Stat>();
		}

		internal void InitMoves(Movement<A, C> newMovement)
		{
			moves = new List<Move<A>>();
			movement = newMovement;
			PhysicsObject physics = gameObject.AddComponent<PhysicsObject>();
			physics.SetGravity(Vector3.down);
		}

		internal void AddMove(Move<A> move)
		{
			moves.Add(move);
		}

		public void Update()
		{
			Move<A> activeMove = null;

			foreach (Move<A> move in moves)
			{
				move.Update();
				if (move.IsActive() && ((activeMove != null && move.GetPriority() > activeMove.GetPriority()) || activeMove == null))
				{
					activeMove = move;
				}
			}

			if (activeMove != null)
			{
				DoMove(activeMove);
			}
		}

		protected abstract void DoMove(Move<A> move);

		public Stat GetStat(StatType statType)
		{
			Stat stat;
			stats.TryGetValue(statType, out stat);
			return stat;
		}

		internal void SetBaseStat(StatType statType, Stat stat)
		{
			if (!stats.ContainsKey(statType))
			{
				stats.Add(statType, stat);
			}
			else
			{
				Debug.LogException(new System.Exception(string.Format("Stat ({0}) was already in stats for ({1})", statType, name)));
			}
		}
	}
}