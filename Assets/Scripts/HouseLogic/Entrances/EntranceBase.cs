using System;
using EnemyLogic;
using UnityEngine;
using UnityEngine.AI;

namespace HouseLogic.Entrances
{
  public abstract class EntranceBase : MonoBehaviour
  {
    [SerializeField]
    private float _delayBeforeLock;
    
    [SerializeField]
    private GameObject _body;

    [SerializeField]
    private Transform _outsidePoint;

    [SerializeField]
    private Transform _insidePoint;

    [SerializeField]
    private Timer _timer;
    
    public NavMeshObstacle[] obstacles;

    #region Actions

    public event Action OnUnlocked;

    #endregion

    #region Properties

    public Vector3 OutsidePoint => _outsidePoint.position;
    public Vector3 InsidePoint => _insidePoint.position;

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
      _timer.Play(_delayBeforeLock, Lock);
      
      _body.SetActive(false);
      foreach (var obstacle in obstacles)
      {
        obstacle.enabled = false;
      }

      _isAlreadyUnlocking = false;
      _isUnlocked = true;

      OnUnlocked?.Invoke();
    }

    [ContextMenu("Close")]
    public void Lock()
    {
      _body.SetActive(true);
      _isUnlocked = false;
            foreach (var obstacle in obstacles)
            {
                obstacle.enabled = true;
            }
        }
  }
}