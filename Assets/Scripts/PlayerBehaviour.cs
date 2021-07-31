using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody player;
    public float playerSpeed;

    public delegate void OnMovement();
    public static event OnMovement Onmovement;

    Animator animator;
    public LightningBehaviour lightningBehaviour;

    CurseBehavior curseBehavior;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Cursor.visible = false;
        Onmovement += PlayerMovement;
        curseBehavior = FindObjectOfType<CurseBehavior>();
        lightningBehaviour.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Onmovement();
    }


    void PlayerMovement()
    {
        if (Input.GetButton("Vertical"))
            player.velocity = Input.GetAxis("Vertical") * playerSpeed * transform.TransformDirection(Vector3.forward);
        else if (Input.GetButton("Horizontal"))
            player.velocity = Input.GetAxis("Horizontal") * playerSpeed * transform.TransformDirection(Vector3.right);
        else if (!Input.GetButton("Vertical") || !Input.GetButton("Horizontal"))
            player.velocity = Vector3.zero;

        transform.Rotate(new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            animator.enabled = true;
            animator.Play("deathAnim");
        }

        if (other.tag == "House")
        {
            lightningBehaviour.enabled = true;
        }

        if (other.tag == "CursePlace")
        {
            curseBehavior.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "House")
        {
            lightningBehaviour.enabled = false;
        }

        if (other.tag == "CursePlace")
        {
            curseBehavior.enabled = false;
        }
    }
}
