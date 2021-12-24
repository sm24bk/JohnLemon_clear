using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 20f;
    Vector3 movement; //전역변수, 멤버변수
    Quaternion rotation;

    Animator animator;//전역변수, 멤버변수
    Rigidbody rigidbody;

    AudioSource AudioSource;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    {
        //WASD 버튼을 눌렀을 때 움직임
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0f, vertical);
        movement.Normalize();

        Vector3 desiredForward;
        desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);

        rotation = Quaternion.LookRotation(desiredForward);

        //transform.position = transform.position + movement * Time.deltaTime * speed;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
                                   //(Mathf.Approximately(horizontal, 0f) == false);

        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

       
        // || OR 연산. 둘중 하나만 참이여도 참이 됨 
        // && AND 연산. 둘 모두 참이여야 참이 됨
        bool iswalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("IsWalk", iswalking);

        if(iswalking)
        {
            if(!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
        }
        else 
        {
            AudioSource.Stop();
        }
    }

    
    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + movement * animator.deltaPosition.magnitude);
        rigidbody.MoveRotation(rotation);
    }
}
