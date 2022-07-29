using UnityEngine.AI;
using UnityEngine;

namespace BraveHunterGames
{
    public class State
    {
        public enum STATE
        {
            IDLE, PATROL, PURSUE, ATTACK
        }

        public enum EVENT
        {
            ENTER, UPDATE, EXIT
        }

        public STATE StateName;
        protected EVENT _stage;
        protected GameObject _npc;
        protected Animator _anim;
        protected State _nextState;
        protected NavMeshAgent _agent;
        protected Transform _target;
        protected LayerMask _viewObstacleLayers; // Layers that cover the AI's view

        float _viewRadius = 10;
        float _viewDistance = 10;
        float _viewAngle = 30;
        int _targetLayerMask = 3;
        RaycastHit _rayHit;

        public State(GameObject npc, NavMeshAgent agent, Animator anim, LayerMask viewObstacleLayers)
        {
            _stage = EVENT.ENTER;
            _npc = npc;
            _anim = anim;
            _agent = agent;
            _viewObstacleLayers = viewObstacleLayers;
        }

        public virtual void Enter() { _stage = EVENT.UPDATE; }
        public virtual void Update() { Debug.Log("Process State: " + StateName);/*Temp Log*/ }
        public virtual void Exit() { _stage = EVENT.EXIT; }

        public State Process()
        {
            if (_stage == EVENT.ENTER)
                Enter();
            else if (_stage == EVENT.UPDATE)
                Update();
            else if (_stage == EVENT.EXIT)
            {
                Exit();
                return _nextState;
            }

            return this;
        }

        public bool IsLookingAtTarget()
        {
            Transform targetTrans = GetTargetInArea();

            if (targetTrans == null) return false;

            if (IsInAngle(targetTrans.position))
            {
                if (!HasObstacle(targetTrans.position))
                {
                    _target = targetTrans;
                    return true;
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

        Transform GetTargetInArea()
        {
            Collider[] colliders = Physics.OverlapSphere(_npc.transform.position, _viewRadius);
            if (colliders == null || colliders.Length < 1)
            {
                return null;
            }

            foreach (var col in colliders)
            {
                if (col.gameObject.layer == _targetLayerMask)
                    return col.transform;
            }

            return null;
        }

        bool IsInAngle(Vector3 targetPos)
        {
            Vector3 targetDir = targetPos - _npc.transform.position;
            return Vector3.Angle(targetDir, _npc.transform.forward) <= _viewAngle;

        }

        bool HasObstacle(Vector3 targetPos)
        {
            Vector3 direction = targetPos - _npc.transform.position;
            float distance = Vector3.Distance(targetPos, _npc.transform.position);
            if (Physics.Raycast(_npc.transform.position, direction, out _rayHit, distance, _viewObstacleLayers))
            {
                Debug.Log(_rayHit.collider.name);
                return true;
            }
            return false;

        }
    }
}

