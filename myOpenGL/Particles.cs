using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOpenGL
{
	class Particles
	{
		public float[] position = new float[3];
		public float rotation;
		public float lifeTime;

		public Particles()
		{
			this.position[0] = 0;
			this.position[1] = 0;
			this.position[2] = 0;
			this.rotation = 0;
			this.lifeTime = 20;
		}
		public Particles(float[] position, float rotation)
		{
			this.position = position;
			this.rotation = rotation;
			this.lifeTime = 20;
		}

		public void setPosition (float x, float y, float z)
		{
			position[0] = x;
			position[1] = y;
			position[2] = z;
		}

		public void setRotation(float rotation)
		{
			this.rotation = rotation;
		}

	}
}
