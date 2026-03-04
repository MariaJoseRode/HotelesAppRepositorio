using TMPro;
using UnityEngine;

public class gameButton : MonoBehaviour
{

    public TMP_Text textoCanvas;
    public TMP_InputField inputField;


   public void BotonIntroducir()
    {
        textoCanvas.text = "Datos introducidos";
        Debug.Log("Introduciendo");
    }

    public void InputPorConsola() { 
        Debug.Log(inputField.text);
    }
}
