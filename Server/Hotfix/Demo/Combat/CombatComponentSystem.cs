using System.Linq;
using EGamePlay.Combat;
using EGamePlay.Combat.Skill;

namespace ET
{
    public class CombatComponentAwakeSystem : AwakeSystem<CombatComponent, CombatEntity>
    {
        public override void Awake(CombatComponent self, CombatEntity combatEntity)
        {
            self.Awake(combatEntity);
        }
    }

    public class CombatComponentUpdateSystem : UpdateSystem<CombatComponent>
    {
        public override void Update(CombatComponent self)
        {
            self.Update();
        }
    }

    public class CombatComponentDestroySystem : DestroySystem<CombatComponent>
    {
        public override void Destroy(CombatComponent self)
        {
            self.Destroy();
        }
    }

    public static class CombatComponentSystem
    {
        public static void Awake(this CombatComponent self, CombatEntity combatEntity)
        {
            var unit = self.GetParent<Unit>();
            combatEntity.Id = unit.Id;
            self.CombatEntity = combatEntity;
            combatEntity.AddComponent<CombatUnitComponent>().Unit = unit;
            combatEntity.AddComponent<SpellComponent>();
            //unit.Domain.GetComponent<EGamePlayComponent>().Unit2CombatEntities.Add(unit, combatEntity);

            var config = SkillConfigCategory.Instance.Get(1001);
            SkillAbility ability = self.CombatEntity.AttachSkill<SkillAbility1001>(config);
            self.CombatEntity.BindSkillInput(ability, UnityEngine.KeyCode.Q);
        }

        public static void Destroy(this CombatComponent self)
        {

        }

        public static void Update(this CombatComponent self)
        {
            
        }
    }
}