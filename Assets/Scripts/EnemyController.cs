using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Objective
{
    public GameObject[] Objectives;
}
public class EnemyController : MonoBehaviour
{
    public Objective obj;
    [SerializeField]int targetRand;
    [SerializeField]float speed;
    float step;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        moveToTarget();
    }

    void moveToTarget()
    {
        step = speed * Time.deltaTime;
        if(obj.Objectives.Length == 0)
        {
            obj.Objectives = GameObject.FindGameObjectsWithTag("objective");
        }
        targetRand = Random.Range(0, 3);
        transform.position = Vector3.MoveTowards(transform.position, obj.Objectives[targetRand].transform.position, step);
    }
}
