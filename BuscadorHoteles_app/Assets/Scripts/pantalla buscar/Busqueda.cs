using UnityEngine;

using TMPro;

public class Busqueda : MonoBehaviour
{

    public TMP_InputField campobusqueda;
   
    public void Buscar()
    {
        if (campobusqueda.text == "" )
        {
            Debug.Log("Debes ingresar algo a buscar");
        }
        else {
            Debug.Log("Buscando resultados...");
        }
        
    }

  
}
