using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int pointsInGame = 0;
    public int lifes = 3;
    public int points = 0;
    public GameObject spawnManagerPrefabs;
    private int spwanActivates = 1;//Toma los spawn para generar

    //Controla flujo de vidas
    public void AddLives(int value)
    {
        lifes += value;
        if (lifes <= 0)
        {
            Debug.Log("Se termino el juego");
            lifes = 0;
        }
        Debug.Log("Vidas: " + lifes);
    }

    //Controla flujo de puntos
    public void AddScore(int value)
    {
        pointsInGame += value;
        Debug.Log("Puntuación= " + pointsInGame);

        points += value;

        if (points ==10)//Al momento de conseguir 10 puntos genera una vida y crea un spawn nuevo
        {
            AddLives(+1);
            points = 0;
            Instantiate(spawnManagerPrefabs);
        }

    }
}

