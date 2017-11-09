using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class CameraBounds : MonoBehaviour
    {

        public Vector3 size = new Vector3(80f, 0f, 50f);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(transform.position, size);
        }

        // Adjusts the position to contrain it within size
        public Vector3 GetAdjustedPos(Vector3 incomingPos)
        {
            Vector3 pos = transform.position;
            Vector3 halfSize = size * 0.5f;

            // Is incomingPos outside the position Z?
            if(incomingPos.z > pos.z + halfSize.z)
            {
                incomingPos.z = pos.z + halfSize.z;
            }

            // Is incomingPos outside the negative Z?
            if(incomingPos.z < pos.z - halfSize.z)
            {
                incomingPos.z = pos.z - halfSize.z;
            }

            // Is incomingPos outside the position X?
            if (incomingPos.x > pos.x + halfSize.x)
            {
                incomingPos.x = pos.x + halfSize.x;
            }

            // Is incomingPos outside the negative X?
            if (incomingPos.x < pos.x - halfSize.x)
            {
                incomingPos.x = pos.x - halfSize.x;
            }

            // Is incomingPos outside the position Y?
            if (incomingPos.y > pos.y + halfSize.y)
            {
                incomingPos.y = pos.y + halfSize.y;
            }

            // Is incomingPos outside the negative Y?
            if (incomingPos.y < pos.y - halfSize.y)
            {
                incomingPos.y = pos.y - halfSize.y;
            }

            return incomingPos;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
