using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUp : MonoBehaviour {


    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID; // 0 = tripleshot 1= speed boost, 2 = shields
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _speed*Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //access the player
            Player player = other.GetComponent<Player>();

            if (player != null) {
                //enable the triple shot
                if (powerupID == 0)
                {
                    player.TripleShotPowerOn();
                }
                else if (powerupID == 1)
                {
                    //enable speed boost
                    player.SpeedBoostPowerupOn();

                }
                else if (powerupID == 2)
                {
                    //enable shield
                    player.ShieldBOostPowerActive();
                }  


            }
            //destroy ourself
            Destroy(this.gameObject);
        }
        
    }
}
