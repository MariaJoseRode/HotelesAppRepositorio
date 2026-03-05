using UnityEngine;

public class botonperfil : MonoBehaviour
{
    public GameObject pantallaperfil;
    
    public void DirigirPerfil()
    {
        Debug.Log("Dirigiendo a la pantalla de perfil...");
        pantallaperfil.SetActive(true);

    }
}
