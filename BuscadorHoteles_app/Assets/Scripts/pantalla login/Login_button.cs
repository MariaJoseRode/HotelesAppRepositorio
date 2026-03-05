using UnityEngine;

public class Login_button : MonoBehaviour
{
    public GameObject pantallaLogin;
    public GameObject pantallaBuscar; 
    public void IniciaSesion()
    {
        Debug.Log("Hola desde el botón");
        pantallaLogin.SetActive(false);
        pantallaBuscar.SetActive(true);

    }

}


