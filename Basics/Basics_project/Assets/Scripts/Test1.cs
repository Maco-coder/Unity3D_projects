using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;

public class Test1 : MonoBehaviour
{

    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject,2);

        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
