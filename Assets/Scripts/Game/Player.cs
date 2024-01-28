using EnemyLogic;
using EnemyLogic.UI;
using JewelLogic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public float speed = 5f;
    public float rotSpd = 5f;

    public Animator animator;
    public Rigidbody rb;

    public Timer timer;
    public ActionProgressBar progress;

    private Quaternion trot;

    public Camera camera;

    void FixedUpdate()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        rb.position += (movement);

        if (movement != Vector3.zero)
        {
            trot = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.RotateTowards(transform.rotation, trot, rotSpd * Time.deltaTime);
        }

        animator.SetFloat("MoveSpeed", movement.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        var jewel = other.GetComponentInParent<Jewel>();
        if (jewel != null && jewel.IsDropped)
        {
            progress.Toggle(true);
            jewel.StartPickingUp();
            timer.Play(1, () => { jewel.Return(); progress.Toggle(false); }, () => progress.SetValue(timer.NormalizedTime));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        var jewel = other.GetComponentInParent<Jewel>();
        if (jewel != null)
        {
            timer.Stop();
            progress.Toggle(false);
        }
    }
}
