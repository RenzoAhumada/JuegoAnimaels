using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    // Start is called before the first frame update

    public float topBound=40f;
    public float lowBound = -15f;
    public float sideBound = 30f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Destruye el objeto al momento de llegar a la posicion en z + 40
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowBound)//Destruye en limite inferior
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound)//Destruye en limite en x
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)//Destruye en limite en -x
        {
            Destroy(gameObject);
        }

    }
}
