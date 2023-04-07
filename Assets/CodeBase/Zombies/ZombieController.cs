using System.Linq;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Zombies
{
    public class ZombieController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private ZombieAnimator animator;

        private int m_LayerMask;
        private readonly Collider[] m_Hits = new Collider[1];
        private const float Radius = 1f;
        private const float distance = 1f;
        private bool m_IsActiveAttack;

        private void Awake() =>
            m_LayerMask = 1 << LayerMask.NameToLayer("Character");

        private void Update() =>
            MoveToDestination();

        private void MoveToDestination()
        {
            agent.SetDestination(target.position);
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.PlayRun();
                ResetAttack();
            }
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.PlayIdle();
                if (!m_IsActiveAttack)
                    OnAttack();
            }
        }

        private void OnAttack()
        {
            m_IsActiveAttack = true;
            if (Hit(out Collider hit))
            {
                animator.PlayAttack();
                hit.transform.GetComponentInParent<CharacterHealth>().Damage(10);
            }
        }

        private bool Hit(out Collider hit)
        {
            var hitsCount = Physics.OverlapSphereNonAlloc(GetStartPoint(), Radius, m_Hits, m_LayerMask);
            hit = m_Hits.FirstOrDefault();
            return hitsCount > 0;
        }

        private Vector3 GetStartPoint()
        {
            var startPoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
                             transform.forward * distance;
            return startPoint;
        }

        public void ResetAttack() =>
            m_IsActiveAttack = false;
    }
}