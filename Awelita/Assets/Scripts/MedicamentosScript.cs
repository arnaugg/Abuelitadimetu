using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicamentosScript : MonoBehaviour
{
    public float timeToSpawn;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
       startPos = this.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("CuentaAtras", timeToSpawn) ;
        }
    }

    void CuentaAtras()
    {
        Invoke("Respawn", 5);

    }

    void Respawn()
    {
        this.transform.position = startPos;
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
