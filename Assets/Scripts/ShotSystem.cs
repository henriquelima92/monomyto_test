using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSystem
{
    [SerializeField]
    private List<GameObject> prefabs;
    [SerializeField]
    private List<int> shotsAmount;
    [SerializeField]
    private int shotSelected;
    public ShotSystem()
    {
        shotSelected = 0;
        shotsAmount = new List<int> {10,10,10};
    }

    public void Tick()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateShot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeShotType();
        }
    }

    private void ChangeShotType()
    {
        shotSelected = (shotSelected < shotsAmount.Count-1) ? (shotSelected += 1) : 0;
        Debug.Log("change to shot index: " + shotSelected);
    }

    private void CreateShot()
    {
        if(shotsAmount[shotSelected] > 0)
        {
            shotsAmount[shotSelected] -= 1;
            Debug.Log("shoot with shot index: " + shotSelected);
            Debug.Log("shots left: " + shotsAmount[shotSelected]);
        }
        else
        {
            Debug.Log("out of shots with index: " + shotSelected);
        }
    }
}
