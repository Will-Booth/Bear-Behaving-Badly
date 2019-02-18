using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject Platform;

    public float MoveSpeed;

    public Transform CurrentPoint;

    public Transform[] Points;

    public int PointSelection;

	// Use this for initialization
	void Start ()
    {
        CurrentPoint = Points[PointSelection];
	}
	
	// Update is called once per frame
	void Update ()
    {
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, CurrentPoint.position, Time.deltaTime * MoveSpeed);

        if(Platform.transform.position == CurrentPoint.position)
        {
            PointSelection++;

            if(PointSelection == Points.Length)
            {
                PointSelection = 0;
            }

            CurrentPoint = Points[PointSelection];
        }
	}
}
