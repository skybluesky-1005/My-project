using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public int maxHp = 100;
    public int energy = 100;
    public int maxEnergy = 100;

    [SerializeField] private GameObject enemy;
    private ActionSO[] actions;

    private void Awake()
    {
        actions = GameManager.instance.actions;
    }

    private void Start()
    {
        StartCoroutine(PlayAction(actions));
    }

    IEnumerator PlayAction(ActionSO[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            yield return new WaitForSeconds(1.5f);

            if (actions[i].action == ActionType.Move)
            {
                transform.Translate(actions[i].moveDir);
                if (transform.position.x < -2.3f) transform.position = new Vector3(-2.3f, transform.position.y, 0);
                else if (transform.position.x > 2.3f) transform.position = new Vector3(2.3f, transform.position.y, 0);
                else if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, 0);
                else if (transform.position.y > 2) transform.position = new Vector3(transform.position.x, 2, 0);
            }
            else if (actions[i].action == ActionType.Heal)
            {
                hp += actions[i].damage;
                if (hp > maxHp)
                    hp = maxHp;
            }
            else if (actions[i].action == ActionType.EnergyUp)
            {
                energy += actions[i].energy;
                if (energy > maxEnergy)
                    energy = maxEnergy;
            }
            else
            {
                energy += actions[i].energy;

                foreach (var point in actions[i].attackPoint)
                {
                    if (enemy.transform.position == (point + transform.position))
                    {
                        enemy.GetComponent<Enemy>().hp -= actions[i].damage;
                    }
                }
            }
        }
    }
}
