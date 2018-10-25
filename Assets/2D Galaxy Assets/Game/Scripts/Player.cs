using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShort = false;
    public bool isSpeedBoostActive = false;
    public bool isShieldBoostActive = false;
    public int lives = 3;


    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;


    [SerializeField]
    private float _speed = 5.0f;
    // Use this for initialization
    void Start() {

        transform.position = new Vector3(0, -4.702877f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {



        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > _canFire)
            {
                if (canTripleShort == true)
                {
                    Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.16072f, 0), Quaternion.identity);
                }
                
                _canFire = Time.time + _fireRate;
            }

        }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if (isSpeedBoostActive == true)
        {
            transform.Translate(Vector3.up * _speed * 3.0f * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * _speed * 3.0f * horizontalInput * Time.deltaTime);


        }
        else
        {
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);

        }




        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -8.4f)
        {

            transform.position = new Vector3(transform.position.x, -8.4f, 0);
        }


        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    public void Damage()
    {


        if (isShieldBoostActive == true)
        {

            isShieldBoostActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        lives--;
        if (lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void TripleShotPowerOn()
    {
        canTripleShort = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }


    public void SpeedBoostPowerupOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());

    }


    public void ShieldBOostPowerActive()
    {
        isShieldBoostActive = true;
        _shieldGameObject.SetActive(true);
        
    }


    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShort = false;
    }
    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

    }

