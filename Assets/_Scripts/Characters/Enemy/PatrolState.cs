using UnityEngine.AI;
using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class PatrolState : State
    {
        float _patrolSpeed = 1.5f;
        public PatrolState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = StateType.PATROL;
        }

        public override void Enter()
        {
            _agent.SetDestination(GameManager.Instance.GetRandomEnemyCheckPos());
            _agent.speed = _patrolSpeed;
            _agent.isStopped = false;
            NetworkManager.Instance.CallEnemyTriggerAnimRPC(TriggerAnimType.Walk);
            base.Enter();
        }

        public override void Update()
        {
            if (IsLookingAtTarget()) // Go to Pursue State
            {
                _nextState = new PursueState(_npc, _agent, _anim, _viewObstacleLayers, _target);
                _stage = StateEventType.EXIT;
            }
            else if (Random.Range(0, 2000) <= 1)// Go to Idle State
            {
                _nextState = new IdleState(_npc, _agent, _anim, _viewObstacleLayers);
                _stage = StateEventType.EXIT;
            }
            else if (IsInDestination())
            {
                _agent.SetDestination(GameManager.Instance.GetRandomEnemyCheckPos());
            }
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }


    }
}

