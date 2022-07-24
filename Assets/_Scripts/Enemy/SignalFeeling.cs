using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalFeeling : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _mr;
    private Material _mat;
    
    private void Start()
    {
        // mat.SetFloat("FeelValue",0.5);
        _mat = _mr.material;
    }
    public void SetNewFeelValue(float value)
    {
        _mat = _mr.material;
        _mat.SetFloat("FeelValue", value);
    }
     public void SetNewColor(Color value)
    {
        _mat = _mr.material;
        _mat.SetColor("ColorOb", value);
     //  _mat.Se
        // _mat.SetColorArray
    }
    private void FixedUpdate()
    {
        float a = Quaternion.FromToRotation(Vector3.forward, this.transform.position - Camera.main.transform.position).eulerAngles.y;
        float b = Quaternion.FromToRotation(Vector3.forward, this.transform.position - Camera.main.transform.position).eulerAngles.x;
        this.transform.rotation = Quaternion.Euler(b,a,0);
    }
}
