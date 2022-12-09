using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    InputController ic = new InputController();
    public PlayerController player;
    // Start is called before the first frame update
    void Awake()
    {
        ic = FindObjectOfType<InputController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown((KeyCode)ic.menuButton))
            {
                SaveSystem.SavePlayer(player);
            }
            if(Input.GetKeyDown((KeyCode)ic.reloadButton))
            {
                Player_base data =  SaveSystem.LoadPlayer();
                player.GetData(data);
            }   
    }    
}
