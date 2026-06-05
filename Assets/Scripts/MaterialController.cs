using System;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public string[] meshTags;
    public Material[] materials;

    private int lastMaterial = -1;

    public void ChangeAllMaterials(int index)
    {
        // Validación para evitar errores si el índice no existe en el array de materiales
        if (index < 0 || index >= materials.Length) return;

        lastMaterial = index;

        foreach (string tag in meshTags)
        {
            // Buscamos TODOS los objetos con la etiqueta actual
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject gameObj in gameObjects)
            {
                Renderer renderer = gameObj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = materials[index];
                }
            }
        }
    }

    void Update()
    {
        if (lastMaterial != -1)
        {
            foreach (string tag in meshTags)
            {
                // Buscamos TODOS los objetos en cada frame para asegurar el material
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

                foreach (GameObject gameObj in gameObjects)
                {
                    Renderer renderer = gameObj.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = materials[lastMaterial];
                    }
                }
            }
        }
    }
}