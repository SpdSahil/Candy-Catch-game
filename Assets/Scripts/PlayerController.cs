using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public bool isMovable = true;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float maxPosition;

    void Update()
    {
        if (isMovable)
        {
            Move();
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.position.x, -maxPosition, maxPosition);

        transform.position = new Vector3 (xPos, transform.position.y, transform.position.z);
    } 
}
