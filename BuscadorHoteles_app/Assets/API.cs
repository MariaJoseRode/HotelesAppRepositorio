using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;




public class API : MonoBehaviour
{
    public TMP_InputField inputEmail;
    public TMP_InputField inputPassword; 

    public void LoginRequest()
    {
        StartCoroutine(POST_Login("http://localhost:8080/login"));
    }

    IEnumerator POST_Login(string uri)
    {
        WWWForm form = new WWWForm();
         form.AddField("campo_email", inputEmail.text);
        form.AddField("campo_password", inputPassword.text);

        UnityWebRequest request = UnityWebRequest.Post(uri, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            RespuestaNode data = JsonUtility.FromJson<RespuestaNode>(request.downloadHandler.text);
            Debug.Log("Mensaje del servidor: " + data.mensaje);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
    public void ClickEnBotonOferta()
    {
        StartCoroutine(PostOferta("http://localhost:8080/oferta"));
    }

    IEnumerator PostOferta(string uri)
    {
        WWWForm form = new WWWForm();
        
        form.AddField("peticion", "oferta");

        UnityWebRequest request = UnityWebRequest.Post(uri, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            
             RespuestaNode data = JsonUtility.FromJson<RespuestaNode>(request.downloadHandler.text);

            Debug.Log("*** OFERTA RECIBIDA ***");
            Debug.Log(data.mensaje);
        }
        else
        {
            Debug.LogError("Error en oferta: " + request.error);
        }
    }
} 


[Serializable]
public class RespuestaNode
{
    public bool success;
    public string mensaje;
}

