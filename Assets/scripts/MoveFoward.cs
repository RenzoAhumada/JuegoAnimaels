using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{

    public float speed = 40f; //velocidad de proyectil
    public GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Moviemiento en X del objeto
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Compara que sea con el tag colocado en Enemy
        //Tambien existe el ignore collision para el player
        if (other.CompareTag("Enemy"))
        {
            //Destuye el objeto con colision
            Destroy(other.gameObject);
            //Aumenta un punto al colisionar con el animal
            gameManager.AddScore(+1);
        }

        
    }
}
