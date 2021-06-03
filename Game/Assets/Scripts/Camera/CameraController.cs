using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PetGame
{


    public class CameraController : MonoBehaviour
    {


        public float followLerpSpeed = 5;





        public Transform transformToFollow;
        [SerializeField] private Transform followerTransform = null;




        // Start is called before the first frame update
        void Start()
        {
            if (followerTransform == null)
            {


                Debug.LogError(typeof(CameraController).ToString() + ": Follower Transform not asigned");
                this.enabled = false;


            }

            



        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (transformToFollow != null)
            {
                followerTransform.position = Vector3.Lerp(
                    followerTransform.position,
                    transformToFollow.position,
                    Time.deltaTime * followLerpSpeed

                );

            }

        }
    }

}