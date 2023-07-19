using Minefarm.Entity.Actor.Monster;
using Minefarm.Entity.Actor.NPC;
using Minefarm.Entity.Actor.Player;
using Minefarm.Map.Block;
using UnityEngine;
namespace Minefarm.Entity.Actor.FowardActionable
{
    public class PlayerFowardActionable : Actorable, IFowardActionable
    {
        protected PlayerController playerController { get => controller as PlayerController; }

        public PlayerFowardActionable(ActorModel actor) : base(actor)
        {
        }

        public bool Action(EntityModel target)
        {
            EntityModel fowardEntity = controller.GetFowardEntity();
            if (fowardEntity == null) return false;

            switch (fowardEntity)
            {
                case BlockModel:
                    playerController.Break(
                        fowardEntity as BlockModel, actor.FormulateAttack());
                    break;
                case MonsterModel:
                    playerController.Attack(
                        fowardEntity as MonsterModel, actor.FormulateAttack());
                    break;
                case NPCModel:
                    Debug.Log("NPC");
                    break;
            }
            return true;
        }
    }
}