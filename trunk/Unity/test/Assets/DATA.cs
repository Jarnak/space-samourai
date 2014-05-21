using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


    [Serializable]
    public class DATA
    {
        public float x=0;
        public float y=0;
        public float z=0;
        public float w = 0;
        public bool go;
	public bool shield;

        public void setX(float nx)
        {
            x = nx;
        }
        public float getX()
        {
            return x;
        }
        public void setY(float ny)
        {
            y = ny;
        }
        public float getY()
        {
            return y;
        }
        public void setZ(float nz)
        {
            z = nz;
        }
        public float getZ()
        {
            return z;
        }
        public void setW(float nz)
        {
            z = nz;
        }
        public float getW()
        {
            return z;
        }
        public bool getGo()
        {
            return go;
        }
}
