using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField campo_email;
    public TMP_InputField campo_password;

    public void IniciarSesion()
    {
        if (campo_email.text != "" && campo_password.text != "")
        {

            Debug.Log("Enviando datos al servidor...");


            StartCoroutine(EnviarDatosLogin(campo_email.text, campo_password.text));
        }
        else
        {
            Debug.Log("Por favor, completa ambos campos.");
        }
    }

    IEnumerator EnviarDatosLogin(string email, string password)
    {
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("mail_usuario", email);
        loginForm.AddField("password_usuario", password);

        string urlDelServidor = "http://localhost:8080/login";
        UnityWebRequest LoginRequest = UnityWebRequest.Post(urlDelServidor, loginForm);

        yield return LoginRequest.SendWebRequest();

        Debug.Log("Respuesta del servidor: " + LoginRequest.downloadHandler.text);
    }
}
