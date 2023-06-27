using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSc : MonoBehaviour
{
public  Transform [] backgrounds;
    private float[] paralaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;
    void Awake()
    {
        cam = Camera.main.transform;

    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;
        paralaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++) {
            paralaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * paralaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }
        previousCamPos = cam.position;
    }
}
