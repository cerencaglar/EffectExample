using UnityEngine;
using UnityEngine.InputSystem;

public class Kontroller : MonoBehaviour
{
    public GameObject alev; // Ana obje (örneðin FlameThrowerEffect)
    private ParticleSystem[] tumParticleSistemleri;

    [Header("Ayarlar")]
    public float donusHizi = 200f;  // Dönüþ hýzý (isteðe göre ayarlanabilir)
    public GameObject karakter;

    private float yatayDonus = 0f;


    public GameObject mermiPrefab;
    public Transform atisNoktasi;
    public float atisGucu = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ýmleci gizle ve sabitle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Ana objenin içindeki tüm ParticleSystem bileþenlerini al
        tumParticleSistemleri = alev.GetComponentsInChildren<ParticleSystem>();

        // Baþta hepsi dursun
        foreach (var ps in tumParticleSistemleri)
        {
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
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

        // Fare hareketini oku (yeni Input System)
        float mouseX = Mouse.current.delta.x.ReadValue() * donusHizi * Time.deltaTime;

        // Yalnýzca yatay eksende (Y) döndür
        yatayDonus += mouseX;
        karakter.transform.rotation = Quaternion.Euler(0f, yatayDonus, 0f);


        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            GameObject mermi = Instantiate(mermiPrefab, atisNoktasi.position, atisNoktasi.rotation);
            Rigidbody rb = mermi.GetComponent<Rigidbody>();
            rb.AddForce(atisNoktasi.forward * atisGucu, ForceMode.Impulse);

            Destroy(mermi, 1.5f);
        }
    }
}
