using UnityEngine;
using UnityEngine.AI;

namespace BraveHunterGames
{
    public class AttackState : State
    {
        Transform _playerTransform;
        public AttackState(GameObject npc, NavMeshAgent agent, Animator anim, Transform playerTransform)
            : base(npc, agent, anim)
        {
            StateName = STATE.ATTACK;
            _playerTransform = playerTransform;
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
            else 
            {
               //
            }

            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}
