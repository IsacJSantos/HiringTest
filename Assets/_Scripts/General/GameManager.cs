using System.Collections.Generic;
using UnityEngine;
using BraveHunterGames.Utils;

namespace BraveHunterGames
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] Transform[] _enemyCheckPoints;
        [SerializeField] string _enemyPrefabRef;
        #region MonoBehaviour Callbacks
        private void Start()
        {
            if (!NetworkManager.Instance.IsMasterClient) return;

            NetworkManager.Instance.InstantiateNetworkObject(_enemyPrefabRef, _enemyCheckPoints[0].position);
        }
        #endregion
        public Vector3 GetRandomEnemyCheckPos()
        {
            int index = Random.Range(0, _enemyCheckPoints.Length);
            return _enemyCheckPoints[index].position;
        }
    }
}

