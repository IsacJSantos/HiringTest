using UnityEngine;
using UnityEngine.AI;

namespace BraveHunterGames
{
    public class AttackState : State
    {
        Transform _playerTransform;
        public AttackState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers, Transform playerTransform)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = STATE.ATTACK;
            _playerTransform = playerTransform;
        }

        public override void Enter()
        {
            _anim.SetTrigger("Attack");
            base.Enter();
        }

        public override void Update()
        {
            _nextState = new IdleState(_npc, _agent, _anim, _viewObstacleLayers);
            _stage = EVENT.EXIT;

            base.Update();
        }

        public override void Exit()
        {
            _anim.ResetTrigger("Attack");
            base.Exit();
        }

    }
}
