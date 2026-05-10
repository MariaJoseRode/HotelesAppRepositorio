using UnityEngine;
using TMPro;

public class BotonHotel : MonoBehaviour
{
    private string nombre;
    private string descripcion;
    private string precio;

    
    public void Configurar(string n, string d, string p)
    {
        nombre = n;
        descripcion = d;
        precio = p;
    }

    public void OnClickDetalles()
    {
        
        Debug.Log("Mostrando detalles de: " + nombre);

       
    }
}