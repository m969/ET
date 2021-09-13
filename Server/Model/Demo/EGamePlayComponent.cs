namespace ET
{
	using EGamePlay;
	using EGamePlay.Combat;

	public class EGamePlayComponentSystem : AwakeSystem<EGamePlayComponent>
	{
		public override void Awake(EGamePlayComponent self)
		{
			self.Awake();
		}
	}

	public class EGamePlayComponentUpdateSystem : UpdateSystem<EGamePlayComponent>
	{
		public override void Update(EGamePlayComponent self)
		{
			self.Update();
		}
	}

	public class EGamePlayComponent : Entity
	{
		//public DoubleMap<Unit, CombatEntity> Unit2CombatEntities { get; set; } = new DoubleMap<Unit, CombatEntity>();


		public void Awake()
        {
			EGamePlay.Entity.EnableLog = true;
			MasterEntity.Create();
            EGamePlay.Entity.Create<CombatContext>();
        }

		public void Update()
		{
			MasterEntity.Instance.Update();
		}
	}
}