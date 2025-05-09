using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxPosX;

    [Header(" Control Settings ")] 
    private float _clickedScreenX;
    private float _clickedPlayerX;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageControl();

    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickedScreenX = Input.mousePosition.x;
            _clickedPlayerX = transform.position.x;

        } else if (Input.GetMouseButton(0))
        {
            float xDiff = Input.mousePosition.x - _clickedScreenX;
            xDiff /= Screen.width;
            xDiff *= moveSpeed;
            
            float newPosX = Mathf.Clamp(_clickedPlayerX + xDiff, -maxPosX, maxPosX);
            transform.position = new Vector2(newPosX, transform.position.y);
            
            Debug.Log("X difference = " + xDiff);

        }
        
    }
    
}
