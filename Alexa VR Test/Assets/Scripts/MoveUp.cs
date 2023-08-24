using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveUp : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.MovePosition(transform.position + new Vector3(1,0,0) * Time.deltaTime * m_Speed);
    }
}
