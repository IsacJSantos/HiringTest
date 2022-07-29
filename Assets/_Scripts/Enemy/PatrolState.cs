using UnityEngine.AI;
using UnityEngine;

namespace BraveHunterGames
{
    public class PatrolState : State
    {
        float _patrolSpeed = 2;
        public PatrolState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = STATE.PATROL;
        }

        public override void Enter()
        {
            _agent.SetDestination(GameManager.Instance.GetRandomEnemyCheckPos());
            _agent.speed = _patrolSpeed;
            _agent.isStopped = false;
            _anim.SetTrigger("Walk");
            base.Enter();
        }

        public override void Update()
        {
            if (IsLookingAtTarget()) // Go to Pursue State
            {
                _nextState = new PursueState(_npc, _agent, _anim, _viewObstacleLayers, _target);
                _stage = EVENT.EXIT;
            }
            else if (Random.Range(0, 2000) <= 1)// Go to Idle State
            {
                _nextState = new IdleState(_npc, _agent, _anim, _viewObstacleLayers);
                _stage = EVENT.EXIT;
            }
            else if (IsInDestination())
            {
                _agent.SetDestination(GameManager.Instance.GetRandomEnemyCheckPos());
            }
            base.Update();
        }

        public override void Exit()
        {
            _anim.ResetTrigger("Walk");
            base.Exit();
        }


    }
}

