using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Zombies
{
    public class ZombieAnimator : MonoBehaviour
    {
        
        [SerializeField] private Animator animator;

        public void PlayRun() => 
            animator.SetFloat(Constants.Move, 1f,0.1f, Time.deltaTime);

        public void PlayIdle() => 
            animator.SetFloat(Constants.Move, 0f,0.1f, Time.deltaTime);

        public void PlayAttack() => 
            animator.SetTrigger(Constants.Attack);
    }
}