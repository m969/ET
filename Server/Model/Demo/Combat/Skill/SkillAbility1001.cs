using EGamePlay.Combat.Ability;
using EGamePlay.Combat.Skill;

namespace ET
{
	public class SkillAbility1001 : SkillAbility
	{
        public override AbilityExecution CreateExecution()
        {
            var abilityExecution = Parent.AddChild<SkillExecution1001>(this);
            return abilityExecution;
        }
    }

    public class SkillExecution1001 : SkillExecution
    {
        public override void BeginExecute()
        {
            Game.EventSystem.Publish(new EventType.OnBeginExecute() { AbilityExecution = this }).Coroutine();
        }

        public override void Update()
        {

        }

        public override void EndExecute()
        {

        }
    }
}