using System;
using UnityEngine;
using EGamePlay.Combat;

namespace ET
{
	[ActorMessageHandler]
	public class G2M_CreateUnitHandler : AMActorRpcHandler<Scene, G2M_CreateUnit, M2G_CreateUnit>
	{
		protected override async ETTask Run(Scene scene, G2M_CreateUnit request, M2G_CreateUnit response, Action reply)
		{
			Unit unit = EntityFactory.Create<Unit, int>(scene, 1001);
			unit.Position = new Vector3(-10, 0, -10);
			var vCol = new VCollisionSphere { Pos = VInt3.zero, Radius = ((VInt)1f).i };
			vCol.Born(new Assets.Scripts.GameLogic.ActorRoot());
			unit.AddComponent<CollisionComponent, VCollisionShape>(vCol);
			unit.AddComponent<MoveComponent>();
            unit.AddComponent<CombatComponent, CombatEntity>(CombatContext.Instance.AddChildWithId<CombatEntity>(unit.Id));

			NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
			numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
			
			unit.AddComponent<MailBoxComponent>();
			await unit.AddLocation();
			unit.AddComponent<UnitGateComponent, long>(request.GateSessionId);
			scene.GetComponent<UnitComponent>().Add(unit);
			response.UnitId = unit.Id;
			
			// 把自己广播给周围的人
			var createUnits = new M2C_CreateUnits();
			createUnits.Units.Add(UnitHelper.CreateUnitInfo(unit));
			MessageHelper.Broadcast(unit, createUnits);
			
			// 把周围的人通知给自己
			createUnits.Units.Clear();
			Unit[] units = scene.GetComponent<UnitComponent>().GetAll();
			foreach (Unit u in units)
			{
				createUnits.Units.Add(UnitHelper.CreateUnitInfo(u));
			}
			units = scene.GetComponent<MonsterComponent>().GetAll();
			foreach (Unit u in units)
			{
				createUnits.Units.Add(UnitHelper.CreateUnitInfo(u));
			}
			MessageHelper.SendActor(unit.GetComponent<UnitGateComponent>().GateSessionActorId, createUnits);

			reply();
		}
	}
}