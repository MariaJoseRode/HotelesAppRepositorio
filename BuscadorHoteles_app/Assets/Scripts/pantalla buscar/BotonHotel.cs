using UnityEngine;
using TMPro;

public class BotonHotel : MonoBehaviour
{
    private string nombre;
    private string descripcion;
    private string precio;

    // Esto lo usaremos para llenar los datos al crear la tarjeta
    public void Configurar(string n, string d, string p)
    {
        nombre = n;
        descripcion = d;
        precio = p;
    }

    public void OnClickDetalles()
    {
        // Por ahora lo mostramos en consola para probar
        Debug.Log("Mostrando detalles de: " + nombre);

        // Aquí es donde llamarías a tu panel de detalles
        // Ejemplo: PanelDetalles.instance.Mostrar(nombre, descripcion, precio);
    }
}