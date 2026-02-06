using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class L1BattleController : MonoBehaviour
{
    [Header("选项指针")]
    public GameObject arrowToAttack;
    public GameObject arrowToDefence;

    [Header("选项花费")]
    public float attackCost = 15f;
    public float defenceCost = 5f;
    public TextMeshProUGUI costText;

    void Update()
    {
        ArrowController();
        CostTextController();
    }

    void ArrowController()
    {
        bool ok1 = arrowToAttack.activeInHierarchy;
        bool ok2 = arrowToDefence.activeInHierarchy;
        float x = Input.GetAxis("Horizontal");
        if (x > 0)
        {
            if (ok1 && !ok2)
            {
                arrowToAttack.SetActive(false);
                arrowToDefence.SetActive(true);
            }
        }
        else if (x < 0)
        {
            if (!ok1 && ok2)
            {
                arrowToAttack.SetActive(true);
                arrowToDefence.SetActive(false);
            }
        }
    }

    void CostTextController()
    {
        bool ok1 = arrowToAttack.activeInHierarchy;
        bool ok2 = arrowToDefence.activeInHierarchy;

        if (ok1 && !ok2)
        {
            costText.text = "花费：" + attackCost.ToString();
        }else if (!ok1 && ok2)
        {
            costText.text = "花费：" + defenceCost.ToString();
        }
    }
}
