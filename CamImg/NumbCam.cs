
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class NumbCam : UdonSharpBehaviour
{
    [SerializeField] GameObject[] camPos;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject img;
    void Start()
    {
        img.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("[0]"))
        {
            img.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("[1]"))
        {
            img.gameObject.SetActive(true);
            cam.transform.position = camPos[0].transform.position;
            cam.transform.rotation = camPos[0].transform.rotation;
        }
        if (Input.GetKeyDown("[2]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[1].transform.position;
            cam.transform.rotation = camPos[1].transform.rotation;
        }
        if (Input.GetKeyDown("[3]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[2].transform.position;
            cam.transform.rotation = camPos[2].transform.rotation;
        }
        if (Input.GetKeyDown("[4]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[3].transform.position;
            cam.transform.rotation = camPos[3].transform.rotation;
        }
        if (Input.GetKeyDown("[5]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[4].transform.position;
            cam.transform.rotation = camPos[4].transform.rotation;
        }
        if (Input.GetKeyDown("[6]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[5].transform.position;
            cam.transform.rotation = camPos[5].transform.rotation;
        }
        if (Input.GetKeyDown("[7]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[6].transform.position;
            cam.transform.rotation = camPos[6].transform.rotation;
        }
        if (Input.GetKeyDown("[8]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[7].transform.position;
            cam.transform.rotation = camPos[7].transform.rotation;
        }
        if (Input.GetKeyDown("[9]"))
        {
            gameObject.SetActive(true);
            cam.transform.position = camPos[8].transform.position;
            cam.transform.rotation = camPos[8].transform.rotation;
        }
    }
}
