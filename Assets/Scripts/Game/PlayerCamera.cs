using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera camera;
    public Transform target;

    public Vector3 offset;

    private void Awake()
    {
        offset = transform.localPosition;
    }

    private void LateUpdate()
    {
        var x = camera.transform.eulerAngles.x;
        camera.transform.position= target.position + offset;
        camera.transform.rotation = Quaternion.Euler(x, 0f, 0f);
    }

}
