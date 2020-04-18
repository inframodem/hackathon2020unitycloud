using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;
    public bool isenemy;
    public LevelStats lc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject lvlcntrl = GameObject.Find("LevelController");
        lc = lvlcntrl.GetComponent<LevelStats>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(new Vector3(transform.position.x + -8f * 
        Time.deltaTime, transform.position.y, transform.position.z));
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.name == "Player")
        {
            if (isenemy)
            {
                lc.health -= 1;
            }
            else
                lc.score += 200; 
        }

        if (hit.gameObject.name == "Player" || hit.gameObject.name == "Offscreen")
        {
            Destroy(gameObject);
        }
    }
}
