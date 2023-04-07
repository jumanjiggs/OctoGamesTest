using UnityEngine;

namespace CodeBase.Zombies
{
    public class ZombieAnimator : MonoBehaviour
    {
        private static readonly int Move = Animator.StringToHash("Move");
        
        [SerializeField] private Animator animator;
        private static readonly int Attack = Animator.StringToHash("Attack");

        public void PlayRun() => 
            animator.SetFloat(Move, 1f,0.1f, Time.deltaTime);

        public void PlayIdle() => 
            animator.SetFloat(Move, 0f,0.1f, Time.deltaTime);

        public void PlayAttack() => 
            animator.SetTrigger(Attack);
    }
}