using UnityEngine.AI;
using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class IdleState : State
    {

        public IdleState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = StateType.IDLE;
        }

        public override void Enter()
        {
            _agent.isStopped = true;
            NetworkManager.Instance.CallEnemyTriggerAnimRPC(TriggerAnimType.Idle);
            base.Enter();
        }

        public override void Update()
        {
            if (IsLookingAtTarget()) // Checks if this enemy has seen a player
            {
                _nextState = new PursueState(_npc, _agent, _anim, _viewObstacleLayers, _target);
                _stage = StateEventType.EXIT;
            }
            else if (Random.Range(0, 1500) <= 5) // Go randomly to Patrol State
            {
                _nextState = new PatrolState(_npc, _agent, _anim, _viewObstacleLayers);
                _stage = StateEventType.EXIT;
            }
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}

