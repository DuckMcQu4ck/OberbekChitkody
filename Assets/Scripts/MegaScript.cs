using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaScript : MonoBehaviour
{

    public double radius;
    public double massGruzov;
    public double mass;
    public double stringLength = 100;
    public double diameter = 10;
    public double rodLength = 15;
    public  double rodMass = 40;

    private GameObject[] huyzes;

    public GameObject Gruz;
    public Slider slider;
    public Text sliderText;
    public InputField textMass;
    public InputField textMassHuyza;


    // Start is called before the first frame update
    void Start()
    {
        huyzes = GameObject.FindGameObjectsWithTag("Huyz");
        textMass.text = mass.ToString();
        textMassHuyza.text = massGruzov.ToString();
        slider.value = -2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RadiusChanged()
    {
        foreach (GameObject huyz in huyzes)
        {
            Vector3 pos = huyz.transform.localPosition;
            float r = (1 - (slider.value + 2));
            sliderText.text = (r).ToString();
            huyz.transform.localPosition = new Vector3(pos.x, pos.y, slider.value);
        }
    }

    public void Apply()
    {
        mass = double.Parse(textMass.text);
        massGruzov = double.Parse(textMassHuyza.text);
        Debug.Log("Mass: " + mass + "Mass H: " + massGruzov);
    }


    private void FixedUpdate()
    {
        Calculate();
    }
    public void Calculate()
    {
        double J = 4 + ((1 / 3) * rodLength * rodMass + radius * massGruzov);
        double r = diameter / 2;
        double a = (r) / ((J / (r)) - r * mass);
        double deltaX = (Time.fixedDeltaTime * Time.fixedDeltaTime * a) / 2;
        Vector3 pos = Gruz.transform.position;
        Debug.Log(deltaX);
        Gruz.transform.position = new Vector3(pos.x, pos.y + (float)deltaX*100000, pos.z);

    }
}
