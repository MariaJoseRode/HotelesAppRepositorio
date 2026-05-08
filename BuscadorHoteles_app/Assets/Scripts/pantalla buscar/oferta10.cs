//using System.Collections;
//using UnityEngine;
//using UnityEngine.Networking;
//using TMPro;


//[System.Serializable]
//public class RespuestaOferta
//{
//    public bool success;
//    public string mensaje;
//}

//public class oferta10 : MonoBehaviour 
//{
//    public TextMeshProUGUI mensajeOferta;
//    public GameObject bannerOferta;

//    public void PeticionOferta()
//    {

//        if (mensajeOferta != null)
//        {
//            mensajeOferta.text = "Obteniendo oferta para nuevo usuario";
//            StartCoroutine(ObtenerOferta());
//        }
//    }

//    IEnumerator ObtenerOferta()
//    {
//        string url = "http://localhost:8080/oferta10";

//        using (UnityWebRequest ofertarequest = UnityWebRequest.Get(url))
//        {
//            yield return ofertarequest.SendWebRequest();

//            if (ofertarequest.result == UnityWebRequest.Result.ConnectionError || ofertarequest.result == UnityWebRequest.Result.ProtocolError)
//            {
//                mensajeOferta.text = "Error al obtener la oferta";
//                Debug.Log("Error: " + ofertarequest.error);
//            }
//            else
//            {

//                string jsonResponse = ofertarequest.downloadHandler.text;
//                RespuestaOferta respuesta = JsonUtility.FromJson<RespuestaOferta>(jsonResponse);

//                if (respuesta != null && respuesta.success)
//                {
//                    mensajeOferta.text = respuesta.mensaje;
//                    if (bannerOferta != null) bannerOferta.SetActive(true);
//                }
//                else
//                {
//                    mensajeOferta.text = "Oferta no disponible";
//                }
//            }
//        }
//    }
//}


using UnityEngine;
using TMPro;

public class oferta10 : MonoBehaviour
{
    public TextMeshProUGUI mensajeOferta;
    public GameObject bannerOferta;

    public void PeticionOferta()
    {
        
        if (mensajeOferta != null)
        {
            mensajeOferta.text = "¡Felicidades! Tienes un 10% de descuento por ser nuevo usuario.";
        }

       
        if (bannerOferta != null)
        {
            bannerOferta.SetActive(true);
        }

        Debug.Log("Oferta mostrada localmente.");
    }

    
    public void CerrarOferta()
    {
        if (bannerOferta != null)
        {
            bannerOferta.SetActive(false); // Esto oculta todo el panel
            Debug.Log("Banner cerrado.");
        }
    }
}