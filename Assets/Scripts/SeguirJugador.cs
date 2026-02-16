using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // Referencia al objeto del jugador

    public float velocidad = 5f; // Velocidad de movimiento del enemigo

    // Update se llama una vez por fotograma
    void Update()
    {
        // Si la referencia al objeto del jugador es nula, salir
        if (jugador == null)
            return;

        // Calcular la dirección del movimiento
        Vector3 direccion = jugador.position - transform.position;
        //direccion.y = 0f;
        direccion.Normalize();

        // Mover al enemigo hacia la posición del jugador
        transform.position += direccion * velocidad * Time.deltaTime;
    }
}
