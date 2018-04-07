 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
    public float up_speed = 0.1f;
    public float side_speed = 0.2f;
    public int one_place_hight = 4;
    public float delta_rotation = 22.5f;

    public GameObject in_platform;
    public GameObject car_on_platform;

    // Use this for initialization
    void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePlatform(3, 3);
    }

    void InPlatformMoveOut()
    {
        if (in_platform.transform.localPosition != new Vector3(0, 0, 1))
        {
            in_platform.transform.Translate(0, 0, side_speed);
            car_on_platform.transform.Translate(0, 0, side_speed);
        }
        else { }
    }

    void AllPlatformMove(Vector3 finish_position)
    {
        if (transform.localPosition != finish_position)
        {
            transform.Translate(0, up_speed, 0);
        }
    }

    void AllPlatformRotate(Quaternion finish_position)
    {
        if (transform.localRotation != finish_position)
        {
            transform.Rotate(new Vector3(0, 1, 0), 1);
        }
    }

    void MovePlatform(int column, int parking_place)
    {

        float rotation = column * delta_rotation;
        Quaternion finish_rotation = Quaternion.Euler(0, rotation, 0);
        int hight = parking_place * one_place_hight;
        Vector3 finish_vector = new Vector3(0, hight, 0);

        if (transform.localPosition == finish_vector && transform.rotation == finish_rotation)
        {
            InPlatformMoveOut();
        }
        else
        {
            AllPlatformMove(finish_vector);
            AllPlatformRotate(finish_rotation);
        }
    }

}
