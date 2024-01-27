using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera camera;
    public Transform target;

    public Vector3 offset;
    private float x;

    private void Awake()
    {
        offset = transform.localPosition;
        x = camera.transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        camera.transform.position= target.position + offset;
        camera.transform.rotation = Quaternion.Euler(x, 0f, 0f);
    }

}
