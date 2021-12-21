using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargaritaController : MonoBehaviour
{

    public float speed;
    public Transform camara;
    public Vector3 camaraOffset;
    private Rigidbody rb;
    private LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    { 
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right* speed * Time.deltaTime, Space.World);
            this.transform.eulerAngles = Vector3.zero;
        }

    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
    this.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    this.transform.eulerAngles = new Vector3(0, 180, 0);
    }
        camara.position = this.transform.position + camaraOffset;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Medicamentos")
        {
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Escalera1")
        {

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                this.transform.position = lm.spawnEscalera2.position;
            }
        }

        if (other.gameObject.tag == "Escalera2")
        {

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                this.transform.position = lm.spawnEscalera1.position;
            }
        }
       
    }
}
