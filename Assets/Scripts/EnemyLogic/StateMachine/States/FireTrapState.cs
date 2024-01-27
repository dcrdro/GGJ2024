using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class FireTrapState : TrapStateBase
  {
    [SerializeField]
    private GameObject _fireEffectObject;

    private void ToggleFireEffect(bool state) => 
      _fireEffectObject.SetActive(state);
    

        protected override void OnTrapStart()
        {
            _animator.PlayOnFireTrap();

            ToggleFireEffect(true);
        }

        protected override void OnTrapEnd()
        {
            ToggleFireEffect(false);
        }
    }
}