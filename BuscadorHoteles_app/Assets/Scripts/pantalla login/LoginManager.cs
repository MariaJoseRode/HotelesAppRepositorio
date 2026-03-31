using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class loginManager : MonoBehaviour
{
    public class LoginResponse
    {
        public bool success;
        public string mensaje;
    }

    public TMP_InputField campo_email;
    public TMP_InputField campo_password;

    public GameObject pantallaLogin;
    public GameObject pantallaPrincipal;

    public void IntentarLogin()
    {
        if (campo_email.text != "" && campo_password.text != "")
        {
            Debug.Log("Enviando datos al servidor...");
            StartCoroutine(EnviarDatosAlServidor(campo_email.text, campo_password.text));
        }
        else
        {
            Debug.Log("Error: Rellena el email y la contraseña.");
        }


        IEnumerator EnviarDatosAlServidor(string email, string password)
        {
            WWWForm form = new WWWForm();
            form.AddField("emailUsuario", email);
            form.AddField("passwordUsuario", password);

            string urlDelServidor = "http://localhost:8080/login";
            UnityWebRequest request = UnityWebRequest.Post(urlDelServidor, form);

            yield return request.SendWebRequest();


            LoginResponse respuestaLogin = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);

            if (respuestaLogin.success == true)
            {
                pantallaLogin.SetActive(false);
                pantallaPrincipal.SetActive(true);
                Debug.Log(respuestaLogin.mensaje);
            }
            else
            {
                Debug.Log("Acceso denegado" + respuestaLogin.mensaje);
            }
        }

    }
}