using System;
using EGamePlay.Combat.Ability;
using EGamePlay.Combat.Skill;
using UnityEngine;


namespace ET
{
	[ActorMessageHandler]
	public class C2M_SpellRequestHandler : AMActorLocationRpcHandler<Unit, C2M_SpellRequest, M2C_SpellResponse>
	{
		protected override async ETTask Run(Unit unit, C2M_SpellRequest message, M2C_SpellResponse response, Action reply)
		{
            reply();
			var combatEntity = unit.GetComponent<CombatComponent>().CombatEntity;
			var point = new Vector3(message.PointX, message.PointY, message.PointZ);
			combatEntity.GetComponent<SpellComponent>().SpellWithPoint(combatEntity.InputSkills[KeyCode.Q], point);
            await ETTask.CompletedTask;
		}
	}
}