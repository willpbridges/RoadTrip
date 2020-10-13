using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;

public class SignText : MonoBehaviour
{
    public string textString;
    private Text text;

    private int fontSize = 28;
    private int textWidth = 400;
    private int textHeight = 200;

    private int textCloseDistance = 7;

    private bool clicked = false;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.fontSize = fontSize;
        text.rectTransform.sizeDelta = new Vector2(textWidth, textHeight);
        text.text = textString;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) > textCloseDistance)
        {
            clicked = false;
        }

        if(clicked)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }

    /*
    public void OnGUI()
    {
        if(clicked)
        {
            GUI.skin.label.fontSize = fontSize;
            GUI.Label(new Rect( (Screen.width / 2) - (textWidth / 2), (Screen.height / 2) - (textHeight / 2), 400, 100 ), text.text);
        }
    }
    */

    public void setClicked()
    {
        clicked = !clicked;
        UnityEngine.Debug.Log("Clicked = " + clicked);
    }
}
