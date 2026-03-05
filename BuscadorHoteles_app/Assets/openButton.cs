using UnityEngine;

public class openButton : MonoBehaviour
{
    public GameObject MenuContext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuContext.SetActive(false);

    }
    public void AbrirMenu() {
        MenuContext.SetActive(true);



    }
}
