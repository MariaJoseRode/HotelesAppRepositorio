using TMPro;
using UnityEngine;

public class mostrarcontrasena : MonoBehaviour
{

    public TMP_InputField campo_password;

    public void CambiaVisibilidad()
    {
        if (campo_password.contentType == TMP_InputField.ContentType.Password)
        {
            campo_password.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            campo_password.contentType = TMP_InputField.ContentType.Password;
        }

        campo_password.ForceLabelUpdate();

    }
}
