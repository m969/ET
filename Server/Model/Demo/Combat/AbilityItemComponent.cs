using EGamePlay.Combat.Ability;

namespace ET
{
	public class AbilityItemComponent : Entity
	{
		public AbilityItem AbilityItem { get; set; }
        public int SyncTimeLimit { get; set; } = 100;
        public long LastSyncTime { get; set; } = 0;
        public Unit Unit => GetParent<Unit>();
	}
}