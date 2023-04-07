using Opsive.UltimateCharacterController.Traits;
using UnityEngine;

namespace CodeBase
{
    public class ZombieHealth : Health
    {
        public Animator zombieAnimator;
        public Collider zombieCollider;
        public override void Die(Vector3 position, Vector3 force, GameObject attacker)
        {
            base.Die(position, force, attacker);
            SwitchRagdollState(false);
        }
        
        public void SwitchRagdollState(bool activate)
        {
            zombieAnimator.enabled = activate;
            zombieCollider.enabled = activate;
        }
    }
}
