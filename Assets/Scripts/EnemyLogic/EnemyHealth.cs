using UnityEngine;

namespace EnemyLogic
{
  public class EnemyHealth : MonoBehaviour
  {
    [SerializeField]
    private int _health;

    [SerializeField, HideInInspector]
    private EnemyMovement _movement;
    
    #region Properties

    public bool IsDied => _currentHealth <= 0;

    #endregion
    
    #region Fields

    private int _currentHealth;

    #endregion

    private void Awake()
    {
      _currentHealth = _health;
    }

    public void TakeDamage(int value)
    {
      _currentHealth -= value;

      if (IsDied) 
        _movement.SetSpeed(_movement.CurrentSpeed * 3);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_movement == null)
        TryGetComponent(out _movement);
    }
#endif
  }
}