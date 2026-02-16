using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f; // velocidad de movimiento del personaje

    // Update se llama una vez por fotograma
    void Update()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Calcular la dirección del movimiento
        Vector3 direccion = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        // Calcular la posición del personaje
        Vector3 posicionActual = transform.position;
        Vector3 nuevaPosicion = posicionActual + direccion * velocidad * Time.deltaTime;

        // Mover al personaje a la nueva posición
        transform.position = nuevaPosicion;

        // Obtener la entrada del teclado para moverse hacia arriba o hacia abajo
        float movimientoVertical2 = Input.GetAxisRaw("UpDown");

        // Calcular la dirección del movimiento vertical
        Vector3 direccionVertical = new Vector3(0f, movimientoVertical2, 0f).normalized;

        // Calcular la posición actual del personaje
        Vector3 posicionActualVertical = transform.position;
        Vector3 nuevaPosicionVertical = posicionActualVertical + direccionVertical * velocidad * Time.deltaTime;

        // Mover al personaje a la nueva posición vertical
        transform.position = nuevaPosicionVertical;
    }
}