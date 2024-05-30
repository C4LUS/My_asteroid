using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.0f;
    public Camera main_camera;
    private Rigidbody2D rb;
    private Vector2 move_input;
    private Vector2 move_velocity;
    private float offset = 1.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move_x = Input.GetAxis("Horizontal");
        float move_y = Input.GetAxis("Vertical");
  
        move_input = new Vector2(move_x, move_y);
        move_velocity = move_input.normalized * speed;
    }

    void FixedUpdate()
    {
        Vector2 new_pos = rb.position + move_velocity * Time.fixedDeltaTime;

        float camHeight = main_camera.orthographicSize;
        float camWidth = main_camera.aspect * camHeight;

        float minX = main_camera.transform.position.x - camWidth + offset;
        float maxX = main_camera.transform.position.x + camWidth - offset;
        float minY = main_camera.transform.position.y - camHeight + offset;
        float maxY = main_camera.transform.position.y + camHeight - offset;

         
        new_pos.x = Mathf.Clamp(new_pos.x, minX, maxX);
        new_pos.y = Mathf.Clamp(new_pos.y, minY, maxY);
        main_camera.transform.position = new Vector3(main_camera.transform.position.x, main_camera.transform.position.y, main_camera.transform.position.z);
        rb.MovePosition(new_pos);
    }
}
