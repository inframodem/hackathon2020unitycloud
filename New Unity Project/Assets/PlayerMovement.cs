using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D playercoll;
    public float playerspeed;
    private Vector2 cameradim;
    public float playerx;
    public float playery;
    // Start is called before the first frame update
    void Start()
    {
        cameradim = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
        Camera.main.transform.position.z));
        playerx = playercoll.bounds.size.x / 2f;
        playery = playercoll.bounds.size.y / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float xspeed = Input.GetAxis("Horizontal") * playerspeed;
        float yspeed = Input.GetAxis("Vertical") * playerspeed;
        rb.MovePosition(new Vector3(transform.position.x + xspeed * Time.deltaTime, 
            transform.position.y + yspeed * Time.deltaTime, transform.position.z));

    }

    void LateUpdate()
    {
        Vector3 camerapos = transform.position;
        camerapos.x = Mathf.Clamp(camerapos.x, cameradim.x * -1f + playerx, cameradim.x - playerx);
        camerapos.y = Mathf.Clamp(camerapos.y, cameradim.y * -1 + playery, cameradim.y - 
            playery - 0.3f);
        transform.position = camerapos;
    }
}
