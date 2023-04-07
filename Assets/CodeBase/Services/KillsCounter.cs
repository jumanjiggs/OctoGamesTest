using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Services
{
    public class KillsCounter : MonoBehaviour
    {
        public int countKills;

        [Inject] private GameControl m_GameControl;
        
        public Action<int> OnZombieDie;

        public void ZombieDie()
        {
            IncreaseCount();
            OnZombieDie?.Invoke(countKills);
        }
        private void IncreaseCount() => 
            countKills++;
    }
}