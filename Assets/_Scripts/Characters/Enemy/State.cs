using UnityEngine.AI;
using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class State
    {
        public StateType StateName;
        protected StateEventType _stage;
        protected GameObject _npc;
        protected Animator _anim;
        protected State _nextState;
        protected NavMeshAgent _agent;
        protected Transform _target;
        protected LayerMask _viewObstacleLayers; // Layers that cover the AI's view

        float _viewRadius = 7.5f;
        float _viewDistance = 8f;
        float _viewAngle = 85;
        int _targetLayerMask = 3;

        float _viewDelay = 0.5f; // Frequency at which the enemy's vision is updated
        float _time;

        public State(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers)
        {
            _stage = StateEventType.ENTER;
            _npc = npc;
            _anim = anim;
            _agent = agent;
            _viewObstacleLayers = viewObstacleLayers;
        }

        public State Process()
        {
            if (_stage == StateEventType.ENTER)
                Enter();
            else if (_stage == StateEventType.UPDATE)
                Update();
            else if (_stage == StateEventType.EXIT)
            {
                Exit();
                return _nextState;
            }

            return this;
        }

        #region Event Methods
        public virtual void Enter()
        {
            _stage = StateEventType.UPDATE;
            NetworkManager.Instance.CallEnemyInitStateRPC(StateName);
        }
        public virtual void Update() { }
        public virtual void Exit() { _stage = StateEventType.EXIT; }

        #endregion


        public bool IsLookingAtTarget()
        {
            if (Time.time < _time) return false;
            _time = Time.time + _viewDelay;

            Transform[] targets = GetTargetInArea();

            if (targets == null || targets.Length < 1) return false;

            foreach (Transform target in targets)
            {
                if (IsInAngle(target.position))
                {
                    if (!HasObstacle(target.position))
                    {
                        _target = target;
                        return true;
                    }
                }
            }

            return false;

        }

        public bool IsInDestination()
        {
            return Vector3.Distance(_npc.transform.position, _agent.destination) <= _agent.stoppingDistance;
        }

        public bool LoseTarget()
        {
            return Vector3.Distance(_npc.transform.position, _target.position) > _viewDistance;
        }



        Transform[] GetTargetInArea()
        {
            int maxOfColliders = 2;
            Collider[] hitColliders = new Collider[maxOfColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(_npc.transform.position, _viewRadius, hitColliders, 1 << _targetLayerMask);

            if (numColliders > 0)
            {
                Transform[] transforms = new Transform[numColliders];
                for (int i = 0; i < numColliders; i++)
                {
                    transforms[i] = hitColliders[i].transform;
                }
                return transforms;
            }
            else return null;
        }

        bool IsInAngle(Vector3 targetPos)
        {
            Vector3 targetDir = targetPos - _npc.transform.position;
            return Vector3.Angle(targetDir, _npc.transform.forward) <= _viewAngle;
        }

        bool HasObstacle(Vector3 targetPos) // Checks if there is obstacle btw the enemy and the player
        {
            Vector3 direction = targetPos - _npc.transform.position;
            float distance = Vector3.Distance(targetPos, _npc.transform.position);

            return Physics.Raycast(_npc.transform.position, direction, distance, _viewObstacleLayers);
        }
    }
}

