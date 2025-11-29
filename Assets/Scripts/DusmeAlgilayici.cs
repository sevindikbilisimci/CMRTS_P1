using UnityEngine;

public class DusmeAlgilayici : MonoBehaviour
{
    public Transform baslangicNoktasi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            cc.enabled = false;

            other.gameObject.transform.position = baslangicNoktasi.position;
            other.transform.rotation = Quaternion.LookRotation(Vector3.forward);


            cc.enabled = true;
        }
       
    }

}
