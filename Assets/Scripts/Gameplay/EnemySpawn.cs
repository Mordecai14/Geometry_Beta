using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5, 5);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //float rand = Random.Range(3, 5);
        Vector3 pos = transform.position;
        transform.position = pos;
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
