using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    //Array prefabs animales
    public GameObject[] animalPrefabs;
    public float StartDelay = 4f;
    public float spawnInterval = 2f;
    public float xSpawnRange = 20f;
    public float sideSpawnMinZ = -11f;
    public float sideSpawnMaxZ=11f;
    public float sideSpawnX= 20f;


    private void Start()
    {
        //Genera prefab con cierto tiempo e intervalo
        InvokeRepeating(nameof(SpawnRandomSide), StartDelay, spawnInterval);
    }
    private void SpawnRandomSide()
    {

        //El spawn tomara un numero entre 0 y 3 y dirige hacia donde ira el animal generado
        int randomSide =Random.Range (0,3);

        if (randomSide == 0)
        {
            SpawnAnimal();
        }
        else if (randomSide == 1)
        {
            SpawnLeftAnimal();
        }
        else
        {
            SpawnRigthAnimal();
        }
    }
    private void SpawnAnimal()
    {
        //Genera aleatoreo de animales desde arriba 
        Vector3 spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), transform.position.y, transform.position.z);//posicion del animal
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        transform.position = spawnPos;
        //Instanacia el animal y lo genera
        Instantiate(animalPrefabs[animalIndex], transform.position, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        //Genera los animales desde la izquierda hacia derecha
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0,90,0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
    void SpawnRigthAnimal()
    {
        //Genera los animales de derecha hacia la izquierda
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));

    }
}

