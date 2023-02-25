using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luigimovement : MonoBehaviour
{
    public Rigidbody body;
    [SerializeField]
    private GameObject mario;
    private playercontroller mariom;
    public float distance;
    public float correctingspeed = 10;
    public int check;

    public float luigiy;
    public bool luigifloored = true;
    public float lgravity;
    public float ljumpheight;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        mariom = mario.GetComponent<playercontroller>();
        lgravity = mariom.gravity;
        ljumpheight = mariom.jumpheight;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y == 0){
            luigifloored = true;
        }
        else{
            luigifloored = false;
        }
        if(Input.GetKey(KeyCode.Space) || Input.GetKey("q")){
            if (luigifloored == true){
            luigiy = 1 * ljumpheight;
            luigifloored = false;
            }
        }
        if (luigifloored == false){
            luigiy = luigiy - lgravity;
        }
        else {
            luigiy = 0;
        }
        if(mariom.x == 1 && mariom.z == 0){
            if (mario.transform.position.x - distance > transform.position.x && mario.transform.position.z - 0.3 < transform.position.z && mario.transform.position.z + 0.3 > transform.position.z){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,0);
            }
            else if (mario.transform.position.x - distance > transform.position.x && mario.transform.position.z > transform.position.z){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,0.8f * mariom.movespeed);
            }
            else if (mario.transform.position.x - distance > transform.position.x && mario.transform.position.z < transform.position.z){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,-0.8f * mariom.movespeed);
            }
        }    
        else if (mariom.x == -1 && mariom.z == 0){
            if (mario.transform.position.x + distance < transform.position.x && mario.transform.position.z - 0.3 < transform.position.z && mario.transform.position.z + 0.3 > transform.position.z){
            body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,0);
            }
            else if (mario.transform.position.x + distance < transform.position.x && mario.transform.position.z > transform.position.z){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,0.8f * mariom.movespeed);
            }
            else if (mario.transform.position.x + distance < transform.position.x && mario.transform.position.z < transform.position.z){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,-0.8f * mariom.movespeed);
            }
        }
                if(mariom.z == 1 && mariom.x == 0){
            if (mario.transform.position.z - distance > transform.position.z && mario.transform.position.x - 0.3 < transform.position.x && mario.transform.position.x + 0.3 > transform.position.x){
                body.velocity = new Vector3(0,0,mariom.z * mariom.movespeed);
                check = 1;
            }
            else if (mario.transform.position.z - distance > transform.position.z && mario.transform.position.x > transform.position.x){
                body.velocity = new Vector3(0.8f * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
                check = 2;
            }
            else if (mario.transform.position.z - distance > transform.position.z && mario.transform.position.x < transform.position.x){
                body.velocity = new Vector3(-0.8f * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
                check = 3;
            }
        }
        else if (mariom.z == -1 && mariom.x == 0){
            if (mario.transform.position.z + distance < transform.position.z && mario.transform.position.x - 0.3 < transform.position.x && mario.transform.position.x + 0.3 > transform.position.x){
            body.velocity = new Vector3(0,0,mariom.z * mariom.movespeed);
            }
            else if (mario.transform.position.z + distance < transform.position.z && mario.transform.position.x > transform.position.x){
                body.velocity = new Vector3(0.8f * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
                check = 2;
            }
            else if (mario.transform.position.z + distance < transform.position.z && mario.transform.position.x < transform.position.x){
                body.velocity = new Vector3(-0.8f * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
                check = 3;
            }
        }
        //diagonal
        if(mariom.x == 1 && mariom.z == 1){
            if (mario.transform.position.x - distance > transform.position.x && mario.transform.position.z - distance > transform.position.z){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
            }
        }
        else if (mariom.x == -1 && mariom.z == -1){
            if (mario.transform.position.x + distance < transform.position.x && mario.transform.position.z + distance < transform.position.z){            
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
            }
        }

                if(mariom.z == 1 && mariom.x == -1){
            if (mario.transform.position.z - distance > transform.position.z && mario.transform.position.x + distance < transform.position.x){
                body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
            }
        }
        else if (mariom.z == -1 && mariom.x == 1){
            if (mario.transform.position.z + distance < transform.position.z && mario.transform.position.x - distance > transform.position.x){
            body.velocity = new Vector3(mariom.x * mariom.movespeed,luigiy,mariom.z * mariom.movespeed);
            }
        }
        if (mariom.z == 0 && mariom.x == 0){
            body.velocity = new Vector3(0,luigiy,0);
        }
    }
}
