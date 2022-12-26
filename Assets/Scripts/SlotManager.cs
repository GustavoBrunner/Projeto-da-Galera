using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    
    public Image image; //referenciado direto no editor da Unity
    [SerializeField]
    public List<Interactable> slotItems = new List<Interactable>(); 
    public bool isOccupied; //variável de controle para saber se o slot tá ou não ocupado

    public Interactable ActualItem;//variável para armazenar o item atual do slot
    
    protected void Awake()
    {
        image.enabled = false;
        isOccupied = false;
        
    }

    protected void Update()
    {
        ActualIcon();
    }

    public void ItemStored(Interactable item)
    {
        //troca a variável de ocupação para verdadeira, o item atual pro que foi pego
        //e desliga o gameobject do item que foi pego
        isOccupied = true;
        ActualItem = item;
        slotItems.Add(item);
        Debug.Log(slotItems[0].name);
        item.gameObject.active = false;
        ActualIcon();
        
        
    }

    public void SlotCleared()
    {
        image.sprite = null;
        image.enabled = false;
    }
    void ActualIcon()
    {
        if(InventorySystem.isOpened && isOccupied)
        {
            image.enabled = true;
            image.sprite = ActualItem.icon.sprite; //passa a sprite do item atual para o slot
                 
        }
        else
        {
            image.enabled = false;// se o inventário não tiver aberto, e não estiver ocupado, tudo fica nulo ou falso
            image.sprite = null;
        }
        
    }

    //pensar em uma lógica que, quando ligar o inventário retornará o item que tá no slot, e passar o sprite pro icon
}
