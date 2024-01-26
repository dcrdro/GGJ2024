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
    public bool IsDropped { get; private set; }

        #endregion

        private Vector3 initPosition;

        private void Awake()
        {
            initPosition = transform.position;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }

        public void Drop()
        {
            gameObject.SetActive(true);
            transform.parent = null;
            IsDropped = true;
        }

        public void PickUp(Transform target)
    {
      gameObject.SetActive(false);
      transform.parent = target;
      
      JewelsContainer.Instance.Remove(this);
      OnPickedUp?.Invoke();
    }

        public void Return()
        {
            gameObject.SetActive(true);
            transform.parent = null;
            transform.position = initPosition;
            IsDropped = false;
        }
    }
}