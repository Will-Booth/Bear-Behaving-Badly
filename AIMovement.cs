using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    public GameObject Player;
    public Transform[] PathPoints;
    private Transform CurrentPathPoints;
    public int CurrentPath = 0;
    public float ReachDistance = 5.0f;

    private Vector2 currentpos;
    private Vector2 targetpos;
    private Vector3 distance;

   

    public float speed;
    public int CurrentIndex;

    private SpriteRenderer flip;
   

	// Use this for initialization
	void Start ()
    {
        CurrentIndex = 0;
        Debug.Log(CurrentIndex);

        speed = 0.5f;
        flip = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Debug.Log(CurrentIndex);
        if(CurrentIndex == 0) 
        {
            MoveRight();
          
        }
        else if(CurrentIndex == 1)
        {
            MoveLeft();
        }

        //Attacking the player

        

       
    }

    private void MoveRight()
    {
        flip.flipX = false;
        currentpos = this.transform.position;
        targetpos = PathPoints[0].transform.position;
        distance = currentpos - targetpos;
        distance.Normalize();
        this.transform.Translate(-distance.x * speed * Time.deltaTime, -distance.y * speed * Time.deltaTime, distance.z * speed * Time.deltaTime, Space.World);
       // Debug.Log("Over Here!");
        NextWayPoint();
    }

    private void MoveLeft()
    {
        flip.flipX = true;
        currentpos = this.transform.position;
        targetpos = PathPoints[1].transform.position;
        distance = currentpos - targetpos;
        distance.Normalize();
        this.transform.Translate(-distance.x * speed * Time.deltaTime, -distance.y * speed * Time.deltaTime, distance.z * speed * Time.deltaTime, Space.World);
       // Debug.Log("Moving On");
        NextWayPoint();
       

    }


    public void OnDrawGizmos()
    {
        if (PathPoints == null)
        {
            return;
        }
        foreach (Transform PathPoint in PathPoints)
        {
            if (PathPoint )
            {
                Gizmos.DrawSphere(PathPoint.position,ReachDistance);
            }
        }
    }


    private void NextWayPoint()
    {
       
        if (Vector2.Distance(this.transform.position,PathPoints[CurrentIndex].transform.position) < 1)
        {
            if (CurrentIndex == 0)
            {
                CurrentIndex = 1;
            }
            else if (CurrentIndex == 1)
            {
                CurrentIndex = 0;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Hit!");
        }
    }


}


