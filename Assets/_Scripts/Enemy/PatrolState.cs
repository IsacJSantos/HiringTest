using UnityEngine.AI;
using UnityEngine;

namespace BraveHunterGames 
{
    public class PatrolState : State
    {
        public PatrolState(GameObject npc, NavMeshAgent agent, Animator anim)
            : base(npc, agent, anim) 
        {
            StateName = STATE.PATROL;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            int aux = Random.Range(0, 101);
            if (aux == 1) // Go to Pursue State
            {
                _nextState = new PursueState(_npc, _agent, _anim, null/*temp null*/);
                _stage = EVENT.EXIT;
            }
            else if (aux == 2)// Go to Idle State
            {
                _nextState = new IdleState(_npc, _agent, _anim);
                _stage = EVENT.EXIT;
            }
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

