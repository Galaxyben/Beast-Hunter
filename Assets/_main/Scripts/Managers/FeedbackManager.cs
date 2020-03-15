using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager feedbackManager;

    [Header("Camera Shakes")]
    public NoiseSettings groundDashNoise;
    public NoiseSettings dashNoise;
    public NoiseSettings hitNoise;
    private CinemachineImpulseSource impulseSource;

    [Header("Feedback settings")]
    public ParticleSystem dashGroundParticles;

    private void Awake()
    {
        feedbackManager = this;
    }

    void Start()
    {
        impulseSource = PlayerStats.playerStats.GetComponent<CinemachineImpulseSource>();
    }
    
    void Update()
    {
        
    }

    public IEnumerator FB_Hit()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
    }

    public void ShakeCamera(NoiseSettings noise)
    {
        impulseSource.m_ImpulseDefinition.m_RawSignal = noise;
        impulseSource.GenerateImpulse();
    }
    public IEnumerator InstantiateParticles(Vector3 _pos, ParticleSystem particleSystem)
    {
        GameObject go = Instantiate(particleSystem.gameObject, _pos, Quaternion.Euler(-90, 0, 0));
        yield return new WaitForSeconds(particleSystem.main.startLifetime.constant);
        Destroy(go);
    }

}
