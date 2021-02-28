using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject shape;

    [SerializeField]
    int NumOfObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i= 0; i < NumOfObjects; i++)
        {
            Instantiate(shape, new Vector2(Random.Range(-25, 25), Random.Range(-25, 25)), new Quaternion(0, 0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
