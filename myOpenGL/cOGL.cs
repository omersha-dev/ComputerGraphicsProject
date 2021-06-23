using System;
using System.Collections.Generic;
using System.Windows.Forms;
using myOpenGL;

//2
using System.Drawing;

namespace OpenGL
{
    class cOGL
    {
        Control p;
        int Width;
        int Height;

        public int intOptionA=1;

        GLUquadric obj;
        float rocketYpos = -5f;
        public float randFloat;

        public int maxParticles = 25;
        public int currentParticle = 0;
        public Particles[] particles;

        public cOGL(Control pb)
        {
            p=pb;
            Width = p.Width;
            Height = p.Height;

            isAnimate = false;
            isInside = true;
            isBounds = false;
            viewAngle = 110;
            Xangl = 0;
            Yangl = 0;
            Zangl = 0;

            intOptionA = 1;

            randFloat = randomFloat(-3, 3);

            Particles[] particles = new Particles[maxParticles];
            for (int i = 0; i < maxParticles; i++)
			{
                particles[i] = new Particles();
			}
            this.particles = particles;

            InitializeGL();
            obj = GLU.gluNewQuadric();
            PrepareLists();
        }

        ~cOGL()
        {
            GLU.gluDeleteQuadric(obj); 
            WGL.wglDeleteContext(m_uint_RC);
        }

		uint m_uint_HWND = 0;

        public uint HWND
		{
			get{ return m_uint_HWND; }
		}
		
        uint m_uint_DC   = 0;

        public uint DC
		{
			get{ return m_uint_DC;}
		}
		uint m_uint_RC   = 0;

        public uint RC
		{
			get{ return m_uint_RC; }
		}

        public int viewAngle;
		public bool isAnimate;
		public bool isInside;
        public bool isBounds;
        public float Xangl;
        public float Yangl;
        public float Zangl;

        uint ROCKET;
        uint ROCKET_BODY;
        uint ROCKET_TAIL;

        void PrepareLists()
        {

            ROCKET = GL.glGenLists(3);
            ROCKET_TAIL = ROCKET + 1;
            ROCKET_BODY = ROCKET + 2;

            GL.glPushMatrix();
                GL.glNewList(ROCKET_TAIL, GL.GL_COMPILE);
                    GL.glBegin(GL.GL_QUADS);
                        GL.glVertex3d(0.0f, 0.0f, 0.0f);
                        GL.glVertex3d(0.0f, 0.2f, 0.0f);
                        GL.glVertex3d(0.5f, 0.2f, 0.6f);
                        GL.glVertex3d(0.5f, 0.0f, 0.6f);

                        GL.glVertex3d(0.0f, 0.0f, 0.0f);
                        GL.glVertex3d(0.0f, 0.2f, 0.0f);
                        GL.glVertex3d(-0.5f, 0.2f, 0.6f);
                        GL.glVertex3d(-0.5f, 0.0f, 0.6f);

                        GL.glVertex3d(0.5f, 0.2f, 0.6f);
                        GL.glVertex3d(0.5f, 0.0f, 0.6f);
                        GL.glVertex3d(-0.5f, 0.0f, 0.6f);
                        GL.glVertex3d(-0.5f, 0.2f, 0.6f);

                        GL.glVertex3d(0.0f, 0.0f, 0.0f);
                        GL.glVertex3d(0.5f, 0.0f, 0.6f);
                        GL.glVertex3d(-0.5f, 0.0f, 0.6f);
                        GL.glVertex3d(0.0f, 0.0f, 0.0f);

                        GL.glVertex3d(0.0f, 0.2f, 0.0f);
                        GL.glVertex3d(0.5f, 0.2f, 0.6f);
                        GL.glVertex3d(-0.5f, 0.2f, 0.6f);
                        GL.glVertex3d(0.0f, 0.2f, 0.0f);

                    GL.glEnd();
                GL.glEndList();
            GL.glPopMatrix();

            GL.glPushMatrix();
                GL.glNewList(ROCKET_BODY, GL.GL_COMPILE);
                    GL.glColor3d(0.5, 0, 0.5);
                    GLU.gluCylinder(GLU.gluNewQuadric(), 0, 0.1, 0.1, 20, 20);
			        GL.glTranslatef(0, 0, 0.1f);
                    GL.glColor3d(1, 0, 0);
			        GLU.gluCylinder(GLU.gluNewQuadric(), 0.1, 0.2, 0.25, 20, 20);
			        GL.glTranslatef(0, 0, 0.25f);
                    GL.glColor3d(0, 0, 1);
			        GLU.gluCylinder(GLU.gluNewQuadric(), 0.2, 0.2, 1, 20, 20);
			    GL.glEndList();
            GL.glPopMatrix();

            CreateRocketList();

        }

        public void CreateRocketList()
		{
            GL.glPushMatrix();

            GL.glNewList(ROCKET, GL.GL_COMPILE);
            GL.glRotated(90, 1, 0, 0);
            GL.glScaled(0.5, 0.5, 0.5);
            GL.glCallList(ROCKET_BODY);
            GL.glTranslatef(0.0f, -0.1f, 0.3f);
            GL.glCallList(ROCKET_TAIL);
            GL.glTranslatef(0.1f, 0.1f, 0.0f);
            GL.glRotated(90, 0, 0, 1);
            GL.glCallList(ROCKET_TAIL);
            GL.glRotated(90, 0, 0, -1);
            GL.glTranslatef(-0.1f, 0.0f, -0.3f);
            GL.glScaled(2, 2, 2);
            GL.glRotated(90, -1, 0, 0);
            GL.glEndList();
            GL.glPopMatrix();
		}

        void DrawBounds()
        {
            if (isBounds)
            {
                GL.glScalef(0.99f, 0.99f, 0.99f);
                GL.glLineWidth(2);
                GL.glColor3f(1.0f, 0.0f, 0.0f);
                GL.glDisable(GL.GL_LIGHTING);
                GL.glBegin(GL.GL_LINE_LOOP);
                GL.glVertex3f(-1, -1, -1);
                GL.glVertex3f(1, -1, -1);
                GL.glVertex3f(1, -1, 1);
                GL.glVertex3f(-1, -1, 1);
                GL.glEnd();
                GL.glBegin(GL.GL_LINE_LOOP);
                GL.glVertex3f(-1, 1, -1);
                GL.glVertex3f(1, 1, -1);
                GL.glVertex3f(1, 1, 1);
                GL.glVertex3f(-1, 1, 1);
                GL.glEnd();
                GL.glBegin(GL.GL_LINES);
                GL.glVertex3f(-1, -1, -1);
                GL.glVertex3f(-1, 1, -1);

                GL.glVertex3f(1, -1, -1);
                GL.glVertex3f(1, 1, -1);

                GL.glVertex3f(1, -1, 1);
                GL.glVertex3f(1, 1, 1);

                GL.glVertex3f(-1, -1, 1);
                GL.glVertex3f(-1, 1, 1);
                GL.glEnd();
                GL.glScalef(1.0f / 0.99f, 1.0f / 0.99f, 1.0f / 0.99f);
            }

            GL.glEnable(GL.GL_COLOR_MATERIAL);
            GL.glEnable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_LIGHTING);
            GL.glTranslatef(0.1f, 0.2f, -0.7f);
            GL.glDisable(GL.GL_LIGHTING);
        }

        public float randomFloat(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
        float oldViewAngle = 110.0f;

        public void Draw()
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;

            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            if (oldViewAngle != viewAngle)
            {
                GL.glMatrixMode(GL.GL_PROJECTION);
                GL.glLoadIdentity();
                oldViewAngle = viewAngle;

                GLU.gluPerspective(viewAngle, (float)Width / (float)Height, 0.45f, 30.0f);

                GL.glMatrixMode(GL.GL_MODELVIEW);
                GL.glLoadIdentity();
            }
            GL.glLoadIdentity();

			if (!isInside)
				GL.glTranslatef(0.0f, 0.0f, -4);

            GL.glDisable(GL.GL_LIGHTING);
            GL.glDisable(GL.GL_BLEND);
            GL.glDisable(GL.GL_TEXTURE_2D);
            DrawBounds();// important: last 2 GL.glDisableS !!!

            //!!!!
            GL.glColor4f(1.0f, 1.0f, 1.0f, 0.5f);
            //!!!!

            GL.glEnable(GL.GL_TEXTURE_2D);

            GL.glDisable(GL.GL_BLEND);
            DrawTexturedCube();
            
            float rocketSpeed = 0.1f;

            if (rocketYpos >= 6.5)
            {
                randFloat = randomFloat(-3, 3);
                rocketYpos = -rocketYpos;
            }
            else
            {
                rocketYpos += 1 * rocketSpeed;
            }

            GL.glTranslatef(randFloat, rocketYpos, -2.0f);
            GL.glCallList(ROCKET);

            /* Start particle system */
            if (particles[currentParticle].lifeTime > 0)
            {
                particles[currentParticle].setRotation(randomFloat(0, 90));
				if (particles[currentParticle].lifeTime == 20)
				{
                    particles[currentParticle].setPosition(0, rocketYpos - 0.7f, -2.0f);
                    particles[currentParticle].setRotationDirection(randomFloat(-1, 1));
				}
                //particles[currentParticle].setPosition(0, rocketYpos - 0.7f, -2.0f);
                GL.glTranslatef(particles[currentParticle].position[0], particles[currentParticle].position[1] - rocketYpos, 0);
                GL.glColor3f(1.0f, 0, 0);
                GL.glRotated(particles[currentParticle].rotation, 0, 0, 1);
                GL.glBegin(GL.GL_QUADS);
                GL.glVertex3d(0.25f, 0.0f, 0.0f);
                GL.glVertex3d(0.25f, 0.25f, 0.0f);
                GL.glVertex3d(0.0f, 0.25f, 0.0f);
                GL.glVertex3d(0.0f, 0.0f, 0.0f);
                GL.glEnd();
                GL.glRotated(particles[currentParticle].rotation, 0, 0, -1);
                GL.glTranslatef(-particles[currentParticle].position[0], -(particles[currentParticle].position[1] - rocketYpos), 0);

				for (int i = 0; i < maxParticles; i++)
                {
                    if (i == currentParticle)
                        continue;
                    if (particles[i].shouldRender == 0)
                        break;
                    particles[i].updateRotation();
                    GL.glTranslatef(particles[i].position[0], particles[i].position[1] - rocketYpos, 0);
                    GL.glRotated(particles[i].rotation, 0, 0, 1);
                    //particles[i].updateAlpha();
                    //GL.glColor4f(particles[i].colors[0], particles[i].colors[1], particles[i].colors[2], particles[i].colors[3]);
                    GL.glBegin(GL.GL_QUADS);
                    GL.glVertex3d(0.25f, 0.0f, 0.0f);
                    GL.glVertex3d(0.25f, 0.25f, 0.0f);
                    GL.glVertex3d(0.0f, 0.25f, 0.0f);
                    GL.glVertex3d(0.0f, 0.0f, 0.0f);
                    GL.glEnd();
                    GL.glRotated(-particles[i].rotation, 0, 0, 1);
                    GL.glTranslatef(-particles[i].position[0], -(particles[i].position[1] - rocketYpos), 0);
					particles[i].lifeTime--;
                    if (particles[i].lifeTime <= 0)
					{
                        particles[i].lifeTime = 20;
                        particles[i].setPosition(0, rocketYpos - 0.7f, -2.0f);
                        particles[currentParticle].setRotationDirection(randomFloat(-1, 1));
                    }
                }

			}
            particles[currentParticle].shouldRender = 1;
            currentParticle++;
            if (currentParticle == maxParticles)
			{
                currentParticle = 0;
			}
            /* End particle system */

            GL.glTranslatef(1.0f, -rocketYpos, 2.0f);

            //GL.glColor3f(0, 1, 0);
            //GLU.gluSphere(obj, 0.05, 16, 16);
            GL.glTranslatef(-randFloat, -0.2f, 0.7f);

            GL.glFlush();

            WGL.wglSwapBuffers(m_uint_DC);

        }

		protected virtual void InitializeGL()
		{
			m_uint_HWND = (uint)p.Handle.ToInt32();
			m_uint_DC   = WGL.GetDC(m_uint_HWND);

            // Not doing the following WGL.wglSwapBuffers() on the DC will
			// result in a failure to subsequently create the RC.
			WGL.wglSwapBuffers(m_uint_DC);

			WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
			WGL.ZeroPixelDescriptor(ref pfd);
			pfd.nVersion        = 1; 
			pfd.dwFlags         = (WGL.PFD_DRAW_TO_WINDOW |  WGL.PFD_SUPPORT_OPENGL |  WGL.PFD_DOUBLEBUFFER); 
			pfd.iPixelType      = (byte)(WGL.PFD_TYPE_RGBA);
			pfd.cColorBits      = 32;
			pfd.cDepthBits      = 32;
			pfd.iLayerType      = (byte)(WGL.PFD_MAIN_PLANE);

			int pixelFormatIndex = 0;
			pixelFormatIndex = WGL.ChoosePixelFormat(m_uint_DC, ref pfd);
			if(pixelFormatIndex == 0)
			{
				MessageBox.Show("Unable to retrieve pixel format");
				return;
			}

			if(WGL.SetPixelFormat(m_uint_DC,pixelFormatIndex,ref pfd) == 0)
			{
				MessageBox.Show("Unable to set pixel format");
				return;
			}
			//Create rendering context
			m_uint_RC = WGL.wglCreateContext(m_uint_DC);
			if(m_uint_RC == 0)
			{
				MessageBox.Show("Unable to get rendering context");
				return;
			}
			if(WGL.wglMakeCurrent(m_uint_DC,m_uint_RC) == 0)
			{
				MessageBox.Show("Unable to make rendering context current");
				return;
			}


            initRenderingGL();
        }

        public void OnResize()
        {
            Width = p.Width;
            Height = p.Height;
            GL.glViewport(0, 0, Width, Height);
            Draw();
        }

        protected virtual void initRenderingGL()
		{
			if(m_uint_DC == 0 || m_uint_RC == 0)
				return;
			if(this.Width == 0 || this.Height == 0)
				return;
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);

            GL.glViewport(0, 0, this.Width, this.Height);
            //GL.glClearColor(0, 0, 0, 0); 
			GL.glMatrixMode ( GL.GL_PROJECTION );
			GL.glLoadIdentity();

            //! TEXTURE 1a 
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            float[] emis ={ 0.3f, 0.3f, 0.3f, 1 };
            GL.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, emis);
            //! TEXTURE 1a 

            
            
	        GL.glShadeModel(GL.GL_SMOOTH);
            GLU.gluPerspective(viewAngle, (float)Width / (float)Height, 0.45f, 30.0f);

            GL.glMatrixMode ( GL.GL_MODELVIEW );
			GL.glLoadIdentity();

            //! TEXTURE 1a 
            GenerateTextures();
            //! TEXTURE 1b 
        }


        //! TEXTURE b
        public uint[] Textures = new uint[7];
        
        void GenerateTextures()
        {
            GL.glEnable(GL.GL_BLEND);
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA); 
            GL.glGenTextures(7, Textures);
            string[] imagesName ={ "front.bmp","back.bmp",
		                            "left.bmp","right.bmp","top.bmp","bottom.bmp","fire.png"};
            for (int i = 0; i < 7; i++)
            {
                Bitmap image = new Bitmap(imagesName[i]);
                image.RotateFlip(RotateFlipType.RotateNoneFlipY); //Y axis in Windows is directed downwards, while in OpenGL-upwards
                System.Drawing.Imaging.BitmapData bitmapdata;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[i]);
                //2D for XYZ
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_byte, bitmapdata.Scan0);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

                image.UnlockBits(bitmapdata);
                image.Dispose();
            }
        }
        //! TEXTURE CUBE b
        //Draws our textured cube, VERY simple.  Notice that the faces are constructed
        //in a counter-clockwise order.  If they were done in a clockwise order you would
        //have to use the glFrontFace() function.  
        void DrawTexturedCube()
        {

            float boxSize = 10.0f;

            // front
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[0]);
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-boxSize, -boxSize, boxSize);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(boxSize, -boxSize, boxSize);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(boxSize, boxSize, boxSize);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-boxSize, boxSize, boxSize);
            GL.glEnd();
            // back
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[1]);
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(boxSize, -boxSize, -boxSize);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-boxSize, -boxSize, -boxSize);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-boxSize, boxSize, -boxSize);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(boxSize, boxSize, -boxSize);
            GL.glEnd();
            // left
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[2]);
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-boxSize, -boxSize, -boxSize);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-boxSize, -boxSize, boxSize);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-boxSize, boxSize, boxSize);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-boxSize, boxSize, -boxSize);
            GL.glEnd();
            // right
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[3]);
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(boxSize, -boxSize, boxSize);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(boxSize, -boxSize, -boxSize);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(boxSize, boxSize, -boxSize);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(boxSize, boxSize, boxSize);
            GL.glEnd();
            // top
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[4]);
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-boxSize, boxSize, boxSize);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(boxSize, boxSize, boxSize);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(boxSize, boxSize, -boxSize);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-boxSize, boxSize, -boxSize);
            GL.glEnd();
            // bottom
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[5]);
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-boxSize, -boxSize, -boxSize);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(boxSize, -boxSize, -boxSize);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(boxSize, -boxSize, boxSize);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-boxSize, -boxSize, boxSize);
            GL.glEnd();

        }
        //! TEXTURE CUBE e

    }

}


