using UnityEngine;
using UnityEngine.AI;
using HiringTest.Utils;

namespace HiringTest
{
    public class AttackState : State
    {
        Transform _playerTransform;
        public AttackState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers, Transform playerTransform)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = StateType.ATTACK;
            _playerTransform = playerTransform;
        }

        public override void Enter()
        {
            NetworkManager.Instance.CallEnemyTriggerAnim(TriggerAnimType.Attack);
            base.Enter();
        }

        public override void Update()
        {
            _nextState = new IdleState(_npc, _agent, _anim, _viewObstacleLayers);
            _stage = StateEventType.EXIT;

            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}
