using System;
using UnityEngine;

namespace CodeBase.Services
{
    public class KillsCounter : MonoBehaviour
    {
        public Action<int> OnZombieDie;
        
        public int countKills;

        public void ZombieDie()
        {
            IncreaseCount();
            OnZombieDie?.Invoke(countKills);
        }
        private void IncreaseCount() => 
            countKills++;
    }
}