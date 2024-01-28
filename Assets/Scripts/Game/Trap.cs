﻿using EnemyLogic.StateMachine;
using EnemyLogic.StateMachine.States;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public string AnimationParameter;
    public float animationTime;

    public Image icon;
    public int damage;

    public TrapType TrapType;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out EnemyStateMachine stateMachine))
        {
            // FindObjectOfType<AudioManager>().PlayTrapCatch();

            var delay = 0;
            switch (TrapType)
            {
                case TrapType._TestTrap1:
                    break;
                case TrapType.Fire:
                    stateMachine.Enter<FireTrapState, float>(damage);
                    delay = 0;
                    break;
                case TrapType.Ice:
                    stateMachine.Enter<IceTrapState, float>(damage);
                    delay = 0;

                    break;
                case TrapType.Cage:
                    stateMachine.Enter<CageTrapState, float>(damage);
                    delay = 1;

                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }

}
