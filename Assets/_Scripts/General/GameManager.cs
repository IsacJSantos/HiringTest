using Cinemachine;
using UnityEngine;
using HiringTest.Utils;

namespace HiringTest
{
    public class GameManager : Singleton<GameManager>
    {

        [SerializeField] Transform[] _enemyCheckPoints;
        [SerializeField] Transform[] _playerSpawnPoints;
        [SerializeField] Transform _camTransform;
        [SerializeField] CinemachineVirtualCamera _vCam;

        [SerializeField] string _playerPrefabRef;
        [SerializeField] string _enemyPrefabRef;

        NetworkManager _networkManager;

        #region MonoBehaviour Callbacks
        private void Start()
        {
            _networkManager = NetworkManager.Instance;
            SpawnEnemy();
            SpawnPlayer();
        }
        #endregion


        public Vector3 GetRandomEnemyCheckPos()
        {
            int index = Random.Range(0, _enemyCheckPoints.Length);
            return _enemyCheckPoints[index].position;
        }

        void SpawnEnemy()
        {
            if (_networkManager.IsMasterClient)
                _networkManager.InstantiateNetworkObject(_enemyPrefabRef, _enemyCheckPoints[0].position);
        }

        void SpawnPlayer()
        {
            Vector3 playerSpawnPos = _playerSpawnPoints[_networkManager.OwnActorNumber - 1].position;
            PlayerManager playerManager = _networkManager.InstantiateNetworkObject(_playerPrefabRef, playerSpawnPos).GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                _vCam.Follow = playerManager.HeadTransform;
                playerManager.Init(_camTransform);
            }
        }

    }
}

