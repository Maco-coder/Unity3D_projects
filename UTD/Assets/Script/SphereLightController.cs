using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLightController : MonoBehaviour
{
    [Header("Spheres and Settings")]
    public List<GameObject> spheres; // Assign all your sphere GameObjects here
    public Color lightColor = Color.white;
    public float intensity = 1f; // Can be used if you attach Light component
    public float blinkInterval = 0.5f; // Default blink interval

    private List<Material> sphereMaterials = new List<Material>();

    void Start()
    {
        // Cache materials and set initial color
        foreach (var sphere in spheres)
        {
            Renderer rend = sphere.GetComponent<Renderer>();
            if (rend != null)
            {
                // Use an instance of the material so we can change it individually
                Material mat = rend.material;
                mat.color = lightColor;
                sphereMaterials.Add(mat);
            }

            // Optional: Add a Light component if you want real lighting
            Light l = sphere.GetComponent<Light>();
            if (l == null)
            {
                l = sphere.AddComponent<Light>();
                l.color = lightColor;
                l.intensity = intensity;
                l.range = 5f;
            }
        }

        // Start blinking pattern
        StartCoroutine(BlinkPattern());
    }

    IEnumerator BlinkPattern()
    {
        while (true)
        {
            for (int i = 0; i < spheres.Count; i++)
            {
                // Simple example: blink in a wave pattern
                sphereMaterials[i].color = lightColor * Random.Range(0f, 1f); // dim to off randomly
                Light l = spheres[i].GetComponent<Light>();
                if (l != null)
                {
                    l.enabled = !l.enabled;
                }

                yield return new WaitForSeconds(blinkInterval / spheres.Count);
            }
            yield return null;
        }
    }
}