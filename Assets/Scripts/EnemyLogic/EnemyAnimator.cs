using UnityEngine;

namespace EnemyLogic
{
  public class EnemyAnimator : MonoBehaviour
  {
    [SerializeField]
    private Animator _animator;

    public void ToggleMovement(bool state)
    {
      _animator.SetBool("Movement", state);
    }

    public void PlayCrashing()
    {
      _animator.SetTrigger("CrashingTrigger");
    }
  }
}