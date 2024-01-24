using UnityEngine;

namespace Utilities
{
  public class LookAtCamera : MonoBehaviour
  {
    #region Fields

    private Camera _mainCamera;

    #endregion

    private void Awake() =>
      _mainCamera = Camera.main;

    public void Update() => 
      Rotate();

    private void Rotate()
    {
      Vector3 direction = (_mainCamera.transform.position - transform.position).normalized;
      Quaternion lookRotation = Quaternion.LookRotation(direction);

      transform.rotation = Quaternion.Euler(lookRotation.eulerAngles.x, 0, 0);
    }
  }
}