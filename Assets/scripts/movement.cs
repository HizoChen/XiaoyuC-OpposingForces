using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
  
       
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
      
      
    }

    void FixedUpdate() 
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * moveZ + transform.right * moveX).normalized;

        rb.velocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.velocity.y, 
            moveDirection.z * moveSpeed
        );


    }



}
