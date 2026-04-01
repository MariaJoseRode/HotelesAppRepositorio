using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;


public class botonCalendario : MonoBehaviour
{
   
    public void ClickEnCalendario()
    {
        StartCoroutine(GetCalendario("http://localhost:8080/mis-reservas"));
    }

    IEnumerator GetCalendario(string uri)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
        
            ReservaData info = JsonUtility.FromJson<ReservaData>(request.downloadHandler.text);

            Debug.Log("*** TUS PRÓXIMAS VACACIONES **");
            Debug.Log("Hotel: " + info.hotel);
            Debug.Log("Periodo: Del " + info.fechaInicio + " al " + info.fechaFin);
            Debug.Log("Estado: " + info.estado);
            Debug.Log("   ");
        }
        else
        {
            Debug.LogError("Error al consultar el calendario: " + request.error);
        }
    }


    [Serializable]
    public class ReservaData
    {
        public bool success;
        public string hotel;
        public string fechaInicio;
        public string fechaFin;
        public string estado;
    }
}
