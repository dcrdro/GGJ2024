using System;
using Core;
using UnityEngine;

namespace JewelLogic
{
  public class Jewel : MonoBehaviour
  {
    #region Actions

    public event Action OnPickedUp;

    #endregion
    
    #region Properties

    public Vector3 Position => transform.position;

    #endregion

    public void PickUp()
    {
      gameObject.SetActive(false);
      
      JewelsContainer.Instance.Remove(this);
      OnPickedUp?.Invoke();
    }
  }
}