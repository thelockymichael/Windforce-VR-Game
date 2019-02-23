using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.Extras
{


    public class FlyingScript : MonoBehaviour
    {
        public Rigidbody player;

        Vector3 lastPos;

        SteamVR_Behaviour_Pose trackedObj;
        public float threshold = 1.0f;

        private void Start()
        {

            trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
            lastPos = trackedObj.poseAction.localPosition;
        }

        private void Update()
        {
          //  Debug.Log(trackedObj.GetVelocity());

            Vector3 offset = trackedObj.poseAction.localPosition - lastPos;
            if (offset.y > threshold)
            {
                player.transform.Translate(Vector3.up * Time.deltaTime * 100, Space.World);

                lastPos = trackedObj.poseAction.localPosition; // Update last position
                Debug.Log("Y CHANGING");

            }
            else
            {
                if (offset.y < -threshold)
                {
                   player.transform.Translate(Vector3.up * Time.deltaTime, Space.World);

                    lastPos = trackedObj.poseAction.localPosition;
                    Debug.Log("- Y CHANGING");
                }
            }
        }
    }
}
        /*
        public Rigidbody player;
        SteamVR_Behaviour_Pose trackedObj;
        Vector3 myVector;
        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Rigidbody>();

            trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
            //   rb = GetComponent<Rigidbody>();   
        }

        public void flappingWings()
        {
            Debug.Log("The player is flapping his wings");
        }

        // Update is called once per frame
        void Update()
        {
            
            myVector = new Vector3(0.0f, -0.1f, 0.0f);
            if (trackedObj.poseAction.velocity. == myVector)
            {
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                Debug.Log("Moving on up now " + transform);
            }
            trackedObj.GetVelocity();
           Debug.Log(trackedObj.GetVelocity());

           
            //    Vector3 v3Velocity = rb.velocity;
            //Debug.Log("Velocity of wing is: " + v3Velocity);
        }
    }
    
}*/
