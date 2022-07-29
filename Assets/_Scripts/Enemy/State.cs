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

        float _visDist = 10;
        float _visAngle = 30;
        float _attackDist = 7;

        public State(GameObject npc, NavMeshAgent agent, Animator anim)
        {
            _stage = EVENT.ENTER;
            _npc = npc;
            _anim = anim;
            _agent = agent;
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
    }
}

