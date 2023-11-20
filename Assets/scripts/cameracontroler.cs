using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cameracontroler : MonoBehaviour
{
    //public Transform player;
    public float followSpeed = 0.5f;
       public float xvalue ;
       public float zvalue ;

    private Vector3 Offset;
   public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
         player = FindObjectOfType<PlayerScript>();   
        Offset = transform.position - player.transform.position;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 transformPosition = player.transform.position + Offset;
        Vector3 campos = transform.position;
        campos.x = player.transform.position.x + xvalue;
        campos.z = player.transform.position.z + zvalue;
        transform.position = campos;
        // Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

    }
}

