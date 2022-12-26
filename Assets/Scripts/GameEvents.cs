using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class IntEvent : UnityEvent<int> {}
    public class FloatEvent : UnityEvent<float> {}
    public class StringEvent : UnityEvent<string>{}

    public class GameEvents :MonoBehaviour
    {
        private PlayerController player;
        private HudController hud;
        private Interactable interactable;
        
        public delegate void OnInteractable();

        static public UnityEvent<int> OnLevelUp = new UnityEvent<int>();
        static public UnityEvent<float> OnTakeDamage = new UnityEvent<float>();
        static public UnityEvent<int> UpdateGold = new UnityEvent<int>();
        static public UnityEvent<int> UpdateXp = new UnityEvent<int>();
        static public UnityEvent<float> UpdateStamina = new UnityEvent<float>();

        public static event OnInteractable OnInteracted; 
        public static event OnInteractable OnGizmosEntered;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            hud = GameObject.FindGameObjectWithTag("HudController").GetComponent<HudController>();
            interactable = GameObject.FindObjectOfType<Interactable>();

            //player.OnItemCollected += interactable.ItemCollected;
            
        }
        

    }
    

/* Enventos C#. São sempre associados a um Delegate (tipo de variável que permite armazenação de métodos (ou vários métodos)) 
   Ao utilizar um evento, devemos sempre verificar se existe algo relacionado a ele. 
   if(evento!=null)
   {
        bloco
   }

   Quando alguma coisa acontece, e nós chamamos um evento para aquilo, precisamos notificar o script desejado de que aquele
   evento aconteceu. Assim?
   if(PlayerPegouItem)
   {
        if(onPlayerPegarItem != null)
        {
            onPlayerPegarItem();
        }
   }

   Script do item:

    player.onPlayerPegarItem += EquiparItem();

    Assim, nós recebemos o evento, notificando que pegamos o item, e utilizaremos o evento com um método da classe player
    para equipar aquele item.

    Para declarar um delegate, nós declaramos um delegate (delegate void method())
    tem que ter o mesmo retorno, e os mesmos parâmetros. 
    Depois declaramos uma variável com o mesmo tipo e parâmetros do Delegate: 
    
    method variavel;
    
    Depois criamos um método que é o que associaremos ao delegate
    
    void attack()

    após isso, associamos o delegate ao método assim:

    method = attack

*/ 
