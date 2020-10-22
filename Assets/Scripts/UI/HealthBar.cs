using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Entity entity;
    [SerializeField]
    private Image barFillImage;
    private float startHealth;

    private void Start()
    {
        if (entity != null)
        {
            entity.GetHealthSystem().OnHealthChange += ChangeFill;
            startHealth = entity.GetHealthSystem().GetHealthAmount();
            ChangeFill(startHealth);
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
        barFillImage.fillAmount = (health/startHealth);
    }
}
