using UnityEngine;
using UnityEngine.AI;
using HiringTest.Utils;

namespace HiringTest
{
    public class AttackState : State
    {
        float _attackDelay = 2f;
        float _time;
        NetworkManager _networkManager = NetworkManager.Instance;
        PlayerController _player;
        public AttackState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers, Transform playerTransform)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = StateType.ATTACK;
            _player = playerTransform.GetComponent<PlayerController>();
            _networkManager.CallPlayerCapturedRPC(_player.ActorNumber);
        }

        public override void Enter()
        {
            _time = Time.time + _attackDelay;
            _networkManager.CallEnemyTriggerAnimRPC(TriggerAnimType.Attack);
            base.Enter();
        }

        public override void Update()
        {
            if (Time.time >= _time)
            {
                _nextState = new IdleState(_npc, _agent, _anim, _viewObstacleLayers);
                _networkManager.CallPlayerLoseRPC(_player.ActorNumber);
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
