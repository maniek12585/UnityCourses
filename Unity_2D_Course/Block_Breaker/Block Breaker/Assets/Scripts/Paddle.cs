using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWitdhInUnits=16f;
    Vector2 paddlePos;
    [SerializeField] float minX=1f;
    [SerializeField] float maxX=15f;
    private float mousePosInUnits;
    
    //cached references
    GameSession theGameSession;
    Ball theBall;
   
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        paddlePos = new Vector2 (transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(),minX,maxX);
        transform.position=paddlePos;
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWitdhInUnits;       
        }

    }
}
