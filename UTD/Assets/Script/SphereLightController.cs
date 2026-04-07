using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLightController : MonoBehaviour
{
    [Header("Spheres and Settings")]
    public List<GameObject> spheres; // Assign all your sphere GameObjects here
    public Color lightColor = Color.white;
    public float intensity = 1f; // If using real Light component
    public float blinkInterval = 0.5f; // Time between on/off

    private List<Material> sphereMaterials = new List<Material>();
    private bool isOn = true;

    void Start()
    {
        // Cache materials and initialize color
        foreach (var sphere in spheres)
        {
            Renderer rend = sphere.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = rend.material; // instance so it can be changed individually
                mat.color = lightColor;
                sphereMaterials.Add(mat);
            }

            // Optional: Add a Light component if you want real light
            Light l = sphere.GetComponent<Light>();
            if (l == null)
            {
                l = sphere.AddComponent<Light>();
                l.color = lightColor;
                l.intensity = intensity;
                l.range = 5f;
            }
        }

        StartCoroutine(BlinkAll());
    }

    IEnumerator BlinkAll()
    {
        while (true)
        {
            // Toggle state
            isOn = !isOn;

            // Update all spheres
            foreach (var mat in sphereMaterials)
            {
                mat.color = isOn ? lightColor : Color.black;
            }

            foreach (var sphere in spheres)
            {
                Light l = sphere.GetComponent<Light>();
                if (l != null)
                    l.enabled = isOn;
            }

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}