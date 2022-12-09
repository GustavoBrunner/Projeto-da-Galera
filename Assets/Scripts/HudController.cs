using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HudController : MonoBehaviour
{
    private Image hpBar;
    private Image staminaBar;
    private Slider healthBarSlider;
    Transform tf;

    private List<TMP_Text> text_hud = new List<TMP_Text>();

    TMP_Text lvHud;
    
    void Awake()
    {
        tf = GetComponent<Transform>();
        hpBar = GetComponentInChildren<Image>();
        staminaBar = GameObject.FindGameObjectWithTag("staminabar").GetComponent<Image>();

        this.healthBarSlider = GetComponentInChildren<Slider>(); 
        GameEvents.OnTakeDamage.AddListener(UpdateHealth);
        lvHud = GameObject.FindGameObjectWithTag("levelHud").GetComponent<TMP_Text>();
        lvHud.text = 1.ToString();
        text_hud.Add(tf.GetComponentInChildren<TMP_Text>());
        GameEvents.UpdateXp.AddListener(UpdateXp);
        GameEvents.OnLevelUp.AddListener(UpdateLevel);
        GameEvents.UpdateStamina.AddListener(UpdateStamina);
        
    }
    //pega a razão enviada através do invoke do evento, e passa ele para o fillamount da barra de vida.
    void UpdateHealth(float hp)
    {
        hpBar.fillAmount = hp;
    }

    //Recebe o evento invocado pelo Player e adiciona esse valor ao HUD
    void UpdateXp(int xp)
    {
        text_hud[0].text = xp.ToString();
        Debug.Log(xp);
    }
    void UpdateLevel(int level)
    {
        lvHud.text = level.ToString();
        
    }

    void UpdateStamina(float stamina)
    {
        staminaBar.fillAmount = stamina;
    }
}
