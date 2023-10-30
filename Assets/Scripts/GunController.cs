using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public GameObject decal;
    public Camera fpsCam;
    public AudioSource source;
    public AudioClip gunshot;
    [Header("Keybinds")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public float shootCoolDown = 0.2f;
    //public int gunIndex = 0; //current gun being held
    private Image frame;
    public GameObject gunImage;
    [Header("Sprites to be used")]
    public List<Sprite> sprites = new List<Sprite>();
    private bool readyToShoot = true;
    private bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        frame = gunImage.GetComponent<Image>();
    }
    private void resetShoot()
    {
        frame.sprite = sprites[1];
        frame.transform.position -= new Vector3(20f, 20f, 0f);
        readyToShoot = true;
        shooting = false;
    }

    private void shoot()
    {
        float weaponRange = 20f;
        float hitforce = 100f;
        readyToShoot = false;
        //shoot
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitforce);
            }
            if (hit.transform.CompareTag("Zombie"))
            {
                Zombie z = hit.transform.GetComponent<Zombie>();
                z.health -= 20;
                if (z.health <= 0) Destroy(hit.transform.gameObject);
            }
        }
        GameObject decalobject = Instantiate(decal, hit.point + (hit.normal * 0.025f), Quaternion.identity) as GameObject;
        decalobject.transform.SetParent(hit.transform, true);
        decalobject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        source.PlayOneShot(gunshot);
        shooting = true;
        frame.transform.position += new Vector3(20f, 20f, 0f);
        Invoke(nameof(resetShoot), shootCoolDown);
    }
    // Update is called once per frame
    void Update()
    {
        if (readyToShoot) frame.sprite = sprites[0];
        if (Input.GetKey(shootKey) && readyToShoot)
        {
            shoot();
        }
        else if (shooting) frame.sprite = sprites[1];
    }
}
