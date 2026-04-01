using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class BotonFavs : MonoBehaviour
{
    public void VerFavoritos()
    {
        StartCoroutine(GetFavoritos("http://localhost:8080/favoritos"));
    }

    IEnumerator GetFavoritos(string uri)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Tus favoritos son: " + request.downloadHandler.text);
        }
    }
}
