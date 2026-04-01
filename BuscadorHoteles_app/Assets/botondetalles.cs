using System;
using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using TMPro;


public class botondetalles : MonoBehaviour
{

    public void ClickEnBotonAzul(string nombreDelHotel)
    {
        // Usamos EscapeURL para que "Hotel Olympia" no rompa la URL
        string nombreEscapado = UnityEngine.Networking.UnityWebRequest.EscapeURL(nombreDelHotel);
        string urlFinal = "http://localhost:8080/detalle-hotel/" + nombreEscapado;

        Debug.Log("Pidiendo a: " + urlFinal); // Para que veas en consola la ruta exacta
        StartCoroutine(GetDetalleHotel(urlFinal));
    }

    IEnumerator GetDetalleHotel(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                HotelData info = JsonUtility.FromJson<HotelData>(request.downloadHandler.text);
                Debug.Log("--- DATOS DEL HOTEL ---");
                Debug.Log("Nombre: " + info.nombre);
                Debug.Log("Descripción: " + info.descripcion);
                Debug.Log("-----------------------");
            }
            else
            {
                // Si sale 404 aquí, revisa que en Node la ruta sea /detalle-hotel/:nombre
                Debug.LogError("Error: " + request.responseCode + " - " + request.error);
            }
        }
    }


    [Serializable]
    public class HotelData
    {
        public bool success;
        public string nombre;
        public string descripcion;
        public string precio;
        public int estrellas;
    }
}
