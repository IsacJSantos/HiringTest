using UnityEngine;
using UnityEngine.AI;
using HiringTest.Utils;

namespace HiringTest
{
    public class AttackState : State
    {
        float _attackDelay = 2f;
        float _time;
        bool _canAttack = false;

        NetworkManager _networkManager = NetworkManager.Instance;
        PlayerManager _player;
        public AttackState(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers, Transform playerTransform)
            : base(npc, agent, anim, viewObstacleLayers)
        {
            StateName = StateType.ATTACK;
            if (playerTransform.gameObject.activeSelf == true) 
            {
                _player = playerTransform.GetComponent<PlayerManager>();
                _networkManager.CallPlayerCapturedRPC(_player.ActorNumber);
                _canAttack = true;
            }
           
        }

        public override void Enter()
        {
            if (_canAttack)
            {
                _time = Time.time + _attackDelay;
                _networkManager.CallEnemyTriggerAnimRPC(TriggerAnimType.Attack);
            }
            
            base.Enter();
        }

        public override void Update()
        {
            if (!_canAttack) 
            {
                _nextState = new IdleState(_npc, _agent, _anim, _viewObstacleLayers);
                _stage = StateEventType.EXIT;
            }
            else if (Time.time >= _time)
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
