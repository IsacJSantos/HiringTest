using UnityEngine.AI;
using UnityEngine;

namespace BraveHunterGames
{
    public class IdleState : State
    {

        public IdleState(GameObject npc, NavMeshAgent agent, Animator anim) : base(npc, agent, anim)
        {
            StateName = STATE.IDLE;
        }

        public override void Enter()
        {
            // _anim.SetTrigger("Idle");
            base.Enter();
        }

        public override void Update()
        {
            int aux = Random.Range(0, 101);
            if (aux == 1) // Go to pursue state
            {
                _nextState = new PursueState(_npc, _agent, _anim, null/*Temp null*/);
                _stage = EVENT.EXIT;
            }
            else if(aux == 2)// Go to Patrol State
            {
                _nextState = new PatrolState(_npc, _agent, _anim);
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

