using UnityEngine;
using TMPro; 

public class HotelCard : MonoBehaviour
{

    public TextMeshProUGUI nombreHotel;
    public TextMeshProUGUI precioHotel;
    public TextMeshProUGUI descripcionHotel;

    public void RellenarDatosHotel(string nombre, float precio, string descripcion)
    {
        nombreHotel.text = nombre;
        precioHotel.text = precio.ToString() + "€";
        descripcionHotel.text = descripcion;
    }
}