using UnityEngine;

public class PendientesToggler : MonoBehaviour
{
    private string pendientesTag = "Pendientes"; 
    private bool isEnabled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableTearsMeshes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void DisableTearsMeshes()
    {
        // Find ALL game objects with the tag and store them in an array
        GameObject[] meshObjects = GameObject.FindGameObjectsWithTag(pendientesTag);
        
        // Loop through every object found and turn off its renderer
        foreach (GameObject meshObject in meshObjects)
        {
            Renderer renderer = meshObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
    }

    public void EnableMesh()
    {
        // Find ALL game objects with the tag
        GameObject[] meshObjects = GameObject.FindGameObjectsWithTag(pendientesTag);
        
        // Loop through every object found and turn on its renderer
        foreach (GameObject meshObject in meshObjects)
        {
            Renderer renderer = meshObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }
    }
    public void TogglePendientes()
    {
        if (isEnabled)
        {
            isEnabled = false;
            DisableTearsMeshes();
        }
        else
        {
            isEnabled = true;
            EnableMesh();
        }
    }
}
