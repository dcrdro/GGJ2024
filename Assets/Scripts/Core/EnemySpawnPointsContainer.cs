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

    #endregion

    private void Awake() => 
      Instance = this;
  }
}