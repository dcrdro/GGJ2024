using System;
using EnemyLogic.UI;
using UnityEngine;

namespace EnemyLogic
{
  public class EnemyHealth : MonoBehaviour
  {
    [SerializeField]
    private int _health;

    [SerializeField, HideInInspector]
    private EnemyInterface _interface;

    [SerializeField, HideInInspector]
    private EnemyMovement _movement;
    
    #region Properties

    public bool IsDied => _currentHealth <= 0;

    private ActionProgressBar HealthProgressBar => _interface.HealthProgressBar;
    
    #endregion
    
    #region Fields

    private int _currentHealth;

    #endregion

    private void Awake() => 
      _currentHealth = _health;

    private void OnEnable()
    {
      if(!IsDied)
        HealthProgressBar.Toggle(true);
    }

    private void OnDisable() => 
      HealthProgressBar.Toggle(false);

    public void TakeDamage(int value)
    {
      _currentHealth -= value;

      HealthProgressBar.SetValue((float)_currentHealth / _health);

      if (IsDied)
      {
        HealthProgressBar.Toggle(false);
        _movement.SetSpeed(_movement.CurrentSpeed * 3);
      }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_movement == null)
        TryGetComponent(out _movement);

      if (_interface == null)
        TryGetComponent(out _interface);
    }
#endif
  }
}