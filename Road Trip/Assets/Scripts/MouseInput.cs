using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;
    public int readDistance = 5;
    private float xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        transform.Rotate(0, mouseX, 0.0f);


        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast (ray, out hit, readDistance))
            {
                GameObject obj = hit.transform.gameObject;
                SignText text = obj.GetComponent<SignText>();
                if(text != null)
                {
                    text.setClicked();
                } 
            }
        }
    }
}
