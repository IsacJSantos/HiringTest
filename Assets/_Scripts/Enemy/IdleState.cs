using UnityEngine.AI;
using UnityEngine;

namespace BraveHunterGames
{
    public class IdleState : State
    {

        public IdleState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers) : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = STATE.IDLE;
        }

        public override void Enter()
        {
            _agent.isStopped = true;
            // _anim.SetTrigger("Idle");
            base.Enter();
        }

        public override void Update()
        {
            if (IsLookingAtTarget()) // Go to pursue state
            {
                _nextState = new PursueState(_npc, _agent, _anim,_viewObstacleLayers, _target);
                _stage = EVENT.EXIT;
            }
            else if(Random.Range(0, 2000) <= 5)// Go to Patrol State
            {
                _nextState = new PatrolState(_npc, _agent, _anim, _viewObstacleLayers);
                _stage = EVENT.EXIT;
            }
            base.Update();
        }

        public override void Exit()
        {
            // _anim.ResetTrigger("Idle");
            base.Exit();
        }

    }
}

