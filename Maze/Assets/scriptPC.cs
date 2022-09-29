using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel = 10;
    private Quaternion rotOriginal;
    public float velRot = 100;
    private float rotY = 0;
    // private AudioSource som;
    public LayerMask alvo;
    public LayerMask mascara;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rbd = GetComponent<Rigidbody>();
        // som = GetComponent<AudioSource>();
        rotOriginal = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMENTO
        float moveFrente = Input.GetAxis("Vertical");
        float moveLado = Input.GetAxis("Horizontal");

        //ROTAÇÃO
        rotY += Input.GetAxisRaw("Mouse X") * velRot * Time.deltaTime;

        Quaternion lado = Quaternion.AngleAxis(rotY, Vector3.up);

        transform.localRotation = rotOriginal * lado;

        rbd.velocity = transform.TransformDirection(new Vector3(moveLado * vel, rbd.velocity.y, moveFrente*vel));
        
        //TIRO
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // som.Play();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100, alvo))
            {
                hit.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
