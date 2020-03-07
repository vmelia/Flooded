using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 12f;
    public float Gravity = -9.81f;

    private Vector3 _velocity;

    // Update is called once per frame
    public void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        _velocity.y += Gravity * Time.deltaTime;
        Controller.Move(_velocity * Time.deltaTime);

        if (Controller.transform.position.y <= 1.08f)
            _velocity = new Vector3();
    }
}