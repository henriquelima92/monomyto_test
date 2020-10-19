using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Entity entity;
    [SerializeField]
    private Image barFillImage;

    private void Start()
    {
        if(entity != null)
        {
            entity.GetHealthSystem().OnHealthChange += ChangeFill;
        }
    }
    private void OnDestroy()
    {
        if(entity != null)
        {
            entity.GetHealthSystem().OnHealthChange -= ChangeFill;
        }
    }

    private void ChangeFill(float health)
    {
        barFillImage.fillAmount = (health/100f);
    }
}
