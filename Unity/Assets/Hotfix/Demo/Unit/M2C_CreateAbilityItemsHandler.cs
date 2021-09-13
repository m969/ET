
using Vector3 = UnityEngine.Vector3;

namespace ET
{
	[MessageHandler]
	public class M2C_CreateAbilityItemsHandler : AMHandler<M2C_CreateAbilityItems>
	{
		protected override async ETVoid Run(Session session, M2C_CreateAbilityItems message)
		{	
			UnitComponent unitComponent = session.Domain.GetComponent<UnitComponent>();
			
			foreach (UnitInfo unitInfo in message.AbilityItems)
			{
				if (unitComponent.Get(unitInfo.UnitId) != null)
				{
					continue;
				}
				Unit unit = UnitFactory.Create(session.Domain, unitInfo);
			}

			await ETTask.CompletedTask;
		}
	}
}
