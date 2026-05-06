using System;
using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using TMPro;


public class botondetalles : MonoBehaviour
{

    public void ClickEnBotonAzul(int idHotel)
    {
        Debug.Log("¡BOTÓN PULSADO! Buscando ID: " + idHotel);

        StartCoroutine(GetDetalleHotel(idHotel));


    }

    public void MostrarPantallaDetalles(HotelData datos)
    {

        Debug.Log("Mostrando detalles de: " + datos.nombre_hotel);
        Debug.Log(" Precio: " + datos.precio + " EUR");
        Debug.Log(" Descripcion: " + datos.descripcion + " .");
    }

    IEnumerator GetDetalleHotel(int id)
    {

        string url = "http://localhost:8080/api/MySQL/detalleHotel/" + id;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                
                Debug.Log("Datos recibidos: " + webRequest.downloadHandler.text);

                HotelData hotelData = JsonUtility.FromJson<HotelData>(webRequest.downloadHandler.text);
                MostrarPantallaDetalles(hotelData);
            }
        }
    }


    [System.Serializable]
    public class HotelData
    {
        public int id_hotel;        
        public string nombre_hotel; 
        public string descripcion;  
        public int precio;          
    }
}
