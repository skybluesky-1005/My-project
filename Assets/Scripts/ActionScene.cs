using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ActionType
{
    Move, Heal, Attack, EnergyUp
}

public class ActionScene : MonoBehaviour
{
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button clearBtn;
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject actionCardsPanel;
    [SerializeField] private GameManager gameManager;

    [HideInInspector] public ActionSO[] selectActions = new ActionSO[3];
    private int slotsCount = 0;

    private void Awake()
    {
        continueBtn.interactable = false;
    }

    private void Update()
    {
        if (slotsCount == 3)
            continueBtn.interactable = true;
        else
            continueBtn.interactable = false;
    }

    public void ContinueBtn()
    {
        for (int i = 0; i < 3; i++)
            gameManager.actions[i] = selectActions[i];
        SceneManager.LoadScene(3);
    }

    public void ClearBtn()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(1).transform.parent = actionCardsPanel.transform;
            selectActions[i] = null;
        }
        slotsCount = 0;
    }

    public void ActionBtn(ActionSO actionSO)
    {
        GameObject currentBtn = EventSystem.current.currentSelectedGameObject;

        if (currentBtn.transform.parent.name == "ActionCardsPanel" && slotsCount <= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (slots[i].transform.childCount < 2)
                {
                    currentBtn.transform.parent = slots[i].transform;
                    currentBtn.transform.position = slots[i].transform.position;
                    selectActions[i] = actionSO;
                    slotsCount++;
                    break;
                }
            }
        }
        else
        {
            currentBtn.transform.parent = actionCardsPanel.transform;
            for (int i = 0; i < 3; i++)
            {
                if (actionSO == selectActions[i])
                {
                    selectActions[i] = null;
                    break;
                }
            }
            slotsCount--;
        }
    }
}
