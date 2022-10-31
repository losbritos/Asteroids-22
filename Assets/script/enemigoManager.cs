using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoManager : MonoBehaviour
{
    public int enemigos_min = 1;
    public int enemigos_max = 2;
    public float limitY = 6;
    public float limitX = 10;
    public GameObject enemigo;

    // Start is called before the first frame update
    void Start()
    {

        if(gamemanager.instance.puntuacion >1000) {
            int enemigos = Random.Range(enemigos_min, enemigos_max);

            for (int i = 0; i < enemigos; i++)
            {
                Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
                Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
                GameObject temp = Instantiate(enemigo, posicion, Quaternion.Euler(rotacion));
                temp.GetComponent<enemigocontroller>().Manager = this;
            }
        }
            

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
