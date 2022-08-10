using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum randomCellType
{
    Combat,
    Move
}
public class AbilityStore : MonoBehaviour
{
    public delegate void StoreMoveAction(MoveAbilityData data);
    public static StoreMoveAction UpdateMoveAbility;

    public delegate void StoreCombatAction(CombatAbilityData data);
    public static StoreCombatAction UpdateCombatAbility;

    [SerializeField] private List<MoveAbilityData> _moveAbilityList = new List<MoveAbilityData>();
    [SerializeField] private List<CombatAbilityData> _combatAbilityList = new List<CombatAbilityData>();

    [SerializeField] private AbilityCell _abilityCellCombat;
    [SerializeField] private AbilityCell _abilityCellMove;
    [SerializeField] private AbilityCell _abilityCellRandom;

    private MoveAbilityData _moveAbility;
    private CombatAbilityData _combatAbility;

    private MoveAbilityData _randomMoveAbility;
    private CombatAbilityData _randomCombatAbility;

    private randomCellType _ramdomCellType;

    private void Awake() {
        WaveSpawner.WaveEnd += generateAbilitis;
        WaveSpawner.WaveStart += hideAll;
    }
    private void generateAbilitis()
    {
        _abilityCellCombat.gameObject.SetActive(true);
        _abilityCellMove.gameObject.SetActive(true);
        _abilityCellRandom.gameObject.SetActive(true);

        _moveAbility = generateMoveAbility();
        _abilityCellMove.InitAbilityCell(_moveAbility.Icon, _moveAbility.Description, _moveAbility.Color);

        _combatAbility = generateCombatAbility();
        _abilityCellCombat.InitAbilityCell(_combatAbility.Icon, _combatAbility.Description, _combatAbility.Color);


        int randomCell = Random.Range(0, 1);

        if (randomCell == 1)
        {
            _ramdomCellType = randomCellType.Combat;

            _randomCombatAbility = generateCombatAbility();
            _abilityCellRandom.InitAbilityCell(_randomCombatAbility.Icon, _randomCombatAbility.Description, _randomCombatAbility.Color);

        }
        else
        {
            _ramdomCellType = randomCellType.Move;

            _randomMoveAbility = generateMoveAbility();
            _abilityCellRandom.InitAbilityCell(_randomMoveAbility.Icon, _randomMoveAbility.Description, _randomMoveAbility.Color);
        }



    }

    private void hideAll(){
        _abilityCellCombat.gameObject.SetActive(false);
        _abilityCellMove.gameObject.SetActive(false);
        _abilityCellRandom.gameObject.SetActive(false);
    }

    private MoveAbilityData generateMoveAbility()
    {
        int size = _moveAbilityList.Count;
        Debug.Log(size);

        var randomMoveAbility = _moveAbilityList[Random.Range(0, size)];

        return randomMoveAbility;
    }

    private CombatAbilityData generateCombatAbility()
    {
        int size = _combatAbilityList.Count;
        Debug.Log(size);

        var randomCombatAbility = _combatAbilityList[Random.Range(0, size)];

        return randomCombatAbility;
    }



    public void SelectNewRandomAbility()
    {
        if (_ramdomCellType == randomCellType.Combat)
        {
            updateNewCombatAbility(_randomCombatAbility);
        }
        else
        {
            updateNewMoveAbility(_randomMoveAbility);
        }

        hideAll();
    }
    public void SelectNewMoveAbility()
    {
        updateNewMoveAbility(_moveAbility);

        hideAll();
    }
    public void SelectNewCombatAbility()
    {
        updateNewCombatAbility(_combatAbility);

        hideAll();
    }

    private void updateNewCombatAbility(CombatAbilityData newCombatAbility)
    {
        UpdateCombatAbility?.Invoke(newCombatAbility);
    }

    private void updateNewMoveAbility(MoveAbilityData newMoveAbility)
    {
        UpdateMoveAbility?.Invoke(newMoveAbility);
    }
}
