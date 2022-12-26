using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public delegate void ActionButtonInteractionHandler();
    public static event ActionButtonInteractionHandler OnDiaryOpenButton;
    public static event ActionButtonInteractionHandler OnDiaryCloseButton;
    public static event ActionButtonInteractionHandler OnMenuButton;
    public static event ActionButtonInteractionHandler OnCloseMenuButton;
    public static event ActionButtonInteractionHandler OnSaveButton;
    public static event ActionButtonInteractionHandler OnLoadButton;

    
    public void OnDiaryButtonPressed()
    {
        //verifica quando o botão do diário foi pressionado e já chama o evento de interação com o botão
        if(OnDiaryOpenButton != null)
        {
            OnDiaryOpenButton();
        }
    }

    public void OnDiaryCloseButtonPressed()
    {
        //verifica quando o botão de fechar o diário foi apertado, e chama o evento
        if(OnDiaryCloseButton != null)
        {
            OnDiaryCloseButton();
        }
    }
    public void OnSaveButtonPressed()
    {
        if(OnSaveButton != null)
        {
            OnSaveButton();
        }
    }
    public void OnMenuButtonPressed()
    {
        if(OnMenuButton != null)
        {
            OnMenuButton();
        }
    }
    public void OnCloseMenuButtonPressed()
    {
        if(OnCloseMenuButton != null)
        {
            OnCloseMenuButton();
        }
    }
    public void OnLoadButtonPressed()
    {
        if(OnLoadButton != null)
        {
            OnLoadButton();
        }
    }
}    
    
