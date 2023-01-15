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
    [SerializeField] private Transform pfPowerUpSpread;
    [SerializeField] private Transform pfPowerUpSpeed;
    [SerializeField] private Transform pfPowerUpFireRate;
    float step;
    private Vector3 MugpieStrafe;
    float timer = 2;
    int Strafecount;

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
        //Sets a timer for the Mugpie Crow
        if(timer > -2)
        {
            timer -= Time.deltaTime;
        }
        //After counter reaches 2, Mugpie crow acts like regular crow
        if (gameObject.tag == "Mugpie" && Strafecount != 2)
        {
            //Mugpie Crow strafes up and right for 2 seconds
            if (timer > 0)
            {
                if(gameObject.transform.position.x < 0)
                {
                    MugpieStrafe = new Vector3(1, 1);
                }
                else
                {
                    MugpieStrafe = new Vector3(-1, 1);
                }
            }
            //Mugpie Crow strafes down and right for 2 seconds
            else if (timer < 0)
            {
                if (gameObject.transform.position.x < 0)
                {
                    MugpieStrafe = new Vector3(1, -1);
                }
                else
                {
                    MugpieStrafe = new Vector3(-1, -1);
                }
            }
            MugpieMove(MugpieStrafe);
        }
        else
        {
            moveToTarget();
        }
    }

    void MugpieMove(Vector3 Die)
    {
        transform.position += Die * speed * Time.deltaTime;
        //returns mugpie crow to state 1, and increments the counter by 1
        if (timer < -2)
        {
            timer = 2;
            Strafecount++;
        }
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
