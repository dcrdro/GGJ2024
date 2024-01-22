using Core;
using UnityEngine;

namespace EnemyLogic
{
  public class EnemySpawnPoint : MonoBehaviour
  {
    [SerializeField]
    private float _timeToSpawn;

    #region Fields

    private float _currentTime;

    #endregion

    private void Awake() => 
      _currentTime = _timeToSpawn;

    private void Update()
    {
      _currentTime -= Time.deltaTime;
      if (_currentTime <= 0)
      {
        SpawnEnemy();
        enabled = false;
      }
    }

    private void SpawnEnemy()
    {
      Debug.Log($"{gameObject.name}: Spawn enemy");

      GameObject prefab = PrefabsProvider.Instance.EnemyPrefab;
      Transform container = ContainersProvider.Instance.EnemiesContainer;
      
      Instantiate(prefab, transform.position, Quaternion.identity, container);
    }
  }
}