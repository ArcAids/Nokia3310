using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem telePortParticles;
    [SerializeField] GameObject attackZone;
    [SerializeField] AudioSource MainTheme;

    AudioSource oraSource;

    private void Awake()
    {
        attackZone.transform.parent = null;
        telePortParticles.transform.parent = null;
        oraSource = GetComponent<AudioSource>();
        GetComponent<Transformer>().onDown += PlayTeleportParticles;
    }
    private void OnEnable()
    {
        attackZone.SetActive(false);
    }

    public void Attack()
    {
        attackZone.transform.position = transform.position;
        particles.Play();
        MainTheme.Pause();
        oraSource.Play();
        attackZone.SetActive(true);
    }

    public void PlayTeleportParticles()
    {
        telePortParticles.transform.position = transform.position;
        telePortParticles.Play();
    }

    public void StopAttack()
    {
        attackZone.SetActive(false);
        MainTheme.UnPause();
    }
}
