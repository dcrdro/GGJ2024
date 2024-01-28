using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Clown : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GetComponent<Animator>().SetTrigger("Out");
        }
    }
}