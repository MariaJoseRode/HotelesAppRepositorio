using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class verdetalle : MonoBehaviour
{
  


   public void VerDetalle()
    {
        Debug.Log("Mostrando detalles del lugar...(esto abriria una pagina nueva - FUTURA ACTUALIZACIÓN");
    }




    public void GetDetalleHotel(string nombre) 
    {
        StartCoroutine(EnviarPeticionDetalle(nombre));
    }

    IEnumerator EnviarPeticionDetalle(string nombre)
    {
        
        string nombreEscapado = UnityWebRequest.EscapeURL(nombre);
        string url = "http://localhost:8080/api/MySQL/buscarHotel/" + nombreEscapado;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Datos del hotel recibidos: " + webRequest.downloadHandler.text);
                
            }
            else
            {
                Debug.LogError("Error al buscar por nombre: " + webRequest.error);
            }
        }
    }
}

