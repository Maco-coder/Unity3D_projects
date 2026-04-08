using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLightController : MonoBehaviour
{
    [Header("Spheres Settings")]
    public List<GameObject> spheres;       // Assign all your spheres
    public Color lightColor = Color.red;   // Color of the lights
    public float fadeSpeed = 1f;           // How fast lights fade in

    private List<Material> sphereMaterials = new List<Material>();
    private List<Light> sphereLights = new List<Light>();
    private float intensity = 0f;          // Current intensity (0 to 1)
    private bool fadingIn = true;

    void Start()
    {
        // Cache materials and light components
        foreach (var sphere in spheres)
        {
            Renderer rend = sphere.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = rend.material;
                mat.color = lightColor * 0f; // start off
                sphereMaterials.Add(mat);
            }

            Light l = sphere.GetComponent<Light>();
            if (l == null)
            {
                l = sphere.AddComponent<Light>();
                l.color = lightColor;
                l.range = 5f;
                l.intensity = 0f;
            }
            sphereLights.Add(l);
        }
    }

    void Update()
    {
        if (fadingIn)
        {
            intensity += fadeSpeed * Time.deltaTime;
            if (intensity >= 0.5f)
            {
                intensity = 0.5f;
                fadingIn = false;
                StartCoroutine(PauseAtMax());
            }
        }

        // Apply intensity to all spheres
        foreach (var mat in sphereMaterials)
        {
            mat.color = lightColor * intensity;
        }

        foreach (var l in sphereLights)
        {
            l.intensity = intensity;
        }
    }

    IEnumerator PauseAtMax()
    {
        yield return new WaitForSeconds(1f); // pause at max for 1 second
        intensity = 0f;     // reset to off
        fadingIn = true;    // start fading in again
    }
}