using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.SceneManagement;


public class Test1 : MonoBehaviour
{

    Rigidbody body            ;
    
    public GameObject WinText ;

    float xInput              ;
    float zInput              ;
    public float speed        ;


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
            //Destroy(gameObject);

            //body.AddForce(Vector3.up * 500);

            //body.velocity = Vector3.forward * 20f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level");
        }

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical")  ;
        body.AddForce(xInput * speed, 0, zInput * speed);

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject);
            WinText.SetActive(true)      ;
        }
    }
}
