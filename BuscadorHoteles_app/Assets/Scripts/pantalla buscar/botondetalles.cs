using UnityEngine;
using UnityEngine.Networking;


using UnityEngine.Networking;
using System.Collections;

public class VerDetalle : MonoBehaviour
{
    public void GetDetalleHotel(int id)
    {
        StartCoroutine(EnviarPeticionDetalle(id));
    }

    IEnumerator EnviarPeticionDetalle(int id)
    {
        string url = "http://localhost:8888/api/MySQL/detalleHotel/" + id;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Datos recibidos: " + webRequest.downloadHandler.text);
                // Aquí conviertes el JSON y abres tu panel de detalles
                // HotelData data = JsonUtility.FromJson<HotelData>(webRequest.downloadHandler.text);
                // MostrarPantallaDetalles(data);
            }
            else
            {
                Debug.LogError("Error al obtener detalles: " + webRequest.error);
            }
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