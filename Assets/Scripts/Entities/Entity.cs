using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected State currentState;
    public void SetState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnStateEnter();
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
