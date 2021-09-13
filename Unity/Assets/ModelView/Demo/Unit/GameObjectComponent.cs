using UnityEngine;

namespace ET
{
    public class GameObjectComponentDestroySystem : DestroySystem<GameObjectComponent>
    {
        public override void Destroy(GameObjectComponent self)
        {
            if (self.GameObject != null)
            {
                GameObject.Destroy(self.GameObject);
            }
        }
    }

    public class GameObjectComponent: Entity
    {
        public GameObject GameObject;
    }
}