using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEditor.PackageManager.Requests;


[System.Serializable]
public class RespuestaOferta
{
    public bool success;
    public string mensaje;
}
public class oferta10 : MonoBehaviour
{
    public TextMeshProUGUI mensajeOferta;
    public GameObject bannerOferta;

    public void PeticionOferta()
    {
        mensajeOferta.text = "Obteniendo oferta para nuevo usuario";
        StartCoroutine(ObtenerOferta());
    }

    IEnumerator ObtenerOferta()
    {
        string url = "http://localhost:8080/oferta10";

        UnityWebRequest ofertarequest = UnityWebRequest.Get(url);

        yield return ofertarequest.SendWebRequest();

        if (ofertarequest.result == UnityWebRequest.Result.ConnectionError || ofertarequest.result == UnityWebRequest.Result.ProtocolError)
        {
            mensajeOferta.text = "Error al obtener la oferta";
            Debug.Log("Error: " + ofertarequest.error);
        }
        else
        {
            RespuestaOferta respuesta = JsonUtility.FromJson<RespuestaOferta>(ofertarequest.downloadHandler.text);
            if (respuesta.success == true)
            {

                mensajeOferta.text = respuesta.mensaje;

                bannerOferta.SetActive(true);

            }

        }
    }
}
