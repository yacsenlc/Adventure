// Universidad Estatal a Distancia
// Unity- Videojuego Adventure
// Autor: Yacsen Lopez Cambronero

using UnityEngine;
using UnityEngine.InputSystem;

public class jugador1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool enSuelo = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // =========================
        // TECLADO
        // =========================

        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Keyboard.current.aKey.isPressed)
            moveHorizontal = -1f;

        if (Keyboard.current.dKey.isPressed)
            moveHorizontal = 1f;

        if (Keyboard.current.wKey.isPressed)
            moveVertical = 1f;

        if (Keyboard.current.sKey.isPressed)
            moveVertical = -1f;


        // =========================
        // TECLADO - FLECHAS
        // =========================

        if (Keyboard.current.leftArrowKey.isPressed)
            moveHorizontal = -1f;

        if (Keyboard.current.rightArrowKey.isPressed)
            moveHorizontal = 1f;

        if (Keyboard.current.upArrowKey.isPressed)
            moveVertical = 1f;

        if (Keyboard.current.downArrowKey.isPressed)
            moveVertical = -1f;

        // =========================
        // CONTROL XBOX
        // =========================

        if (Gamepad.current != null)
        {
            Vector2 stick = Gamepad.current.leftStick.ReadValue();

            // El control reemplaza al teclado
            if (stick.x != 0)
                moveHorizontal = stick.x;

            if (stick.y != 0)
                moveVertical = stick.y;
        }


        // =========================
        // MOVIMIENTO
        // =========================

        Vector3 movement = new Vector3(
            moveHorizontal * speed,
            rb.linearVelocity.y,
            moveVertical * speed
        );

        rb.linearVelocity = movement;


        // =========================
        // SALTO
        // =========================

        bool saltarTeclado = Keyboard.current.spaceKey.wasPressedThisFrame;

        bool saltarXbox = false;

        if (Gamepad.current != null)
        {
            saltarXbox = Gamepad.current.buttonSouth.wasPressedThisFrame;
        }

        if ((saltarTeclado || saltarXbox) && enSuelo)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enSuelo = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }
}
