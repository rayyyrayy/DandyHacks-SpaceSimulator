using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
            [SerializeField] private Material myMaterial;


    public void changeColor()
    {
        myMaterial.color = Color.green;
    }

    public void changeColorRed()
    {
        myMaterial.color = Color.red;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
    }
}
