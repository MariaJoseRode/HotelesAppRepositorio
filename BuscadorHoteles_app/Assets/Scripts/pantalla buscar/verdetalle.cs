using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class verdetalle : MonoBehaviour
{
  


   public void VerDetalle()
    {
        Debug.Log("Mostrando detalles del lugar...(esto abriria una pagina nueva - FUTURA ACTUALIZACIÓN");
    }




    public void GetDetalleHotel(string nombre) // Ahora recibe un string
    {
        StartCoroutine(EnviarPeticionDetalle(nombre));
    }

    IEnumerator EnviarPeticionDetalle(string nombre)
    {
        // Importante: Usamos EscapeURL por si el nombre tiene espacios (ej: "Hotel Estimar")
        string nombreEscapado = UnityWebRequest.EscapeURL(nombre);
        string url = "http://localhost:8080/api/MySQL/buscarHotel/" + nombreEscapado;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Datos del hotel recibidos: " + webRequest.downloadHandler.text);
                // Aquí ya puedes procesar el JSON con el nombre del hotel
            }
            else
            {
                Debug.LogError("Error al buscar por nombre: " + webRequest.error);
            }
        }
    }
}

