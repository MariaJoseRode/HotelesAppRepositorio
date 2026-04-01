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

    
    public void ClickEnBotonNaranja()
    {
        Debug.Log("Pulsado el botón. Enviando petición de reserva...");
        StartCoroutine(PostReserva("http://localhost:8080/reservar"));
    }

    IEnumerator PostReserva(string uri)
    {
        WWWForm form = new WWWForm();

        
        form.AddField("campo_email", inputEmail.text);
        form.AddField("campo_password", inputPassword.text);

        UnityWebRequest request = UnityWebRequest.Post(uri, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
           
            RespuestaNode data = JsonUtility.FromJson<RespuestaNode>(request.downloadHandler.text);

            if (data.success)
            {
                
                
                Debug.Log("Mensaje: " + data.mensaje);
                  Debug.Log("  ");
            }
        }
        else
        {
            
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