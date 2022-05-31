using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instaniate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 30f;
    private Animator anim;
    public BoxCollider2D boxCollider;
    private bool hit;
    private float direction;
    private float lifeTime;
    public GameObject player;
    PlayerController pc;
    public GameObject bullet;
    void Start()
    {
       anim = GetComponent<Animator>();
       boxCollider = GetComponent<BoxCollider2D>();
        pc = gameObject.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject == player)
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }
    }

}
