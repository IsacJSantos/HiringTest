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
        NetworkManager _networkManager;
        bool _enebleAI; // If the AI calcs are activated

        #region MonoBehabiour Callbacks

        private void Awake()
        {
            Events.SetEnemyTriggerAnim += OnSetTriggerAnim;
            Events.MasterClientSwitched += OnMasterClientSwitched;

            _networkManager = NetworkManager.Instance;
        }

        private void Start()
        {
            if (!_networkManager.IsMasterClient) return;

            _currentState = new IdleState(_npc, _agent, _animator, _visObstacleLayers);
            _enebleAI = true;
        }

        private void OnDestroy()
        {
            Events.SetEnemyTriggerAnim -= OnSetTriggerAnim;
            Events.MasterClientSwitched -= OnMasterClientSwitched;
        }

        private void Update()
        {
            if (_enebleAI == false) return;

            _currentState = _currentState.Process(); // Process enemy AI States
        }
        #endregion

        void OnSetTriggerAnim(TriggerAnimType triggerAnim)
        {
            _animator.ResetTrigger(_currentTriggerAnim.ToString());
            _animator.SetTrigger(triggerAnim.ToString());
            _currentTriggerAnim = triggerAnim;
        }

        void OnMasterClientSwitched(int actorNumber)
        {
            bool isThisClient = actorNumber == _networkManager.OwnActorNumber;

            if (isThisClient)
            {
                _currentState = new IdleState(_npc, _agent, _animator, _visObstacleLayers);
                _enebleAI = true;
            }
        }
    }
}

