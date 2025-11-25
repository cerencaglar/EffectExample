using UnityEngine;
using UnityEngine.InputSystem;

public class kontrol2 : MonoBehaviour
{
    public GameObject mesale; // Ana obje (örneðin FlameThrowerEffect)
    private ParticleSystem[] tumParticleSistemleri;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ana objenin içindeki tüm ParticleSystem bileþenlerini al
        tumParticleSistemleri = mesale.GetComponentsInChildren<ParticleSystem>();

        // Baþta hepsi dursun
        foreach (var ps in tumParticleSistemleri)
        {
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            // Henüz oynamayanlarý baþlat
            foreach (var ps in tumParticleSistemleri)
            {
                if (!ps.isPlaying)
                    ps.Play();
            }
        }
        else
        {
            // Çalýþanlarý durdur
            foreach (var ps in tumParticleSistemleri)
            {
                if (ps.isPlaying)
                    ps.Stop();
            }
        }
    }
}
