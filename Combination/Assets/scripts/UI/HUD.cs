using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("shot cell")]
    [SerializeField] private Image _shotCell;
    [SerializeField] private Image _shotCellColored;
    [Header("health cell")]
    [SerializeField] private Image _healthCell;
    [SerializeField] private Image _healthCellColored;
    [Header("move cell")]
    [SerializeField] private Image _moveCell;
    [SerializeField] private Image _moveCellColored;

    private void Awake()
    {
        CombatAbilityData.UpdateCombatAbilityUI += updateShotCells;
        MoveAbilityData.UpdateMoveAbilityUI += updateMoveCells;
        HealthData.UpdateHealthAbilityUI += updateHealthCells;
    }

    private void OnDestroy()
    {
        CombatAbilityData.UpdateCombatAbilityUI -= updateShotCells;
        MoveAbilityData.UpdateMoveAbilityUI -= updateMoveCells;
        HealthData.UpdateHealthAbilityUI -= updateHealthCells;
    }

    private void updateShotCells(Sprite newIcon, Color32 newColor)
    {
        updateCell(_shotCell, _shotCellColored, newIcon, newColor);
    }

    private void updateMoveCells(Sprite newIcon, Color32 newColor)
    {
        updateCell(_moveCell, _moveCellColored, newIcon, newColor);
    }

    private void updateHealthCells(Sprite newIcon, Color32 newColor)
    {
        updateCell(_healthCell, _healthCellColored, newIcon, newColor);
    }

    private void updateCell(Image Icon, Image IconColored, Sprite newIcon, Color32 newColor)
    {
        Icon.sprite = newIcon;
        IconColored.color = newColor;
    }
}
