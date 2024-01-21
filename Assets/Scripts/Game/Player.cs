using UnityEngine;

public class Player: MonoBehaviour
{
    public float speed = 5f;
    public float rotSpd = 5f;

    private Quaternion trot;

    void Update()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        transform.position += (movement);

        if (movement != Vector3.zero)
        {
            trot = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, trot, rotSpd * Time.deltaTime);
        }
    }
}
