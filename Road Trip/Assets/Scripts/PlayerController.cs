using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    
    private CharacterController characterController;

    private Text text;
    private int fontSize = 28;
    private int textWidth = 450;
    private int textHeight = 450;
    private int initialDelay = 10;

    private bool sitting = false;
    private int sittingDistance = 5;

    private Vector3 prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        text = GetComponentInChildren<Text>();
        text.fontSize = fontSize;
        text.rectTransform.sizeDelta = new Vector2(textWidth, textHeight);

        StartCoroutine(ShowInitialText(initialDelay));
    }

    IEnumerator ShowInitialText(int delay)
    {
        text.enabled = true;
        yield return new WaitForSeconds(initialDelay);
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject bench = GameObject.FindWithTag("Bench");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sitting)
            {
                this.transform.position = prevPosition;
                sitting = false;
            }
            else
            {
                if (Vector3.Distance(this.transform.position, bench.transform.position) < sittingDistance)
                {
                    prevPosition = this.transform.position;
                    this.transform.position = bench.transform.position;
                    sitting = true;
                }
            }
        }

        if (!sitting) {
            //prevPosition = this.transform.position;
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
            float vertical = Input.GetAxis("Vertical") * movementSpeed;
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = transform.rotation * moveDirection;
            characterController.SimpleMove(moveDirection);
        }

        //UnityEngine.Debug.Log("prevPosition = (" + prevPosition.x + ", " + prevPosition.y + ", " + prevPosition.z + ")");


    }
}
