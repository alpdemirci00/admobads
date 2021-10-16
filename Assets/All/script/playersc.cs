using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playersc : MonoBehaviour
{
    public AudioClip altin, duşme, kazanma;
    public DynamicJoystick DynamicJoystick;
    public FixedJoystick fj;
    public UnityEngine.UI.Text can, zaman, durum;
    bool oyundevam = true;
    bool oyuntamam = false;
    public float zamansayacı = 90;
    int cansayacı = 1;
    public UnityEngine.UI.Button btn, menub;
    public UnityEngine.UI.Button menu;
    public UnityEngine.UI.Button sonrakilevel;
    Vector3 inputXY;
    public static SphereCollider sphere;
    public static Rigidbody rb;
    public altin altıns;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (altıns.oyunaktif)
        {
            if (oyundevam && !oyuntamam)
            {
                zamansayacı -= Time.deltaTime;
                zaman.text = (int)zamansayacı + "";
            }
            else if (!oyuntamam)
            {
                durum.text = "LOSE";
                btn.gameObject.SetActive(true);
                menub.gameObject.SetActive(false);
                menu.gameObject.SetActive(true);
                can.gameObject.SetActive(false);
                fj.gameObject.SetActive(false);
                Destroy(DynamicJoystick.gameObject);
            }


            if (zamansayacı < 0)
                oyundevam = false;
        }
    }

    private void FixedUpdate()
    {
        if (oyundevam && !oyuntamam)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            inputXY = new Vector3(horizontalInput, verticalInput);
            if (inputXY.magnitude > 1) { inputXY.Normalize(); }

        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.transform.position = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision CollisionData)
    {
        string objismi = CollisionData.gameObject.tag;
        if (objismi.Equals("bitiş"))
        {
            GetComponent<AudioSource>().PlayOneShot(kazanma, 1f);
            oyuntamam = true;
            durum.text = "WİN";
            btn.gameObject.SetActive(true);
            can.gameObject.SetActive(false);
            fj.gameObject.SetActive(false);
            menub.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
            sonrakilevel.gameObject.SetActive(true);
            Destroy(DynamicJoystick.gameObject);
        }
        else if (!objismi.Equals("güvenli") && !objismi.Equals("Altın"))
        {
            cansayacı -= 1;
            can.text = cansayacı + "";
            if (cansayacı == 0)
                oyundevam = false;
            rb.velocity = Vector3.zero;
        }

        string obj = CollisionData.gameObject.tag;
        if (obj.Equals("düşman"))
        {
            GetComponent<AudioSource>().PlayOneShot(duşme, 1f);
        }
    }

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        sphere = transform.GetComponent<SphereCollider>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Altın"))
        {
            GetComponent<AudioSource>().PlayOneShot(altin, 1f);
            altıns.altınarttır();
            Destroy(other.gameObject);
        }
    }
}
