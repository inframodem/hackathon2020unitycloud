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
    private float lasttime;
    // Start is called before the first frame update
    void Start()
    {
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
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {

            float spawnheight = Random.Range(cameradim.y, cameradim.y * -1);
            int whatobj = Random.Range(0, 11);

            if (whatobj >= 9)
            {
                Instantiate(point, new Vector3(cameradim.x, spawnheight, 0), Quaternion.identity);
            }
            else
                Instantiate(enemy, new Vector3(cameradim.x, spawnheight, 0), Quaternion.identity);
            spawnTime = lasttime * challengerate;
            lasttime = spawnTime;

        }
    }
}
