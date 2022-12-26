using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public delegate void UiInteraction();
    public static event UiInteraction InteractButtonPressed;
    public static event UiInteraction InventoryInteraction;
    


    private Image image;
    public GameObject buttonGo;
    
    private GameObject Diary;
    private TMP_Text diaryText;
    private Transform DiaryTf;
    public GameObject DCloseButton;

    private Vector3 ScaleClose = new Vector3(0,0,0);
    private Vector3 ScaleOpen = new Vector3(1,1,1);

    private GameObject MainMenu;
    private Transform MainMenuTf;

    void Awake()
    {
        //image = GameObject.FindGameObjectWithTag("InteractionButton").GetComponent<Image>();
        buttonGo = GameObject.FindGameObjectWithTag("InteractionButton").gameObject;
        buttonGo.SetActive(false);
        Diary = GameObject.FindGameObjectWithTag("Diary");
        diaryText = Diary.GetComponentInChildren<TMP_Text>();
        DiaryTf = Diary.GetComponent<Transform>();
        CloseDiary();
        MainMenuTf = GameObject.FindGameObjectWithTag("MainMenu").transform;
        
        
        ButtonActions.OnDiaryOpenButton += OpenDiary; //vincula todos os eventos de inteção dos botões de ação com métodos da classe
        ButtonActions.OnDiaryCloseButton += CloseDiary;
        ButtonActions.OnCloseMenuButton += CloseMainMenu;
        ButtonActions.OnMenuButton += OpenMainMenu;
        
    }

    void Update()
    {
        OnItemInteracted(); //verifica a cada frame se alguma interação está acontecendo
        OnItemInteractionOver();
        OpenInventory();
    }
    void TurnInteractButtonOn()
    {
        buttonGo.SetActive(true); //liga a imagem de interação quando nos aproximamos de um item
        
    }

    void TurnInteractButtonOff()
    {
        buttonGo.SetActive(false); //desliga a imagem de interação quando nos afastamos
    }
    public void OnItemInteracted()
    {
        //Interactable.ItemInteracted -= TurnInteractButtonOff;
        Interactable.ItemInteracted += TurnInteractButtonOn;
        
    }

    public void OnItemInteractionOver()
    {
        Interactable.ItemInteractionOver += TurnInteractButtonOff;
    }

    private void OpenInventory()
    {
        if(InputState.invetoryButton)
        {
            if(InventoryInteraction != null)
            {
                InventoryInteraction();
            }
        }
    }
    private void OpenDiary()
    {
        //responsável por abrir o diário
        DiaryTf.localScale = ScaleOpen; //aumenta a escala do diário
        DCloseButton.SetActive(true); //liga o botão de fechar o diário
    }
    
    private void CloseDiary()
    {
        DiaryTf.localScale = ScaleClose; //diminui a escala do diário pra 0, fazendo ele sumir
        Debug.Log("teste");
        DCloseButton.SetActive(false); //ativa o gameobject do botão de fechar o diário
    }
    private void OpenMainMenu()
    {
        MainMenuTf.localScale = new Vector3(1,1,1); //aumenta a escala do menu pra 1, em todos os eixos
    }
    private void CloseMainMenu()
    {
        MainMenuTf.localScale = new Vector3(0,0,0); //diminui a escala do menu pra 0
    }

}
