using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using System;

public class botonreserva : MonoBehaviour
{
    [Header("Referencias de Inputs")]
    public TMP_InputField inputEmail;
    public TMP_InputField inputPassword;

    // Esta es la función que debes asignar al botón naranja en el OnClick
    public void ClickEnBotonNaranja()
    {
        Debug.Log("Pulsado el botón. Enviando petición de reserva...");
        StartCoroutine(PostReserva("http://localhost:8080/reservar"));
    }

    IEnumerator PostReserva(string uri)
    {
        WWWForm form = new WWWForm();

        // Enviamos los datos que el servidor espera
        form.AddField("campo_email", inputEmail.text);
        form.AddField("campo_password", inputPassword.text);

        UnityWebRequest request = UnityWebRequest.Post(uri, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Convertimos el JSON que nos da Node a una clase de C#
            RespuestaNode data = JsonUtility.FromJson<RespuestaNode>(request.downloadHandler.text);

            if (data.success)
            {
                // ESTO ES LO QUE SALE POR CONSOLA
                Debug.Log("--- RESPUESTA DEL SERVIDOR ---");
                Debug.Log("Mensaje: " + data.mensaje);
                Debug.Log("------------------------------");
            }
        }
        else
        {
            // Esto saldrá en rojo en la consola si el servidor está apagado
            Debug.LogError("ERROR: No se pudo conectar con el servidor. ¿Está Node.js encendido?");
        }
    }

    [Serializable]
    public class RespuestaNode
    {
        public bool success;
        public string mensaje;
    }
}