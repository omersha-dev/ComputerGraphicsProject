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
		public float[] colors = new float[4];
		public float rotation;
		public int rotaionDirection = 1;
		public float lifeTime;
		public int shouldRender = 0;
		public Particles()
		{
			this.position[0] = 0;
			this.position[1] = 0;
			this.position[2] = 0;
			this.colors[0] = 1;
			this.colors[1] = 0;
			this.colors[2] = 0;
			this.colors[3] = 1;
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

		public void setRotationDirection(float f)
		{
			if (f <= 0)
				this.rotaionDirection = -1;
			else
				this.rotaionDirection = 1;
		}

		public void updateRotation()
		{
			this.rotation += this.rotaionDirection;
		}

		public void updateAlpha()
		{
			this.colors[3] -= 1;
		}

	}
}
