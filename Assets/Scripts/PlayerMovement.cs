using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 12f;
    public float Gravity = -9.81f;
    public float JumpHeight = 3.0f;

    private Vector3 _velocity;

    // Update is called once per frame
    public void Update()
    {
        // If on the ground - reset velocity.
        if (Controller.isGrounded)
            _velocity.y = -2f;
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        // Jump.
        if (Input.GetButtonDown("Jump"))    //ToDo: remove double+ jump.
            _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);

        _velocity.y += Gravity * Time.deltaTime;
        Controller.Move(_velocity * Time.deltaTime);
    }
}