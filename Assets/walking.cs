using UnityEngine;

public class RigidbodyPlayer : MonoBehaviour
{
    public float speed = 25f;
    public float jumpForce = 25f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Evita que el cubo se caiga o gire
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Movimiento con WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z) * speed;

        // Mantiene la velocidad vertical (para gravedad/salto)
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Detecta si está tocando el suelo
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}