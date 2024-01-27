using System.Collections;
using UnityEngine;

public class WorldCamera: MonoBehaviour
{
    public Camera camera;
    public Transform target;
    public Vector3 maxDist;
    public float maxOffset;


    private Vector3 offset;
    private Vector3 initTargetPos;



    private void Awake()
    {
        offset = transform.position;
    }

    private void Start()
    {
        initTargetPos = target.position;
    }

    private void LateUpdate()
    {
        var x = Mathf.InverseLerp(-maxDist.x, maxDist.x, target.position.x - initTargetPos.x);
        var z = Mathf.InverseLerp(-maxDist.z, maxDist.z, target.position.z - initTargetPos.z);

        var vx = Mathf.Lerp(-maxOffset, maxOffset, x);
        var vz = Mathf.Lerp(-maxOffset, maxOffset, z);

        camera.transform.position = offset + new Vector3(vx, 0, vz);
    }

}
