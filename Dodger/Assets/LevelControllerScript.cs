// Alexander Peterson
// 4/19/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    public float maxSpawnTime;
    public float spawnTime;
    public GameObject point;
    public GameObject enemy;
    public Vector2 cameradim;
    public float challengerate;
    public float lasttime;
    public float spawncap;
    // Start is called before the first frame update
    void Start()
    {
        //gets camera dimensions and sets up spawn 
        cameradim = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
        Camera.main.transform.position.z));
        cameradim.x += 3f;
        cameradim.y -= 0.5f;
        spawnTime = maxSpawnTime;
        lasttime = spawnTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer for spawning
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            //generates random floats and ints for spawning
            float spawnheight = Random.Range(cameradim.y, cameradim.y * -1);
            int whatobj = Random.Range(0, 11);

            //spawns obsticals randomly along the y value of the spawn position
            if (whatobj >= 9)
            {
                Instantiate(point, new Vector3(cameradim.x, spawnheight, 0), Quaternion.identity);
            }
            else
                Instantiate(enemy, new Vector3(cameradim.x, spawnheight, 0), Quaternion.identity);
            spawnTime = lasttime * challengerate;
            //sets timer again and caps it
            if (lasttime > spawncap)
            {
                lasttime = spawnTime;
            }
            else
                lasttime = spawncap;
        }
    }
}
