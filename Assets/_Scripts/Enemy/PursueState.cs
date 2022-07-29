using UnityEngine;
using UnityEngine.AI;

namespace BraveHunterGames
{
    public class PursueState : State
    {
        Transform _playerTransform;
        public PursueState(GameObject npc, NavMeshAgent agent, Animator anim, Transform playerTransform) : base(npc, agent, anim)
        {
            StateName = STATE.PURSUE;
            _playerTransform = playerTransform;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            int aux = Random.Range(0, 101);
            if (aux == 1) // Go to Patrol State
            {
                _nextState = new PatrolState(_npc, _agent, _anim);
                _stage = EVENT.EXIT;
            }
            else if(aux == 2)// Go to Attack State
            {
                _nextState = new AttackState(_npc, _agent, _anim, null /*Temp null*/);
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

