using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public static Driver instance;
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.01f;
    SpriteRenderer sr;
    Color yellow;
    Color blue;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        yellow = Color.yellow;
        blue = Color.blue;
    }

    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="blueCar")
        {
            Destroy(collision.gameObject);
            sr.color = blue;


        }

        if (collision.gameObject.tag == "yellowCar")
        {
            Destroy(collision.gameObject);
            sr.color = yellow;
        }

    }
}
