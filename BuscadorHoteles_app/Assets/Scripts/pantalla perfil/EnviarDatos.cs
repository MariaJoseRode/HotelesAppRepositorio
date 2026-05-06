using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class EnviarDatos : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputDireccion;
    public TextMeshProUGUI textoBotonPrincipal;
    public TextMeshProUGUI textoFeedback;
    public GameObject PantallaPerfil;

    //Datos recuperados del servidor para mostrar en la pantalla del perfil
    [System.Serializable]
    public class DatosRecuperados
    {
        public bool success;
        public string nombre;
        public string direccion;
    }

    public void Start()
    {
        StartCoroutine(PedirDatosAlServidor());
    }
    public void PulsoGuardar()
    {
        StartCoroutine(EnviarPerfilAlServidor(inputNombre.text, inputDireccion.text));
    }

    IEnumerator EnviarPerfilAlServidor(string nombre, string direccion)
    {
        string mailUsuario = PlayerPrefs.GetString("EmailLogueado");

        WWWForm form = new WWWForm();
        form.AddField("NombreUsuario", nombre);
        form.AddField("DireccionUsuario", direccion);
        form.AddField("EmailUsuario", mailUsuario);

        string url = "http://localhost:8080/api/MySQL/guardarPerfil";

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Perfil guardado con éxito: " + www.downloadHandler.text);
                textoFeedback.text = "Tus datos se han guardado con éxito";
                yield return new WaitForSeconds(2f); // Espera 2 segundos para apagar la pantalla de perfil
                PantallaPerfil.SetActive(false);
            }
            else
            {
                textoFeedback.text = "Error al guardar tus datos. Por favor, inténtalo de nuevo.";
                Debug.Log("Error al guardar el perfil: " + www.error);
            }

        }

    }

    IEnumerator PedirDatosAlServidor()
    {
        string mailUsuario = PlayerPrefs.GetString("EmailLogueado");

        string url = "http://localhost:8080/api/MySQL/obtenerPerfil?EmailUsuario=" + mailUsuario;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                DatosRecuperados datosUsuario = JsonUtility.FromJson<DatosRecuperados>(www.downloadHandler.text);
                if (datosUsuario.success == true)
                {
                    inputNombre.text = datosUsuario.nombre;
                    inputDireccion.text = datosUsuario.direccion;
                    Debug.Log("Datos recuperados y colocados en pantalla.");
                }
                else
                {
                    Debug.Log("Todavía no se han guardado datos para este usuario.");
                }
            }
        }

    }
}
