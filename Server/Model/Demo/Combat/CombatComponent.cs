namespace ET
{
	public class CombatComponent : Entity
	{
		public EGamePlay.Combat.CombatEntity CombatEntity { get; set; }
		public Unit Unit => this.GetParent<Unit>();
	}
}