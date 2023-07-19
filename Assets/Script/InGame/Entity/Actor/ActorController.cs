using UniRx.Triggers;
using UniRx;
using UnityEngine;
using Minefarm.InGame;
using Minefarm.Map.Block;

namespace Minefarm.Entity.Actor
{
    [RequireComponent(typeof(ActorModel))]
    public class ActorController : EntityController
    {     
        protected ActorModel actorModel { get => (ActorModel)entityModel; }
        public virtual void Awake()
        {
            SubscribeStream();
        }

        private void SubscribeStream()
        {
            this.OnCollisionEnterAsObservable()
                .Select(collider => collider.gameObject)
                .Where(go => go.layer == LayerMask.NameToLayer("Block"))
                .Subscribe(_ => actorModel.isGround = true);
        }

        public override void Spawn()
        {
            actorModel.hp = actorModel.calculatedMaxHp;
            base.Spawn();
        }

        public bool FowardAction()
        {
            EntityModel fowardEntity = GetFowardEntity();
            if (actorModel.fowardActionable.Action(fowardEntity))
            {
                actorModel.onFowardAction.Invoke(fowardEntity);
                return true;
            }
            return false;
        }

        public void Move(Vector3 direction)
        {
            if (actorModel.moveable.Move(direction))
                actorModel.onMove.Invoke(direction);
        }

        public void Shoot(Vector3 direction)
        {
            if (actorModel.shootable.Shoot(direction))
                actorModel.onShoot.Invoke(direction);
        }

        public void Attack(ActorModel target, int damage)
        {
            if (actorModel.attackable.Attack(target, damage))
                actorModel.onAttack.Invoke(target, damage);
        }

        public void Jump()
        {
            if (actorModel.jumpable.Jump())
                actorModel.onJump.Invoke();
        }

        public void Damge(ActorModel target, int damage)
        {
            bool isCritical = false;
            int retDamage = -1;
            if (actorModel.damageable.Damage(target, damage, out retDamage, out isCritical))
                actorModel.onDamage.Invoke(target, retDamage, isCritical);
        }

        public EntityModel GetFowardEntity(Vector3 foawrd, float distance = 1f, int layer = ~0)
        {
            RaycastHit hit;
            Ray ray = new Ray(rigidbody.position + transform.up * 0.5f, foawrd);

            if (Physics.SphereCast(ray, 0.15f, out hit, distance + 0.15f, layer))
                return hit.transform.GetComponent<EntityModel>();
            return null;
        }
        public EntityModel GetFowardEntity(float distance = 1f, int layer = ~0)
            => GetFowardEntity(actorModel.body.forward, distance, layer);
    }
}
