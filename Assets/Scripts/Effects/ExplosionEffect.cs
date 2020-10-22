using UnityEngine;

public class ExplosionEffect
{
    private ParticleSystem particle;

    public ExplosionEffect(ParticleSystem particle)
    {
        this.particle = particle;
    }

    public void Play()
    {
        particle.transform.SetParent(null);
        particle.gameObject.SetActive(true);
        GameObject.Destroy(particle.gameObject, particle.main.duration);
    }
}
