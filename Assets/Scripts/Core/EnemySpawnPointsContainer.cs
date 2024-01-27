using JewelLogic;
using System.Linq;
using UnityEngine;

namespace Core
{
  public class EnemySpawnPointsContainer : MonoBehaviour
  {
    public static EnemySpawnPointsContainer Instance;
    
    [SerializeField]
    private Transform[] _spawnPoints;

    #region Properties

    public Transform this[int index] => _spawnPoints[index];
        public int Length => _spawnPoints.Length;


    public int EscapedCount { get; set; }

        #endregion

        private void Awake()
        {
            _spawnPoints = GetComponentsInChildren<Transform>().ToArray();
            Instance = this;
        }
    }
}