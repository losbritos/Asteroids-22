using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour

{
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationSpeed= 10;
    public GameObject bala;
    public GameObject boquilla;
    public GameObject particulamuerte;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       float vertical = Input.GetAxis("Vertical");
        if(vertical > 0) 
        { 
            
            
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsando",true );
        }
        else
        {
            anim.SetBool("impulsando", false);
        }
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
           GameObject temp =  Instantiate(bala, boquilla.transform.position, transform.rotation);
            Destroy(temp, 1.5f);
        }
    }

    public void Muerte()
    {
        GameObject temp = Instantiate(particulamuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);

        gamemanager.instance.vidas -= 1;
        if (gamemanager.instance.vidas <= 0)

        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        else 
        {
            StartCoroutine(Respawn_Coroutime());
        }
        

       

       IEnumerator Respawn_Coroutime()
        {
            collider.enabled = false;
            sprite.enabled = false;
            yield return new WaitForSeconds(2);
            collider.enabled = true;
            sprite.enabled = true;

            
            transform.position = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(0, 0);



            
        } 

    }
}
