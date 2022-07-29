using System.Collections.Generic;
using UnityEngine;
using BraveHunterGames.Utils;

namespace BraveHunterGames 
{
    public class GameManager : Singleton<GameManager> 
    {
        [SerializeField] Transform[] _enemyCheckPoints;

        #region MonoBehaviour Callbacks
        
        #endregion
        public Vector3 GetRandomEnemyCheckPos() 
        {
            int index = Random.Range(0, _enemyCheckPoints.Length);
            return _enemyCheckPoints[index].position;
        }
    }
}

