using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float speed = 10f;
    public float mouseSensitivity = 2f;
    public float verticalSpeed = 5f;

    float rotationX = 0f;

    void Update()
    {
        // Rotación con mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);

        // Movimiento WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z + transform.right * x;

        // Subir y bajar
        if (Input.GetKey(KeyCode.E))
            move += Vector3.up;
        if (Input.GetKey(KeyCode.Q))
            move += Vector3.down;

        transform.parent.position += move * speed * Time.deltaTime;
    }
}