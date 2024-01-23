using UnityEngine;

namespace EnemyLogic
{
  [RequireComponent(typeof(EnemyMovement), typeof(EnemyJewelDetector))]
  public class EnemyJewelPickUp : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private EnemyMovement _movement;

    [SerializeField, HideInInspector]
    private EnemyJewelDetector _jewelDetector;

    private void OnEnable() => 
      _movement.OnTargetReached += PickUp;

    private void OnDisable() => 
      _movement.OnTargetReached -= PickUp;
    
    private void PickUp()
    {
      _movement.OnTargetReached -= PickUp;

      _jewelDetector.DisableDetection();
      _jewelDetector.CurrentTargetJewel.PickUp();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_movement == null)
        TryGetComponent(out _movement);

      if (_jewelDetector == null)
        TryGetComponent(out _jewelDetector);
    }
#endif
  }
}