using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    public float spriteLength;
    public float startOffset;
    public float speed;

    private float startPos;

    void Start()
    {
        startPos = mainCamera.transform.position.y;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        mainCamera.transform.Translate(Vector3.up * speed * Time.deltaTime);
        float cameraY = mainCamera.transform.position.y;
        float deltaY = (cameraY - startPos) * (1 - startOffset);

        // Calculate the new Y position for the sprite
        float newYPos = transform.position.y + deltaY;

        // Update the position of the sprite
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);

        // If the camera has moved past the length of the sprite, adjust the start position
        if (cameraY > startPos + spriteLength)
        {
            transform.position += Vector3.up * spriteLength;
            startPos += spriteLength;
        }
        // If the camera has moved back, adjust the start position accordingly
        else if (cameraY < startPos - spriteLength)
        {
            transform.position -= Vector3.up * spriteLength;
            startPos -= spriteLength;
        }
    }
}

//https://www.youtube.com/watch?v=H6q-Y5JAiDk&ab_channel=KeeGamedev