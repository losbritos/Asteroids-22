using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigocontroller : MonoBehaviour

{
    public float speed_min;
    public float speed_max;

    Rigidbody2D rb;
    public enemigoManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        if (gamemanager.instance.puntuacion > 1000) {
            rb = GetComponent<Rigidbody2D>();
            Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            direccion = direccion * Random.Range(speed_min, speed_max);
            Debug.Log(Random.Range(-1f, 1f));
           rb.AddForce(direccion);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void muerte()
    {
        
        Destroy(gameObject);
    }
    //private void OnTriggerEnter2D(Collider2D collision) { 

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
         {
           collision.gameObject.GetComponent<MovimientoPersonaje>().Muerte();
            Destroy(gameObject);
       }

    }
}
