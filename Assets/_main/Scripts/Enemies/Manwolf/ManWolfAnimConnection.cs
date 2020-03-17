using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManWolfAnimConnection : MonoBehaviour
{
    public FSM_Manwolf manWolf;

    public void ActivatePunch()
    {
        manWolf.punchBox.enabled = true;
    }

    public void DeactivatePunch()
    {
        manWolf.punchBox.enabled = false;
    }

    public void ActivateAreaAttack()
    {
        manWolf.areaBox.enabled = true;
    }

    public void DeactivateAreaAttack()
    {
        manWolf.areaBox.enabled = false;
    }
}
