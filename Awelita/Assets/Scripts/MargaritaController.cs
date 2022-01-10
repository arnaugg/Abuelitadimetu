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
    public float timeToSpawn;
    public List <GameObject> medicamento;
    int medicamentoactivo = 0;
    public Animator animator;

    public AudioSource walksource;
    public AudioSource pillsource;
    public AudioClip walkgrass;
    public AudioClip walkwood;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        walksource.clip = walkwood;
    }

    // Update is called once per frame
    void Update()
    { 
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right* speed * Time.deltaTime, Space.World);
            this.transform.eulerAngles = Vector3.zero;
            animator.SetBool("Walk", true);
            walksource.Play();
        }

    else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        this.transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("Walk", true);
            walksource.Play();
        }
    else
        {
            animator.SetBool("Walk", false);
            walksource.Stop();
        }
        camara.position = this.transform.position + camaraOffset;
    
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Medicamentos")
        {
            pillsource.Play();
            other.gameObject.SetActive(false);
            Invoke("CuentaAtras", timeToSpawn);
            GameManager.instance.remaining_time += 15;
            if (GameManager.instance.remaining_time > GameManager.instance.initial_time)
            {
                GameManager.instance.remaining_time = GameManager.instance.initial_time;
            }
        }
        else if(other.gameObject.tag == "Jardin")
        {
            walksource.clip = walkgrass;
        }

    }
    void CuentaAtras()
    {
        Invoke("Respawn", 5);

    }

    void Respawn()
    {
         medicamentoactivo = Random.Range(0, medicamento.Count);
        medicamento[medicamentoactivo].SetActive(true);
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

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                this.transform.position = lm.spawnEscalera1.position;
            }
        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Jardin")
        {
            walksource.clip = walkwood;
        }
    }
}
