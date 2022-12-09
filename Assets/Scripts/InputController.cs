using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public int moveRight;
    public int moveLeft;
    public int moveUp;
    public int moveDown;
    public int fireButton; 
    public int consumableButton;
    public int reloadButton;
    public int pauseButton;
    public int invetoryButton;
    public int menuButton;
    public int nextAttack;
    public int previousAttack;
    public List<int> keyList = new List<int>();

    private void Awake()
    {
        fireButton = 0;
        consumableButton = 1;

        moveRight = (int)KeyCode.D;
        moveLeft = (int)KeyCode.A;
        moveUp = (int)KeyCode.W;
        moveDown = (int)KeyCode.S;
        reloadButton = (int)KeyCode.R;
        pauseButton = (int)KeyCode.P;
        invetoryButton = (int)KeyCode.I;
        menuButton = (int)KeyCode.Escape;
        

        keyList.Add(nextAttack);
        keyList.Add(previousAttack);

    }

    private void Update()
    {
        InputState.menuButton = false;
        InputState.invetoryButton = false;
        InputState.pauseButton = false;
        InputState.reloadButton = false;

        if(Input.GetMouseButtonDown(fireButton))
        {
            InputState.fireButton = true;
        }
        if(Input.GetMouseButtonUp(fireButton))
        {
            InputState.fireButton = false;
        }
        if(Input.GetMouseButtonDown(consumableButton))
        {
            InputState.consumableButton = true;
        }
        if(Input.GetMouseButtonUp(consumableButton))
        {
            InputState.consumableButton = false;
        }
        
        if(Input.GetKeyDown((KeyCode)menuButton))
        {
            InputState.menuButton = true;
        }
        if(Input.GetKeyUp((KeyCode)menuButton))
        {
            InputState.menuButton = false;
        }
        if(Input.GetKeyDown((KeyCode)reloadButton))
        {
            InputState.reloadButton = true;
        }
        if(Input.GetKeyUp((KeyCode)reloadButton))
        {
            InputState.reloadButton = false;
        }
        if(Input.GetKeyDown((KeyCode)pauseButton))
        {
            InputState.pauseButton = true;
        }
        if(Input.GetKeyUp((KeyCode)pauseButton))
        {
            InputState.pauseButton = false;
        }
        if(Input.GetKeyDown((KeyCode)invetoryButton))
        {
            InputState.invetoryButton = true;
        }
        if(Input.GetKeyUp((KeyCode)invetoryButton))
        {
            InputState.invetoryButton = false;
        }





    }

}
