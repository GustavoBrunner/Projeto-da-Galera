
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Interactable : MonoBehaviour
{
    public delegate void ItemInterectedHandler();
    public delegate void ItemCollectedHandler(Interactable item);
    public static event ItemInterectedHandler ItemInteracted;
    public static event ItemInterectedHandler ItemInteractionOver;
    public static event ItemCollectedHandler ItemCollected; 
    public string name { get; protected set;}
    public int id { get; protected set;}

    public string type { get; protected set;}
    [SerializeField]
    public SpriteRenderer icon;
    Transform tf;
    Collider2D clldr;
    InputController ic;
    bool isIn = false;

    void Awake()
    {
        gameObject.tag = "Interactable";
        clldr = GetComponent<CircleCollider2D>();
        clldr.isTrigger = true;
        icon = GetComponentInChildren<SpriteRenderer>();
        ic = GameObject.FindObjectOfType<InputController>();
        
    }
    void Update()
    {
       PickItem();
    }
    //----------------------------------------------------------------------
    public void OnTriggerEnter2D(Collider2D other)
    {
        //verifica se o player entrou no trigger do item, se entrou, vai chamar o evento de interação
        if(other.gameObject.tag == "Player")
        {
            isIn = true;
            if(ItemInteracted != null)
            {
                ItemInteracted();
                Debug.Log("player in");
            }
        }
    }

     public void OnTriggerExit2D(Collider2D other)
     {
        //verifica se o player saiu do trigger do objeto
         if(other.gameObject.tag == "Player")
         {
            isIn = false;
             if(ItemInteractionOver != null)
             {
                ItemInteractionOver();
                Debug.Log("Player Leave");
             }
         }
     }
    void PickItem()
    {
        //verifica se o botão de ação foi apertado e se o player tá dentro do raio de
        //ação do item, se sim pra ambos, o item é coletado através do evento.
        if(InputState.actionButton && isIn)
        {
            if(ItemCollected != null)
            {
                ItemCollected(this);
            }
        }
    }
}
