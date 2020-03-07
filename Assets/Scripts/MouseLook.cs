
using UnityEngine;

namespace Assets.Scripts
{
    public class MouseLook : MonoBehaviour
    {
        public float Sensitivity = 300f;
        public Transform PlayerBody;

        private float _xRotation = 0f;

        // Start is called before the first frame update
        public void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        public  void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, +90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

            PlayerBody.Rotate(Vector3.up, mouseX);
        }
    }
}