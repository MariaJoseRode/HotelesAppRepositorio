using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using static botondetalles;

public class BotonLupa : MonoBehaviour
{
    public TMP_InputField inputBuscador;
    public GameObject panelNoResultados; // ESTO AHORA ESTÁ VACÍO PORQUE LUEGO VAMOS A CREAR UN PANEL EMERGENTE
    public Transform contenedor; //Container de cards con resultados
    public GameObject cardPrefab; //Card hoteles
    public void ClickBuscador()
    {
        string texto = inputBuscador.text;
        if (!string.IsNullOrEmpty(texto))
        {
            Debug.Log(" Buscando en la BBDD: " + texto);
            StartCoroutine(BuscarHotelesServidor(texto)); //uso de corrutinas ;)
        }
    }

    IEnumerator BuscarHotelesServidor(string nombre)


    {
        string url = "http://localhost:8080/api/MySQL/buscarHotel/" + nombre; //nelace a la bbdd

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)) //peticion get para la bbdd
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                RespuestaBusqueda respuesta = JsonUtility.FromJson<RespuestaBusqueda>(webRequest.downloadHandler.text); //cogemos el json

                if (respuesta.success && respuesta.datos.Length > 0)
                {
                    foreach(Transform hijo in contenedor)
                    {
                        Destroy(hijo.gameObject); //Borraremos todas las búsquedas anteriores
                    }
                    // panel que crearemos más adelante
                    if (panelNoResultados != null) panelNoResultados.SetActive(false);

                    Debug.Log("===============================");
                    Debug.Log(" ¡HOTELES ENCONTRADOS (" + respuesta.datos.Length + ")!");

                    foreach (var hotel in respuesta.datos)
                    {
                        GameObject nuevoCard = Instantiate(cardPrefab, contenedor);
                        HotelCard scriptCard = nuevoCard.GetComponentInChildren<HotelCard>(); //Creo un nuevo objeto de tipo HotelCard para rellenar los datos del hotel en la card
                        if (scriptCard != null)
                        {
                            scriptCard.RellenarDatosHotel(hotel.nombre_hotel, hotel.precio, hotel.descripcion); //Llamo a la función que rellena los datos.
                        }
                        Debug.Log($" NOMBRE: {hotel.nombre_hotel} |  PRECIO: {hotel.precio}€ |  DESC: {hotel.descripcion}");
                    }
                    Debug.Log("========================================");
                }
                else
                {
                    Debug.LogWarning(" No hay coincidencias en la BBDD para: " + nombre);
                    
                    if (panelNoResultados != null) panelNoResultados.SetActive(true); //puesto con if porque no tenemos eso todavia
                }
            }
            else
            {
                Debug.LogError(" Error de conexión con el servidor: " + webRequest.error);
            }
        }
    }


    //Clase para recuperar la info del hotel de la BBDD
    [System.Serializable]
    public class InfoHotel
    {
        public string nombre_hotel;
        public string descripcion;
        public float precio;
    }


    [System.Serializable]
    public class RespuestaBusqueda
    {
        public bool success;
        public InfoHotel[] datos; //aqui le decimos que coja la clase hotel que YA TENIAMOS 
    }
}

