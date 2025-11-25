using UnityEngine;

public class Patlama : MonoBehaviour
{
    private bool patladi = false;
    ParticleSystem[] efektler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ana objenin içindeki tüm ParticleSystem bileþenlerini al
        efektler = GetComponentsInChildren<ParticleSystem>();

        // Baþta hepsi dursun
        foreach (var ps in efektler)
        {
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Yalnýzca ilk çarpýþmada çalýþsýn (güvenlik)
        if (patladi) return;
        patladi = true;

        // Çarpýþma plane ileyse (istersen kaldýrabilirsin)
        if (collision.gameObject.CompareTag("plane"))
        {
            // Merminin içindeki ParticleSystem bileþenlerini bul
            

            foreach (var ps in efektler)
            {
                ps.Play(); // Tüm partikül efektlerini baþlat
            }

        }
    }
}
