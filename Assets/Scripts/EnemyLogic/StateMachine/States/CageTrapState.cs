using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class CageTrapState : TrapStateBase
  {
    [SerializeField]
    private GameObject cage;

        private Vector3 pos;

    private void T(bool state) =>
      cage.SetActive(state);
    

        protected override void OnTrapStart()
        {
            pos = cage.transform.position;
            _animator.PlayOnCageTrap();

            T(true);
        }

        protected override void OnTrapEnd()
        {
            T(false);
            cage.transform.position = pos;
        }
    }
}