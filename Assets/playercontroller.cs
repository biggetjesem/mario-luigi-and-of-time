using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody body;
    public float x;
    public float y;
    public float z;
    public float movespeed;
    public float jumpheight;
    public float gravity;
    public int side;

    public bool floored = true;
    // Start is called before the first frame update
    void Start()
    {
           body = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y == 0){
            floored = true;
        }
        else{
            floored = false;
        }
        //vertical
        if(Input.GetKey("w")){
            z = 1;
            side = 1;
        } else if(Input.GetKey("s")){
            z = -1;
            side = 3;
        }else {
            z = 0;
        }
        //horizontal
        if(Input.GetKey("a")){
            x = -1;
            side = 4;
        } else if(Input.GetKey("d")){
            x = 1;
            side = 2;
        }else {
            x = 0;
        }
        //jump
        if(Input.GetKey(KeyCode.Space) || Input.GetKey("e")){
            if (floored == true){
            y = 1 * jumpheight;
            floored = false;
            }
        }
        if (floored == false){
            y = y - gravity;
        }
        else {
            y = 0;
        }
            

      body.velocity = new Vector3(x * movespeed , y , z * movespeed); 
    }
}
