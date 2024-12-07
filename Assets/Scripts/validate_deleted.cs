using UnityEngine;
using TMPro; // Asegúrate de tener esta referencia para usar TextMeshPro

public class DisableTouchedObjects : MonoBehaviour
{
    void Start()
    {
        // Recuperar la lista de objetos tocados desde PlayerPrefs
        string touchedObjects = PlayerPrefs.GetString("TouchedObjects", "");

        if (!string.IsNullOrEmpty(touchedObjects))
        {
            // Dividir la cadena en un arreglo de nombres de objetos
            string[] touchedPokemon = touchedObjects.Split(',');

            // Recorrer todos los nombres de los Pokémon tocados
            foreach (string pokemonName in touchedPokemon)
            {
                // Buscar el objeto en la escena por su nombre
                GameObject pokemonObject = GameObject.Find(pokemonName);

                if (pokemonObject != null)
                {
                    // Desactivar el objeto
                    pokemonObject.SetActive(false);

                    // Imprimir en la consola la cantidad de eliminados
                    Debug.Log("Objeto desactivado: " + pokemonName);
                }
            }

            // Actualizar el texto de eliminados con el conteo
        }
    }

}
