using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10f;
    public float verticalInput;
    public float xRange = 20f;
    public float zRange = 11f;
    public GameObject projectile;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        //Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        

        //Rango de limites donde se puede mover el personaje, tambien puede trabajarse con un IF

        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedZ = Mathf.Clamp(transform.position.z, -zRange, zRange);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);


        //Disparo de comida toma el codigo de la tecla que se presiona
        //En moveFoward, ignora el collider del player, solamente afecta el de enemy para no destruir el player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Shoot");
            Instantiate(projectile, transform.position, transform.rotation);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {

        //Si un animal toca al jugador saldra este cartel
        if (other.CompareTag("Enemy")) {
            //Quita una vida en game manager
            gameManager.AddLives(-1);
        }

    }
}
