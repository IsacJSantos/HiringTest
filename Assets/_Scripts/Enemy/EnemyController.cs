using UnityEngine;
using UnityEngine.AI;

namespace BraveHunterGames
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] NavMeshAgent _agent;
        [SerializeField] GameObject _npc;
        [SerializeField] Animator _animator;
        [SerializeField] State _currentState;
        [SerializeField] LayerMask _visObstacleLayers; // Layers that cover the enemy's view

        #region MonoBehabiour Callbacks

        private void Start()
        {
            _currentState = new IdleState(_npc,_agent,_animator,_visObstacleLayers);
        }

        private void Update()
        {
            _currentState = _currentState.Process();
        }
        #endregion


    }
}

