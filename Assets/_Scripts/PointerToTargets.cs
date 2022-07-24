using UnityEngine;

using UnityEngine.UI;
//using UnityEngine.UIElements;

public class PointerToTargets : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerData playerData;
   // public Transform[] _pointersPositions;
    public Vector3[] _pointers;
    private Vector3 CenterOfScreenToTargetDirection;
    private Vector2 cameraWidthAndHeight;
    private Vector2 _screenCenter;
    public GameObject pointerPrefab;
    [SerializeField] private GameObject[] _pointerInScreen;
    [SerializeField] private Image[] pointerImages;
    
       // [SerializeField] public Image pointerImage ;
    public float imageFadeDistance = 10;
    void Start()
    {
       
        this.pointerImages = new Image[playerData.enemiesTransforms.Length];
        _pointerInScreen = new GameObject[playerData.enemiesTransforms.Length];
        _pointers = new Vector3[playerData.enemiesTransforms.Length];
      //  _pointersPositions = new Transform[playerData.enemiesTransforms.Length];
        for (int i = 0; i < playerData.enemiesTransforms.Length; i++)
        {
            _pointerInScreen[i] = Instantiate(pointerPrefab, this.transform);
            //_pointersPositions[i] = _pointerInScreen[i].transform;
            pointerImages[i] = _pointerInScreen[i].GetComponentInChildren<Image>();
        }

        cameraWidthAndHeight = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        _screenCenter = cameraWidthAndHeight / 2;


    }


    void FadingImage(Transform imageTransform, Transform target)
    {
     //   imageTransform.color = new Color(1f, 1f, 1f, 20 - Vector3.Distance(target.position, playerData.transform.position));
        if (Vector3.Distance(target.position, playerData.transform.position) > imageFadeDistance)
        {
            imageTransform.position = new Vector2(1000, 1000);
            //    print("True");
        }
        else
        {
         //   return false;
          //  print("False");
        }
     
    }
    void MovingPointer(Vector3 _pointer, Transform _pointersPosition)
    {
        //  Vector2 cameraWidthAndHeigh
     
        for (int i = 0; i < playerData.enemiesTransforms.Length; i++)
        {
            _pointers[i] = Camera.main.WorldToScreenPoint(playerData.enemiesTransforms[i].position);
        }

        if (BorderCheck(_pointer))  
        {
            //print();
            _pointersPosition.position = BoundingElement(_pointer, cameraWidthAndHeight);
        }
        else
        {
            _pointersPosition.position = new Vector2(1000, 1000);
        }


    }
    Vector2 BoundingElement(Vector2 element, Vector2 borders)
    {
        Vector2 BoundedPosition;
        BoundedPosition = element;
        if (BoundedPosition.x > borders.x * 0.9f)
        {
            BoundedPosition = new Vector3(borders.x * 0.9f, BoundedPosition.y);
        }
        if (BoundedPosition.y > borders.y * 0.9f)
        {
            BoundedPosition = new Vector3(BoundedPosition.x, borders.y * 0.9f);
        }
        //  _pointersPosition.position = _pointer;
        if (BoundedPosition.x < borders.y * 0.1f)
        {
            BoundedPosition = new Vector3(borders.x * 0.1f, BoundedPosition.y);
        }
        if (BoundedPosition.y < borders.x * 0.1f)
        {
            BoundedPosition = new Vector3(BoundedPosition.x, borders.x * 0.1f);
        }
        return BoundedPosition;
    }
    bool BorderCheck(Vector2 element)
    {
        if ((element.x * 0.9f > cameraWidthAndHeight.x) || (element.y > cameraWidthAndHeight.y * 0.9f) || (element.x < cameraWidthAndHeight.y * 0.1f) || (element.y < cameraWidthAndHeight.y * 0.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
  



    void Update()
    {
        // Quaternion q = Quaternion.FromToRotation(_pointersPosition.up, (_screenCenter - new Vector2(_pointersPosition.position.x, _pointersPosition.position.y)));
        //    Vector3 a = Quaternion.ToEulerAngles(q);
        //    q = Quaternion.Euler(0,a.y,0);
        //   Vector3 a =  new Vector3((_screenCenter - new Vector2(_pointersPosition.position.x, _pointersPosition.position.y)).x, (_screenCenter - new Vector2(_pointersPosition.position.x, _pointersPosition.position.y)).y,0);
        //  _pointersPosition.rotation *= Quaternion.FromToRotation(-_pointersPosition.up, a);
        // _pointersPosition.rotation = Quaternion.
        // print(_screenCenter - new Vector2(_pointersPosition.position.x, _pointersPosition.position.y));
        for (int i = 0; i < playerData.enemiesTransforms.Length; i++)
        {
         
            MovingPointer(_pointers[i], _pointerInScreen[i].transform);
            FadingImage(_pointerInScreen[i].transform, playerData.enemiesTransforms[i]);
            pointerImages[i].color = new Color(1f, 1f, 1f, (20 - Vector3.Distance(playerData.enemiesTransforms[i].position, playerData.transform.position))/20);
            //    pointerImages[i].color = Color.red;
            //    RotatePointer(_pointers[i], _pointersPositions[i]);
            //   FadingImage(_pointersPositions[i], pointerImages[i]);
        }
    }
    //  MovingPointer();
    //ShowingAndHidingPointer();
}


// Update is called once per frame


