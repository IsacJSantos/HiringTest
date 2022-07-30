using Cinemachine;
using UnityEngine;
using BraveHunterGames.Utils;

namespace BraveHunterGames
{
    public class GameManager : Singleton<GameManager>
    {

        [SerializeField] Transform[] _enemyCheckPoints;
        [SerializeField] Transform[] _playerSpawnPoints;
        [SerializeField] Transform _camTransform;
        [SerializeField] CinemachineVirtualCamera _vCam;

        [SerializeField] string _playerPrefabRef;
        [SerializeField] string _enemyPrefabRef;

        #region MonoBehaviour Callbacks
        private void Start()
        {
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
            if (NetworkManager.Instance.IsMasterClient)
                NetworkManager.Instance.InstantiateNetworkObject(_enemyPrefabRef, _enemyCheckPoints[0].position);
        }
        void SpawnPlayer() 
        {
            Vector3 playerSpawnPos = _playerSpawnPoints[NetworkManager.Instance.OwnActorNumber - 1].position;
            PlayerController playerController = NetworkManager.Instance.InstantiateNetworkObject(_playerPrefabRef, playerSpawnPos).GetComponent<PlayerController>();
            if (playerController != null) 
            {
                _vCam.Follow = playerController.HeadTransform;
                playerController.Init(_camTransform, NetworkManager.Instance.OwnActorNumber);
            }
        }
    }
}

