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

        ButtonActions.OnLoadButton += LoadGame;
        ButtonActions.OnSaveButton += SaveGame; //linka o evento com a função de salvar o jogo
    }

    // Update is called once per frame
       

    private void SaveGame()
    {
        //usa a classe SaveSystem e o DTO do player para armazenar as informações
        SaveSystem.SavePlayer(player);
    }
    private void LoadGame()
    {
    
        Player_base data = SaveSystem.LoadPlayer();
        player.GetData(data);
    }
}
