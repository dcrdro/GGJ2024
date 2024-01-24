using System;
using UnityEngine;

namespace HouseLogic.Entrances
{
  public abstract class EntranceBase : MonoBehaviour
  {
    [SerializeField]
    private GameObject _body;
    
    #region Actions

    public event Action OnUnlocked;

    #endregion
    
    #region Properties

    public Vector3 Position => transform.position;

    public bool IsAlreadyUnlocking => _isAlreadyUnlocking;
    public bool IsUnlocked => _isUnlocked;

    #endregion

    #region Fields

    private bool _isAlreadyUnlocking;
    private bool _isUnlocked;

    #endregion

    public void StartUnlocking() => 
      _isAlreadyUnlocking = true;

    public void Unlock()
    {
      _body.SetActive(false);
      
      _isAlreadyUnlocking = false;
      _isUnlocked = true;
      
      OnUnlocked?.Invoke();
    }

    public void Lock()
    {
      _body.SetActive(true);
      _isUnlocked = false;
    }
  }
}