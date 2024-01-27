using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class IceTrapState : TrapStateBase
  {
    [SerializeField]
    private GameObject _ice;

    private void T(bool state) => 
      _ice.SetActive(state);
    

        protected override void OnTrapStart()
        {
            _animator.PlayOnIceTrap();

            T(true);
        }

        protected override void OnTrapEnd()
        {
            T(false);
        }
    }
}