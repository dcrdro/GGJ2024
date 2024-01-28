using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class EnemiesDiedCounter : MonoBehaviour
  {
    public static EnemiesDiedCounter Instance;
    
    [SerializeField]
    private Text _counter;

    #region Fields

    private float _diedEnemiesCount;
    private float _maxEnemiesCount;

    #endregion
    
    private void Awake() => 
      Instance = this;

    public void Initialize()
    {
      _maxEnemiesCount = EnemySpawnPointsContainer.Instance.Length;
      UpdateText();
    }

    public void IncreaseDiedEnemiesCount()
    {
      _diedEnemiesCount++;
      UpdateText();
    }
    
    public void UpdateText() => 
      _counter.text = $"{_diedEnemiesCount}/{_maxEnemiesCount}";
  }
}