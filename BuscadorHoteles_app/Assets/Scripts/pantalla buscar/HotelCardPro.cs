using UnityEngine;
using TMPro;
using UnityEngine.UI; // para usar el botón

public class HotelCard : MonoBehaviour
{
    public TextMeshProUGUI nombreHotel;
    public TextMeshProUGUI precioHotel;
    public TextMeshProUGUI descripcionHotel;
    public Button botonDetalles; 

    private int idHotelActual;

    public void RellenarDatosHotel(int id, string nombre, float precio, string descripcion)
    {
        idHotelActual = id;
        nombreHotel.text = nombre;
        precioHotel.text = precio.ToString() + " €";
        descripcionHotel.text = descripcion;

        // Esto hace que el botón sepa a qué ID llamar sin configurarlo a mano
        if (botonDetalles != null)
        {
            botonDetalles.onClick.RemoveAllListeners();
            botonDetalles.onClick.AddListener(() => {
                // Usamos FindFirstObjectByType que es la versión moderna de Unity 6
                Object.FindFirstObjectByType<VerDetalle>().GetDetalleHotel(idHotelActual);
            });
        }
    }

    public void RellenarDatosHotell(int id, string nombre, float precio, string descripcion)
    {
        nombreHotel.text = nombre;
        precioHotel.text = precio.ToString() + " €";
        descripcionHotel.text = descripcion;

        if (botonDetalles != null)
        {
            botonDetalles.onClick.RemoveAllListeners();
            botonDetalles.onClick.AddListener(() => {
                // Buscamos el script verdetalle (asegúrate de que el nombre coincida)
                var scriptDetalle = Object.FindFirstObjectByType<verdetalle>();
                if (scriptDetalle != null)
                {
                    scriptDetalle.GetDetalleHotel(nombreHotel.text);
                }
            });
        }
    }
}