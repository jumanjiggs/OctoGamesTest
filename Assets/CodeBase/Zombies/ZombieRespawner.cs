using Opsive.UltimateCharacterController.Traits;
using UnityEngine;

namespace CodeBase.Zombies
{
    public class ZombieRespawner : Respawner
    {
        private ZombieHealth m_ZombieHealth;

        protected override void Awake()
        {
            base.Awake();
            m_ZombieHealth = GetComponent<ZombieHealth>();
        }

        public override void Respawn(Vector3 position, Quaternion rotation, bool transformChange)
        {
            base.Respawn(position, rotation, transformChange);
            m_ZombieHealth.SwitchRagdollState(true);
        }
        
    }
}