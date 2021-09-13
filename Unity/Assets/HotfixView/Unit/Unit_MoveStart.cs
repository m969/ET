using UnityEngine;

namespace ET
{
    public class Unit_MoveStart : AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(EventType.MoveStart args)
        {
            if (args.Unit.GetComponent<AnimatorComponent>() == null) return;
            AnimatorComponent animatorComponent = args.Unit.GetComponent<AnimatorComponent>();
            if (args.Unit.Moving == false)
            {
                args.Unit.Moving = true;
                animatorComponent.Animator.CrossFade("Archer_run", 0.1f);
            }
            await ETTask.CompletedTask;
        }
    }
}