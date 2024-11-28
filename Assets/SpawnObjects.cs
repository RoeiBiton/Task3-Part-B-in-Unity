using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab you want to spawn
    public RectTransform canvasTransform; // Reference to the Canvas' RectTransform
    public float spawnInterval = 2f; // Time between spawns
    public float yAxis = 8;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        // Possible x positions
        int[] xPositions = { -432, 0, 432 };

        // Randomly select an x position
        int randomIndex = Random.Range(0, xPositions.Length);
        float x = xPositions[randomIndex];

        // Define the spawn position (in world space)
        Vector3 spawnPosition = new Vector3(x, yAxis, 0);

        // Instantiate the object at the spawn position
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Set the spawned object's parent to the Canvas
        spawnedObject.transform.SetParent(canvasTransform, false);

        // Adjust the RectTransform if it's a UI object
        RectTransform rectTransform = spawnedObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.localScale = Vector3.one; // Avoid scaling issues
        }

        // Assign a random color (if it's a UI object with an Image component)
        AssignRandomColor(spawnedObject);
    }


    void AssignRandomColor(GameObject obj)
    {
        // Possible colors
        Color[] colors = { Color.red, Color.green, Color.yellow, Color.blue };

        // Randomly select a color
        int randomColorIndex = Random.Range(0, colors.Length);
        Color randomColor = colors[randomColorIndex];

        // Assign the color to the object's Renderer
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = randomColor;
        }
    }
}