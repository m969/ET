using UnityEngine;

namespace ET
{
    public class Unit_MoveStop : AEvent<EventType.MoveStop>
    {
        protected override async ETTask Run(EventType.MoveStop args)
        {
            if (args.Unit.GetComponent<AnimatorComponent>() == null) return;
            args.Unit.Moving = false;
            args.Unit.GetComponent<AnimatorComponent>().Animator.CrossFade("Archer_Idle", 0.2f);
            await ETTask.CompletedTask;
        }
    }
}