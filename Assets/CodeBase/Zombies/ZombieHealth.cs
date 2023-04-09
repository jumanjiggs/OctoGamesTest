using CodeBase.Services;
using Opsive.UltimateCharacterController.Traits;
using Opsive.UltimateCharacterController.Traits.Damage;
using UnityEngine;
using Zenject;

namespace CodeBase.Zombies
{
    public class ZombieHealth : Health
    {
        public ZombieController agent;
        public Animator zombieAnimator;
        public Collider zombieCollider;
        [Inject] private KillsCounter m_KillsCounter;
        [SerializeField] private ParticleSystem fxHit;


        public override void Die(Vector3 position, Vector3 force, GameObject attacker)
        {
            base.Die(position, force, attacker);
            SwitchRagdollState(false);
            m_KillsCounter.ZombieDie();
        }


        public override void OnDamage(DamageData damageData)
        {
            base.OnDamage(damageData);
            PlayFxOnHit();
        }

        private void PlayFxOnHit()
        {
            Instantiate(fxHit.gameObject,
                new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z),
                Quaternion.identity, transform);
        }

        public void SwitchRagdollState(bool activate)
        {
            agent.ResetAttack();
            zombieAnimator.enabled = activate;
            zombieCollider.enabled = activate;
            agent.enabled = activate;
        }
    }
}