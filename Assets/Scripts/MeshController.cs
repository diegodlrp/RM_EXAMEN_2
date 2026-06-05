using System;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public string[] meshTags;

    // Guardamos la etiqueta que está actualmente activa en la pantalla
    private string currentActiveTag = "";

    void Start()
    {
        DisableAllMeshes();
    }

    public void EnableMeshByTag(string tag)
    {
        // 1. Apagamos absolutamente todos los objetos de la lista de etiquetas
        DisableAllMeshes();

        // 2. Registramos cuál es la etiqueta que debe estar activa ahora
        currentActiveTag = tag;

        // 3. Buscamos y encendemos TODOS los objetos de la etiqueta seleccionada (viejos y nuevos)
        GameObject[] meshObjects = GameObject.FindGameObjectsWithTag(tag);
        
        foreach (GameObject meshObject in meshObjects)
        {
            Renderer renderer = meshObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }
    }

    public void DisableAllMeshes()
    {
        currentActiveTag = ""; // Ya nada está activo

        foreach (string tag in meshTags)
        {
            GameObject[] meshObjects = GameObject.FindGameObjectsWithTag(tag);
            
            foreach (GameObject meshObject in meshObjects)
            {
                Renderer renderer = meshObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;
                }
            }
        }
    }

    /// <summary>
    /// NOTA PARA TU SPAWNER:
    /// Cuando instancies un objeto nuevo en tu script de Spawner, 
    /// llama a esta función pasándole el objeto clonado y su etiqueta.
    /// Esto garantizará que si se spawnea mientras su etiqueta está oculta, nazca invisible.
    /// </summary>
    public void CheckSpawnedObjectStatus(GameObject spawnedObject, string objectTag)
    {
        Renderer renderer = spawnedObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Si la etiqueta del objeto clonado NO es la que está activa en pantalla, lo apaga al nacer
            renderer.enabled = (objectTag == currentActiveTag);
        }
    }
}