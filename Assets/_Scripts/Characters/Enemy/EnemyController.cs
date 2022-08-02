using UnityEngine;
using UnityEngine.AI;
using HiringTest.Utils;

namespace HiringTest
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] NavMeshAgent _agent;
        [SerializeField] GameObject _npc;
        [SerializeField] Animator _animator;
        [SerializeField] State _currentState;
        [SerializeField] LayerMask _visObstacleLayers; // Layers that cover the enemy's view

        TriggerAnimType _currentTriggerAnim;

        #region MonoBehabiour Callbacks

        private void Awake()
        {
            Events.SetEnemyTriggerAnim += OnSetTriggerAnim;
        }

        private void Start()
        {
            if (!NetworkManager.Instance.IsMasterClient) return;

            _currentState = new IdleState(_npc, _agent, _animator, _visObstacleLayers);
        }

        private void OnDestroy()
        {
            Events.SetEnemyTriggerAnim -= OnSetTriggerAnim;
        }

        private void Update()
        {
            if (!NetworkManager.Instance.IsMasterClient) return;

            _currentState = _currentState.Process();
        }
        #endregion

        void OnSetTriggerAnim(TriggerAnimType triggerAnim)
        {
            _animator.ResetTrigger(_currentTriggerAnim.ToString());
            _animator.SetTrigger(triggerAnim.ToString());
            _currentTriggerAnim = triggerAnim;
        }

    }
}

