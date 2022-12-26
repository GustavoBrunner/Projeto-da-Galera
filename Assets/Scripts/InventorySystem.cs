using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
[System.Serializable]
public class InventorySystem : MonoBehaviour
{
    [SerializeField]

    public delegate void ItemStore(Interactable item);
    public static event ItemStore ItemStored;
    public delegate void ClearSlot();
    public static event ClearSlot SlotCleared;
    
    [SerializeField]
    private List<SlotManager> slots = new List<SlotManager>();
    private List<Interactable> Itens = new List<Interactable>();

    Transform tf;
    
    public Image Inventory;
    public static bool isOpened ;

    
    
    public Image[] slot;
    

    

    Inventory inventory;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        //inventory = Inventory.instance;
        OnItemCollected();
        tf = GetComponent<Transform>();
        slots.AddRange(tf.GetComponentsInChildren<SlotManager>());
        Debug.Log(slots.Count);
        CloseInventory();
        
        
        UiController.InventoryInteraction += OnInventoryInteraction;
        
    }
    protected virtual void Update()
    {
        OnInventoryInteraction();
    }

    public void OnItemCollected()
    {
        Interactable.ItemCollected += PutItemInInventory;
    }

    void PutItemInInventory(Interactable item)
    {
        Itens.Add(item); //adiciona o item pego a uma lista de itens
          
        for (int i = 0; i < slots.Count; i++)
        {
            if(i < Itens.Count && slots[i].isOccupied != true)
            {
                slots[i].ItemStored(item);
                
            }
            else
            {
                Debug.Log("não é possível coletar o item");
            }
        }
    }

    public void OnInventoryInteraction()
    {
        
        if(isOpened != true)
        {
            UiController.InventoryInteraction += OpenInventory;
        }
        else
        {
            UiController.InventoryInteraction += CloseInventory;
        }
    }

    private void OpenInventory()
    { //liga todos os objetos responsáveis pelo inventário
        isOpened = true;
        Inventory.enabled = true;
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].enabled = true;
        }
    }

    private void CloseInventory()
    { //desliga todos os objetos responsáveis pelo inventário através do loop
        isOpened = false;
        Inventory.enabled = false;
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].enabled = false;
        }
    }
    


}
