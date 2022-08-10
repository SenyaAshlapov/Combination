using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AbilityCell : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _colored;
    [SerializeField] private TMP_Text  _description;
    public void InitAbilityCell(Sprite newIcon, string newDescription, Color32 newColor){
        _icon.sprite = newIcon;
        _description.text = newDescription;
        _colored.color = newColor;
    }
}
