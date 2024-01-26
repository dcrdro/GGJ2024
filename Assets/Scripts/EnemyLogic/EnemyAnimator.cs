using UnityEngine;

namespace EnemyLogic
{
  public class EnemyAnimator : MonoBehaviour
  {
    [SerializeField]
    private Animator _animator;

    public void ToggleMovement(bool state) => 
      _animator.SetBool("Movement", state);

    public void PlayCrashing() => 
      _animator.SetTrigger("CrashingTrigger");

    public void PlayPickUp(float pickUpSpeed)
    {
      _animator.SetFloat("PickUpSpeed", pickUpSpeed);
      _animator.SetTrigger("PickUpTrigger");
    }

    public void LockAction(bool state) => 
      _animator.SetBool("LockAction", state);

    public void PlayOnFireTrap() => 
      _animator.SetTrigger("OnFireTrap");
  }
}