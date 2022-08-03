using UnityEngine;
using UnityEngine.AI;
using HiringTest.Utils;


namespace HiringTest
{
    public class PursueState : State
    {
        float _pursueSpeed = 2.5f;
        public PursueState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers, Transform target)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = StateType.PURSUE;
            _target = target;
        }

        public override void Enter()
        {
            _agent.speed = _pursueSpeed;
            _agent.SetDestination(_target.position);
            _agent.isStopped = false;
            NetworkManager.Instance.CallEnemyTriggerAnim(TriggerAnimType.Run);
            base.Enter();
        }

        public override void Update()
        {
            if (LoseTarget()) // Go to Patrol State
            {
                _nextState = new PatrolState(_npc, _agent, _anim, _viewObstacleLayers);
                _stage = StateEventType.EXIT;
            }
            else if (IsInDestination())// Go to Attack State
            {
                _nextState = new AttackState(_npc, _agent, _anim, _viewObstacleLayers, _target);
                _stage = StateEventType.EXIT;
            }
            else
                _agent.SetDestination(_target.transform.position);

            base.Update();
        }

        public override void Exit()
        {
            _agent.isStopped = true;
            base.Exit();
        }
    }
}

