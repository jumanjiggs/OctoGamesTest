using CodeBase.Services;
using Opsive.UltimateCharacterController.Traits;
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
        
        public override void Die(Vector3 position, Vector3 force, GameObject attacker)
        {
            base.Die(position, force, attacker);
            SwitchRagdollState(false);
            m_KillsCounter.ZombieDie();
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
