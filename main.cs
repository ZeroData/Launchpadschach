using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IntelOrca.Launchpad;
using Midi;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool firstclick = true;
        LaunchpadDevice device;
        Schach neuesspiel;

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            try
            {
                device = new LaunchpadDevice();
                device.DoubleBuffered = true;
            }
            catch
            {
                System.Windows.Forms.Application.Exit();
            }
            device.Reset();
            System.Windows.Forms.Application.Exit();
        }

        public Form1()
        {
            InitializeComponent();
            try
            {
                device = new LaunchpadDevice();
                device.DoubleBuffered = true;
            }
            catch
            {
                textBox2.Text = ("Launchpad nicht angeschlossen, oder durch ein anderes Programm verwendet!");
                return;
            }
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    device[x, y].TurnOffLight();
            device.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.Reset();
            button1.Enabled = true;
            button2.Enabled = false;
            button2.Text = "Launchpad erkannt";
            hilfe();
        }

        public void figurensetzen()
        {
            a1.SizeMode = PictureBoxSizeMode.StretchImage;
            a2.SizeMode = PictureBoxSizeMode.StretchImage;
            a3.SizeMode = PictureBoxSizeMode.StretchImage;
            a4.SizeMode = PictureBoxSizeMode.StretchImage;
            a5.SizeMode = PictureBoxSizeMode.StretchImage;
            a6.SizeMode = PictureBoxSizeMode.StretchImage;
            a7.SizeMode = PictureBoxSizeMode.StretchImage;
            a8.SizeMode = PictureBoxSizeMode.StretchImage;

            b1.SizeMode = PictureBoxSizeMode.StretchImage;
            b2.SizeMode = PictureBoxSizeMode.StretchImage;
            b3.SizeMode = PictureBoxSizeMode.StretchImage;
            b4.SizeMode = PictureBoxSizeMode.StretchImage;
            b5.SizeMode = PictureBoxSizeMode.StretchImage;
            b6.SizeMode = PictureBoxSizeMode.StretchImage;
            b7.SizeMode = PictureBoxSizeMode.StretchImage;
            b8.SizeMode = PictureBoxSizeMode.StretchImage;

            c1.SizeMode = PictureBoxSizeMode.StretchImage;
            c2.SizeMode = PictureBoxSizeMode.StretchImage;
            c3.SizeMode = PictureBoxSizeMode.StretchImage;
            c4.SizeMode = PictureBoxSizeMode.StretchImage;
            c5.SizeMode = PictureBoxSizeMode.StretchImage;
            c6.SizeMode = PictureBoxSizeMode.StretchImage;
            c7.SizeMode = PictureBoxSizeMode.StretchImage;
            c8.SizeMode = PictureBoxSizeMode.StretchImage;

            d1.SizeMode = PictureBoxSizeMode.StretchImage;
            d2.SizeMode = PictureBoxSizeMode.StretchImage;
            d3.SizeMode = PictureBoxSizeMode.StretchImage;
            d4.SizeMode = PictureBoxSizeMode.StretchImage;
            d5.SizeMode = PictureBoxSizeMode.StretchImage;
            d6.SizeMode = PictureBoxSizeMode.StretchImage;
            d7.SizeMode = PictureBoxSizeMode.StretchImage;
            d8.SizeMode = PictureBoxSizeMode.StretchImage;

            e1.SizeMode = PictureBoxSizeMode.StretchImage;
            e2.SizeMode = PictureBoxSizeMode.StretchImage;
            e3.SizeMode = PictureBoxSizeMode.StretchImage;
            e4.SizeMode = PictureBoxSizeMode.StretchImage;
            e5.SizeMode = PictureBoxSizeMode.StretchImage;
            e6.SizeMode = PictureBoxSizeMode.StretchImage;
            e7.SizeMode = PictureBoxSizeMode.StretchImage;
            e8.SizeMode = PictureBoxSizeMode.StretchImage;

            f1.SizeMode = PictureBoxSizeMode.StretchImage;
            f2.SizeMode = PictureBoxSizeMode.StretchImage;
            f3.SizeMode = PictureBoxSizeMode.StretchImage;
            f4.SizeMode = PictureBoxSizeMode.StretchImage;
            f5.SizeMode = PictureBoxSizeMode.StretchImage;
            f6.SizeMode = PictureBoxSizeMode.StretchImage;
            f7.SizeMode = PictureBoxSizeMode.StretchImage;
            f8.SizeMode = PictureBoxSizeMode.StretchImage;

            g1.SizeMode = PictureBoxSizeMode.StretchImage;
            g2.SizeMode = PictureBoxSizeMode.StretchImage;
            g3.SizeMode = PictureBoxSizeMode.StretchImage;
            g4.SizeMode = PictureBoxSizeMode.StretchImage;
            g5.SizeMode = PictureBoxSizeMode.StretchImage;
            g6.SizeMode = PictureBoxSizeMode.StretchImage;
            g7.SizeMode = PictureBoxSizeMode.StretchImage;
            g8.SizeMode = PictureBoxSizeMode.StretchImage;

            h1.SizeMode = PictureBoxSizeMode.StretchImage;
            h2.SizeMode = PictureBoxSizeMode.StretchImage;
            h3.SizeMode = PictureBoxSizeMode.StretchImage;
            h4.SizeMode = PictureBoxSizeMode.StretchImage;
            h5.SizeMode = PictureBoxSizeMode.StretchImage;
            h6.SizeMode = PictureBoxSizeMode.StretchImage;
            h7.SizeMode = PictureBoxSizeMode.StretchImage;
            h8.SizeMode = PictureBoxSizeMode.StretchImage;

            a2.Image = System.Drawing.Image.FromFile("bauer.png");
            b2.Image = System.Drawing.Image.FromFile("bauer.png");
            c2.Image = System.Drawing.Image.FromFile("bauer.png");
            d2.Image = System.Drawing.Image.FromFile("bauer.png");
            e2.Image = System.Drawing.Image.FromFile("bauer.png");
            f2.Image = System.Drawing.Image.FromFile("bauer.png");
            g2.Image = System.Drawing.Image.FromFile("bauer.png");
            h2.Image = System.Drawing.Image.FromFile("bauer.png");
            a1.Image = System.Drawing.Image.FromFile("turm.png");
            h1.Image = System.Drawing.Image.FromFile("turm.png");
            b1.Image = System.Drawing.Image.FromFile("springer.png");
            g1.Image = System.Drawing.Image.FromFile("springer.png");
            c1.Image = System.Drawing.Image.FromFile("laeufer.png");
            f1.Image = System.Drawing.Image.FromFile("laeufer.png");
            d1.Image = System.Drawing.Image.FromFile("dame.png");
            e1.Image = System.Drawing.Image.FromFile("koenig.png");

            a7.Image = System.Drawing.Image.FromFile("bauer2.png");
            b7.Image = System.Drawing.Image.FromFile("bauer2.png");
            c7.Image = System.Drawing.Image.FromFile("bauer2.png");
            d7.Image = System.Drawing.Image.FromFile("bauer2.png");
            e7.Image = System.Drawing.Image.FromFile("bauer2.png");
            f7.Image = System.Drawing.Image.FromFile("bauer2.png");
            g7.Image = System.Drawing.Image.FromFile("bauer2.png");
            h7.Image = System.Drawing.Image.FromFile("bauer2.png");
            a8.Image = System.Drawing.Image.FromFile("turm2.png");
            h8.Image = System.Drawing.Image.FromFile("turm2.png");
            b8.Image = System.Drawing.Image.FromFile("springer2.png");
            g8.Image = System.Drawing.Image.FromFile("springer2.png");
            c8.Image = System.Drawing.Image.FromFile("laeufer2.png");
            f8.Image = System.Drawing.Image.FromFile("laeufer2.png");
            d8.Image = System.Drawing.Image.FromFile("dame2.png");
            e8.Image = System.Drawing.Image.FromFile("koenig2.png");
        }

        class Warten
        {
            public Warten(LaunchpadDevice alt)
            {
                clock(alt);
            }

            void clock(LaunchpadDevice device)
            {
                Clock warten = new Clock(160);
                warten.Start();
                device[1, 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[2, 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[1, 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);

                device[6, 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[5, 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[6, 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);

                device[1, 5].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[1, 6].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[2, 6].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);

                device[6, 5].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[5, 6].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                device[6, 6].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);

                bool stop = false;
                while (stop == false)
                {
                    if (warten.Time == 1 || warten.Time == 5)
                    {
                        if (warten.Time >= 3)
                        {
                            stop = true;
                            warten.Stop();
                            device[3, 4].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            device[4, 3].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            device[4, 4].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            device[3, 3].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            System.Threading.Thread.Sleep(375);
                            device.Reset();
                            break;
                        }
                        else
                        {
                            device[3, 4].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            device[4, 3].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            device[4, 4].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            device[3, 3].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                    }
                    else if (warten.Time == 2)
                    {
                        device[3, 4].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                        device[4, 3].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                        device[4, 4].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                        device[3, 3].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    }
                    else if (warten.Time == 3)
                    {
                        device[3, 4].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        device[4, 3].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        device[4, 4].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        device[3, 3].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                    }
                    else if (warten.Time == 4)
                    {
                        device[3, 4].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                        device[4, 3].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                        device[4, 4].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                        device[3, 3].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    }
                }
            }
        }

        void hilfe()
        {
            textBox2.Text = "Hilfe:" + Environment.NewLine;
            textBox2.Text = textBox2.Text + "Drücken Sie während eines Spiels [mixer] auf dem Launchpad,\num die Ansicht umzuschalten." + Environment.NewLine;
            textBox2.Text = textBox2.Text + "Drücken Sie während eines Spiels [user1] bzw. [user2] auf dem Launchpad,\num den am Zug befindlichen Spieler manuell zu wechseln." + Environment.NewLine;
            textBox2.Text = textBox2.Text + "Sie können echte Figuren auf das Launchpad stellen, oder aber nur die Anzeige des Programms verwenden." + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e) //Neues Spiel
        {
            if (firstclick == true)
            {
                neuesspiel = new Schach(textBox2, textBox1, device, pictureBox1, a1, a2, a3, a4, a5, a6, a7, a8, b1, b2, b3, b4, b5, b6, b7, b8, c1, c2, c3, c4, c5, c6, c7, c8, d1, d2, d3, d4, d5, d6, d7, d8, e1, e2, e3, e4, e5, e6, e7, e8, f1, f2, f3, f4, f5, f6, f7, f8, g1, g2, g3, g4, g5, g6, g7, g8, h1, h2, h3, h4, h5, h6, h7, h8);
                firstclick = false;
                button1.Text = "Partie Beenden";
                figurensetzen();
                textBox2.Text = "Neue Schachpartie:";
            }
            else
            {
                System.Windows.Forms.Application.Restart();
                neuesspiel.exit();
                GC.SuppressFinalize(device);
                GC.SuppressFinalize(neuesspiel);
                GC.Collect();
                firstclick = true;
                button1.Text = "Neue Partie";
            }
        }

        private class Schach
        {
            public LaunchpadDevice mLaunchpadDevice;

            public Schach(TextBox TextBox2, TextBox TextBox1, LaunchpadDevice device, PictureBox PicBoxx, PictureBox a1, PictureBox a2, PictureBox a3, PictureBox a4, PictureBox a5, PictureBox a6, PictureBox a7, PictureBox a8, PictureBox b1, PictureBox b2, PictureBox b3, PictureBox b4, PictureBox b5, PictureBox b6, PictureBox b7, PictureBox b8, PictureBox c1, PictureBox c2, PictureBox c3, PictureBox c4, PictureBox c5, PictureBox c6, PictureBox c7, PictureBox c8, PictureBox d1, PictureBox d2, PictureBox d3, PictureBox d4, PictureBox d5, PictureBox d6, PictureBox d7, PictureBox d8, PictureBox e1, PictureBox e2, PictureBox e3, PictureBox e4, PictureBox e5, PictureBox e6, PictureBox e7, PictureBox e8, PictureBox f1, PictureBox f2, PictureBox f3, PictureBox f4, PictureBox f5, PictureBox f6, PictureBox f7, PictureBox f8, PictureBox g1, PictureBox g2, PictureBox g3, PictureBox g4, PictureBox g5, PictureBox g6, PictureBox g7, PictureBox g8, PictureBox h1, PictureBox h2, PictureBox h3, PictureBox h4, PictureBox h5, PictureBox h6, PictureBox h7, PictureBox h8)
            {
                initialisieren();
                pa1 = a1;
                pa2 = a2;
                pa3 = a3;
                pa4 = a4;
                pa5 = a5;
                pa6 = a6;
                pa7 = a7;
                pa8 = a8;

                pb1 = b1;
                pb2 = b2;
                pb3 = b3;
                pb4 = b4;
                pb5 = b5;
                pb6 = b6;
                pb7 = b7;
                pb8 = b8;

                pc1 = c1;
                pc2 = c2;
                pc3 = c3;
                pc4 = c4;
                pc5 = c5;
                pc6 = c6;
                pc7 = c7;
                pc8 = c8;

                pd1 = d1;
                pd2 = d2;
                pd3 = d3;
                pd4 = d4;
                pd5 = d5;
                pd6 = d6;
                pd7 = d7;
                pd8 = d8;

                pe1 = e1;
                pe2 = e2;
                pe3 = e3;
                pe4 = e4;
                pe5 = e5;
                pe6 = e6;
                pe7 = e7;
                pe8 = e8;

                pf1 = f1;
                pf2 = f2;
                pf3 = f3;
                pf4 = f4;
                pf5 = f5;
                pf6 = f6;
                pf7 = f7;
                pf8 = f8;

                pg1 = g1;
                pg2 = g2;
                pg3 = g3;
                pg4 = g4;
                pg5 = g5;
                pg6 = g6;
                pg7 = g7;
                pg8 = g8;

                ph1 = h1;
                ph2 = h2;
                ph3 = h3;
                ph4 = h4;
                ph5 = h5;
                ph6 = h6;
                ph7 = h7;
                ph8 = h8;
                mLaunchpadDevice = device;
                PictureBox1 = PicBoxx;
                mLaunchpadDevice.DoubleBuffered = false; //Geändert..!
                ausgabe = TextBox2;
                ausgabetb2 = TextBox1;
                mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                spieleranzeige();
                launchpadaus(mLaunchpadDevice);
                showboard();
                mLaunchpadDevice.ButtonPressed += mLaunchpadDevice_ButtonPressed;
            } //Konstruktor

            public void exit()
            {
                mLaunchpadDevice.Reset();
                GC.SuppressFinalize(ar);
                GC.SuppressFinalize(br);
                GC.SuppressFinalize(cr);
                GC.SuppressFinalize(dr);
                GC.SuppressFinalize(er);
                GC.SuppressFinalize(fr);
                GC.SuppressFinalize(gr);
                GC.SuppressFinalize(hr);
                GC.SuppressFinalize(ag);
                GC.SuppressFinalize(bg);
                GC.SuppressFinalize(cg);
                GC.SuppressFinalize(dg);
                GC.SuppressFinalize(eg);
                GC.SuppressFinalize(fg);
                GC.SuppressFinalize(gg);
                GC.SuppressFinalize(hg);
                GC.SuppressFinalize(t1r);
                GC.SuppressFinalize(t2r);
                GC.SuppressFinalize(s1r);
                GC.SuppressFinalize(s2r);
                GC.SuppressFinalize(l1r);
                GC.SuppressFinalize(l2r);
                GC.SuppressFinalize(damerot);
                GC.SuppressFinalize(koenigrot);
                GC.SuppressFinalize(t1g);
                GC.SuppressFinalize(t2g);
                GC.SuppressFinalize(s1g);
                GC.SuppressFinalize(s2g);
                GC.SuppressFinalize(l1g);
                GC.SuppressFinalize(l2g);
                GC.SuppressFinalize(damegruen);
                GC.SuppressFinalize(koeniggruen);
                GC.Collect();
            }
            public TextBox ausgabe;
            public TextBox ausgabetb2;
            public PictureBox PictureBox1;

            public void initialisieren()
            {
                ausgabe = new TextBox();
                ausgabetb2 = new TextBox();
                PictureBox1 = new PictureBox();

                pa1 = new PictureBox();
                pa2 = new PictureBox();
                pa3 = new PictureBox();
                pa4 = new PictureBox();
                pa5 = new PictureBox();
                pa6 = new PictureBox();
                pa7 = new PictureBox();
                pa8 = new PictureBox();

                pb1 = new PictureBox();
                pb2 = new PictureBox();
                pb3 = new PictureBox();
                pb4 = new PictureBox();
                pb5 = new PictureBox();
                pb6 = new PictureBox();
                pb7 = new PictureBox();
                pb8 = new PictureBox();

                pc1 = new PictureBox();
                pc2 = new PictureBox();
                pc3 = new PictureBox();
                pc4 = new PictureBox();
                pc5 = new PictureBox();
                pc6 = new PictureBox();
                pc7 = new PictureBox();
                pc8 = new PictureBox();

                pd1 = new PictureBox();
                pd2 = new PictureBox();
                pd3 = new PictureBox();
                pd4 = new PictureBox();
                pd5 = new PictureBox();
                pd6 = new PictureBox();
                pd7 = new PictureBox();
                pd8 = new PictureBox();

                pe1 = new PictureBox();
                pe2 = new PictureBox();
                pe3 = new PictureBox();
                pe4 = new PictureBox();
                pe5 = new PictureBox();
                pe6 = new PictureBox();
                pe7 = new PictureBox();
                pe8 = new PictureBox();

                pf1 = new PictureBox();
                pf2 = new PictureBox();
                pf3 = new PictureBox();
                pf4 = new PictureBox();
                pf5 = new PictureBox();
                pf6 = new PictureBox();
                pf7 = new PictureBox();
                pf8 = new PictureBox();

                pg1 = new PictureBox();
                pg2 = new PictureBox();
                pg3 = new PictureBox();
                pg4 = new PictureBox();
                pg5 = new PictureBox();
                pg6 = new PictureBox();
                pg7 = new PictureBox();
                pg8 = new PictureBox();

                ph1 = new PictureBox();
                ph2 = new PictureBox();
                ph3 = new PictureBox();
                ph4 = new PictureBox();
                ph5 = new PictureBox();
                ph6 = new PictureBox();
                ph7 = new PictureBox();
                ph8 = new PictureBox();
            }

            public PictureBox pa1;
            public PictureBox pa2;
            public PictureBox pa3;
            public PictureBox pa4;
            public PictureBox pa5;
            public PictureBox pa6;
            public PictureBox pa7;
            public PictureBox pa8;

            public PictureBox pb1;
            public PictureBox pb2;
            public PictureBox pb3;
            public PictureBox pb4;
            public PictureBox pb5;
            public PictureBox pb6;
            public PictureBox pb7;
            public PictureBox pb8;

            public PictureBox pc1;
            public PictureBox pc2;
            public PictureBox pc3;
            public PictureBox pc4;
            public PictureBox pc5;
            public PictureBox pc6;
            public PictureBox pc7;
            public PictureBox pc8;

            public PictureBox pd1;
            public PictureBox pd2;
            public PictureBox pd3;
            public PictureBox pd4;
            public PictureBox pd5;
            public PictureBox pd6;
            public PictureBox pd7;
            public PictureBox pd8;

            public PictureBox pe1;
            public PictureBox pe2;
            public PictureBox pe3;
            public PictureBox pe4;
            public PictureBox pe5;
            public PictureBox pe6;
            public PictureBox pe7;
            public PictureBox pe8;

            public PictureBox pf1;
            public PictureBox pf2;
            public PictureBox pf3;
            public PictureBox pf4;
            public PictureBox pf5;
            public PictureBox pf6;
            public PictureBox pf7;
            public PictureBox pf8;

            public PictureBox pg1;
            public PictureBox pg2;
            public PictureBox pg3;
            public PictureBox pg4;
            public PictureBox pg5;
            public PictureBox pg6;
            public PictureBox pg7;
            public PictureBox pg8;

            public PictureBox ph1;
            public PictureBox ph2;
            public PictureBox ph3;
            public PictureBox ph4;
            public PictureBox ph5;
            public PictureBox ph6;
            public PictureBox ph7;
            public PictureBox ph8;

            System.Media.SoundPlayer MusicPlayer = new System.Media.SoundPlayer(); //Zum Abspielen der Sounds

            int zug = 1;
            Bauerrot ar = new Bauerrot(0, 6);
            Bauerrot br = new Bauerrot(1, 6);
            Bauerrot cr = new Bauerrot(2, 6);
            Bauerrot dr = new Bauerrot(3, 6);
            Bauerrot er = new Bauerrot(4, 6);
            Bauerrot fr = new Bauerrot(5, 6);
            Bauerrot gr = new Bauerrot(6, 6);
            Bauerrot hr = new Bauerrot(7, 6);
            Bauergruen ag = new Bauergruen(0, 1);
            Bauergruen bg = new Bauergruen(1, 1);
            Bauergruen cg = new Bauergruen(2, 1);
            Bauergruen dg = new Bauergruen(3, 1);
            Bauergruen eg = new Bauergruen(4, 1);
            Bauergruen fg = new Bauergruen(5, 1);
            Bauergruen gg = new Bauergruen(6, 1);
            Bauergruen hg = new Bauergruen(7, 1);
            Turmrot t1r = new Turmrot(0, 7);
            Turmrot t2r = new Turmrot(7, 7);
            Turmgruen t1g = new Turmgruen(0, 0);
            Turmgruen t2g = new Turmgruen(7, 0);
            Springerrot s1r = new Springerrot(1, 7);
            Springerrot s2r = new Springerrot(6, 7);
            Springergruen s1g = new Springergruen(1, 0);
            Springergruen s2g = new Springergruen(6, 0);
            Koenigrot koenigrot = new Koenigrot(4, 7);
            Koeniggruen koeniggruen = new Koeniggruen(4, 0);
            Laeuferrot l1r = new Laeuferrot(2, 7);
            Laeuferrot l2r = new Laeuferrot(5, 7);
            Laeufergruen l1g = new Laeufergruen(2, 0);
            Laeufergruen l2g = new Laeufergruen(5, 0);
            Damerot damerot = new Damerot(3, 7);
            Damegruen damegruen = new Damegruen(3, 0);

            int bauer = 0;
            int bauerg = 0;
            int turm = 0;
            int turmg = 0;
            int springer = 0;
            int springerg = 0;
            int laeufer = 0;
            int laeuferg = 0;
            int dame = 0;
            int dameg = 0;
            int rotverwandelt = 0;
            int gruenverwandelt = 0;
            int passantgruen = 9;
            int passantrot = 9;

            bool baueristdran = false;
            bool turmistdran = false;
            bool springeristdran = false;
            bool koenigistdran = false;
            bool laeuferistdran = false;
            bool dameistdran = false;
            bool rochaderotgross = true, rochaderotklein = true;
            bool rochadegruengross = true, rochadegruenklein = true;

            bool mixer = true;
            int checkbauer(int x, int y)
            {
                bauer = 8;
                if (ar.ison(x, y))
                    bauer = 0;
                if (br.ison(x, y))
                    bauer = 1;
                if (cr.ison(x, y))
                    bauer = 2;
                if (dr.ison(x, y))
                    bauer = 3;
                if (er.ison(x, y))
                    bauer = 4;
                if (fr.ison(x, y))
                    bauer = 5;
                if (gr.ison(x, y))
                    bauer = 6;
                if (hr.ison(x, y))
                    bauer = 7;
                if (bauer != 8)
                    return bauer;
                if (ag.ison(x, y))
                    bauerg = 0;
                if (bg.ison(x, y))
                    bauerg = 1;
                if (cg.ison(x, y))
                    bauerg = 2;
                if (dg.ison(x, y))
                    bauerg = 3;
                if (eg.ison(x, y))
                    bauerg = 4;
                if (fg.ison(x, y))
                    bauerg = 5;
                if (gg.ison(x, y))
                    bauerg = 6;
                if (hg.ison(x, y))
                    bauerg = 7;
                return bauerg;
            } //Überprüft, um welchen Bauern es sich handelt
            int checkturm(int x, int y)
            {
                turm = 8;
                if (t1r.ison(x, y))
                    turm = 1;
                if (t2r.ison(x, y))
                    turm = 2;
                if (ersatzturm1.ison(x, y))
                    turm = 3;
                if (ersatzturm2.ison(x, y))
                    turm = 4;
                if (ersatzturm3.ison(x, y))
                    turm = 4;
                if (turm != 8)
                    return turm;
                if (t1g.ison(x, y))
                    turmg = 1;
                if (t2g.ison(x, y))
                    turmg = 2;
                if (ersatzturm1g.ison(x, y))
                    turmg = 3;
                if (ersatzturm2g.ison(x, y))
                    turmg = 4;
                if (ersatzturm3g.ison(x, y))
                    turmg = 4;
                return turmg;
            }  //Überprüft, um welchen Turm es sich handelt
            int checkspringer(int x, int y)
            {
                springer = 8;
                if (s1r.ison(x, y))
                    springer = 1;
                if (s2r.ison(x, y))
                    springer = 2;
                if (ersatzspringer1.ison(x,y))
                    springer = 3;
                if (ersatzspringer2.ison(x,y))
                    springer = 4;
                if (ersatzspringer3.ison(x,y))
                    springer = 5;
                if (springer != 8)
                    return springer;
                if (s1g.ison(x, y))
                    springerg = 1;
                if (s2g.ison(x, y))
                    springerg = 2;
                if (ersatzspringer1g.ison(x,y))
                    springerg = 3;
                if (ersatzspringer2g.ison(x,y))
                    springerg = 4;
                if (ersatzspringer3g.ison(x,y))
                    springerg = 5;
                return springerg;
            } //...
            int checklaeufer(int x, int y)
            {
                laeufer = 8;
                if (l1r.ison(x, y))
                    laeufer = 1;
                if (l2r.ison(x, y))
                    laeufer = 2;
                if (ersatzlaeufer1.ison(x, y))
                    laeufer = 3;
                if (ersatzlaeufer2.ison(x, y))
                    laeufer = 4;
                if (ersatzlaeufer3.ison(x, y))
                    laeufer = 5;
                if (laeufer != 8)
                    return laeufer;
                if (l1g.ison(x, y))
                    laeuferg = 1;
                if (l2g.ison(x, y))
                    laeuferg = 2;
                if (ersatzlaeufer1g.ison(x, y))
                    laeuferg = 3;
                if (ersatzlaeufer2g.ison(x, y))
                    laeuferg = 4;
                if (ersatzlaeufer3g.ison(x, y))
                    laeuferg = 5;
                return laeuferg;
            }  //...

            public void launchpadaus(LaunchpadDevice device)
            {
                for (int y = 0; y < 8; y++)
                    for (int x = 0; x < 8; x++)
                        device[x, y].TurnOffLight();
            }
            void showboard()
            {
                if (mixer == true)
                {
                    launchpadaus(mLaunchpadDevice);
                    showfigures();
                }
                else
                {
                    if (zug == 2)
                        for (int y = 0; y < 8; y++)
                            for (int x = 0; x < 8; x++)
                                if (y % 2 == 0)
                                {
                                    if (x % 2 == 0)
                                    {
                                        mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                                    }
                                    else mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                                }
                                else
                                    if (x % 2 == 0)
                                    {
                                        mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                                    }
                                    else mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    if (zug == 1)
                        for (int y = 0; y < 8; y++)
                            for (int x = 0; x < 8; x++)
                                if (y % 2 == 0)
                                {
                                    if (x % 2 == 0)
                                    {
                                        mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                                    }
                                    else mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                                }
                                else
                                    if (x % 2 == 0)
                                    {
                                        mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                                    }
                                    else mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                }
            }
            void spieleranzeige()
            {
                checkfield();
                if (zug == 1)
                {
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                }
                else
                {
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                }
            }
            void gewonnen()
            {
                launchpadaus(mLaunchpadDevice);
                mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);

                if (zug == 1)
                {
                    for (int y = 0; y < 8; y++)
                        for (int x = 0; x < 8; x++)
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(1000);
                    launchpadaus(mLaunchpadDevice);
                    mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(500);
                    for (int y = 0; y < 8; y++)
                        for (int x = 0; x < 8; x++)
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(1000);
                    launchpadaus(mLaunchpadDevice);
                    mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(500);
                    for (int y = 0; y < 8; y++)
                        for (int x = 0; x < 8; x++)
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(1000);
                    launchpadaus(mLaunchpadDevice);
                    mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(500);
                }
                if (zug == 2)
                {
                    for (int y = 0; y < 8; y++)
                        for (int x = 0; x < 8; x++)
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                    System.Threading.Thread.Sleep(1000);
                    launchpadaus(mLaunchpadDevice);
                    mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(500);
                    for (int y = 0; y < 8; y++)
                        for (int x = 0; x < 8; x++)
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                    System.Threading.Thread.Sleep(1000);
                    launchpadaus(mLaunchpadDevice);
                    mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(500);
                    for (int y = 0; y < 8; y++)
                        for (int x = 0; x < 8; x++)
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                    System.Threading.Thread.Sleep(1000);
                    launchpadaus(mLaunchpadDevice);
                    mLaunchpadDevice.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    mLaunchpadDevice.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
                    System.Threading.Thread.Sleep(500);
                }
            }

            delegate void StringParameterDelegate(string value);
            void ausgeben(string value)
            {
                if (ausgabe.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ausgabe.BeginInvoke(new StringParameterDelegate(ausgeben), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ausgabe.Text = ausgabe.Text + Environment.NewLine + value;
            }
            public void ausgeben2(string value)
            {
                if (ausgabe.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ausgabetb2.BeginInvoke(new StringParameterDelegate(ausgeben2), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ausgabetb2.Text = value;
            }
            void pboxchange(string value)
            {
                if (PictureBox1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    PictureBox1.BeginInvoke(new StringParameterDelegate(pboxchange), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                PictureBox1.Image = System.Drawing.Image.FromFile(value);
            }

            public void a1set(string value)
            {
                if (pa1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa1.BeginInvoke(new StringParameterDelegate(a1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa1.Image = System.Drawing.Image.FromFile(value);
            }
            public void a2set(string value)
            {
                if (pa2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa2.BeginInvoke(new StringParameterDelegate(a2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa2.Image = System.Drawing.Image.FromFile(value);
            }
            public void a3set(string value)
            {
                if (pa3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa3.BeginInvoke(new StringParameterDelegate(a3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa3.Image = System.Drawing.Image.FromFile(value);
            }
            public void a4set(string value)
            {
                if (pa4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa4.BeginInvoke(new StringParameterDelegate(a4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa4.Image = System.Drawing.Image.FromFile(value);
            }
            public void a5set(string value)
            {
                if (pa5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa5.BeginInvoke(new StringParameterDelegate(a5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa5.Image = System.Drawing.Image.FromFile(value);
            }
            public void a6set(string value)
            {
                if (pa6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa6.BeginInvoke(new StringParameterDelegate(a6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa6.Image = System.Drawing.Image.FromFile(value);
            }
            public void a7set(string value)
            {
                if (pa7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa7.BeginInvoke(new StringParameterDelegate(a7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa7.Image = System.Drawing.Image.FromFile(value);
            }
            public void a8set(string value)
            {
                if (pa8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pa8.BeginInvoke(new StringParameterDelegate(a8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pa8.Image = System.Drawing.Image.FromFile(value);
            }

            public void b1set(string value)
            {
                if (pb1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb1.BeginInvoke(new StringParameterDelegate(b1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb1.Image = System.Drawing.Image.FromFile(value);
            }
            public void b2set(string value)
            {
                if (pb2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb2.BeginInvoke(new StringParameterDelegate(b2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb2.Image = System.Drawing.Image.FromFile(value);
            }
            public void b3set(string value)
            {
                if (pb3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb3.BeginInvoke(new StringParameterDelegate(b3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb3.Image = System.Drawing.Image.FromFile(value);
            }
            public void b4set(string value)
            {
                if (pb4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb4.BeginInvoke(new StringParameterDelegate(b4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb4.Image = System.Drawing.Image.FromFile(value);
            }
            public void b5set(string value)
            {
                if (pb5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb5.BeginInvoke(new StringParameterDelegate(b5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb5.Image = System.Drawing.Image.FromFile(value);
            }
            public void b6set(string value)
            {
                if (pb6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb6.BeginInvoke(new StringParameterDelegate(b6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb6.Image = System.Drawing.Image.FromFile(value);
            }
            public void b7set(string value)
            {
                if (pb7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb7.BeginInvoke(new StringParameterDelegate(b7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb7.Image = System.Drawing.Image.FromFile(value);
            }
            public void b8set(string value)
            {
                if (pb8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pb8.BeginInvoke(new StringParameterDelegate(b8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pb8.Image = System.Drawing.Image.FromFile(value);
            }

            public void c1set(string value)
            {
                if (pc1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc1.BeginInvoke(new StringParameterDelegate(c1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc1.Image = System.Drawing.Image.FromFile(value);
            }
            public void c2set(string value)
            {
                if (pc2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc2.BeginInvoke(new StringParameterDelegate(c2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc2.Image = System.Drawing.Image.FromFile(value);
            }
            public void c3set(string value)
            {
                if (pc3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc3.BeginInvoke(new StringParameterDelegate(c3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc3.Image = System.Drawing.Image.FromFile(value);
            }
            public void c4set(string value)
            {
                if (pc4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc4.BeginInvoke(new StringParameterDelegate(c4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc4.Image = System.Drawing.Image.FromFile(value);
            }
            public void c5set(string value)
            {
                if (pc5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc5.BeginInvoke(new StringParameterDelegate(c5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc5.Image = System.Drawing.Image.FromFile(value);
            }
            public void c6set(string value)
            {
                if (pc6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc6.BeginInvoke(new StringParameterDelegate(c6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc6.Image = System.Drawing.Image.FromFile(value);
            }
            public void c7set(string value)
            {
                if (pc7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc7.BeginInvoke(new StringParameterDelegate(c7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc7.Image = System.Drawing.Image.FromFile(value);
            }
            public void c8set(string value)
            {
                if (pc8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pc8.BeginInvoke(new StringParameterDelegate(c8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pc8.Image = System.Drawing.Image.FromFile(value);
            }

            public void d1set(string value)
            {
                if (pd1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd1.BeginInvoke(new StringParameterDelegate(d1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd1.Image = System.Drawing.Image.FromFile(value);
            }
            public void d2set(string value)
            {
                if (pd2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd2.BeginInvoke(new StringParameterDelegate(d2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd2.Image = System.Drawing.Image.FromFile(value);
            }
            public void d3set(string value)
            {
                if (pd3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd3.BeginInvoke(new StringParameterDelegate(d3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd3.Image = System.Drawing.Image.FromFile(value);
            }
            public void d4set(string value)
            {
                if (pd4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd4.BeginInvoke(new StringParameterDelegate(d4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd4.Image = System.Drawing.Image.FromFile(value);
            }
            public void d5set(string value)
            {
                if (pd5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd5.BeginInvoke(new StringParameterDelegate(d5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd5.Image = System.Drawing.Image.FromFile(value);
            }
            public void d6set(string value)
            {
                if (pd6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd6.BeginInvoke(new StringParameterDelegate(d6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd6.Image = System.Drawing.Image.FromFile(value);
            }
            public void d7set(string value)
            {
                if (pd7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd7.BeginInvoke(new StringParameterDelegate(d7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd7.Image = System.Drawing.Image.FromFile(value);
            }
            public void d8set(string value)
            {
                if (pd8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pd8.BeginInvoke(new StringParameterDelegate(d8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pd8.Image = System.Drawing.Image.FromFile(value);
            }

            public void e1set(string value)
            {
                if (pe1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe1.BeginInvoke(new StringParameterDelegate(e1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe1.Image = System.Drawing.Image.FromFile(value);
            }
            public void e2set(string value)
            {
                if (pe2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe2.BeginInvoke(new StringParameterDelegate(e2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe2.Image = System.Drawing.Image.FromFile(value);
            }
            public void e3set(string value)
            {
                if (pe3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe3.BeginInvoke(new StringParameterDelegate(e3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe3.Image = System.Drawing.Image.FromFile(value);
            }
            public void e4set(string value)
            {
                if (pe4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe4.BeginInvoke(new StringParameterDelegate(e4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe4.Image = System.Drawing.Image.FromFile(value);
            }
            public void e5set(string value)
            {
                if (pe5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe5.BeginInvoke(new StringParameterDelegate(e5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe5.Image = System.Drawing.Image.FromFile(value);
            }
            public void e6set(string value)
            {
                if (pe6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe6.BeginInvoke(new StringParameterDelegate(e6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe6.Image = System.Drawing.Image.FromFile(value);
            }
            public void e7set(string value)
            {
                if (pe7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe7.BeginInvoke(new StringParameterDelegate(e7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe7.Image = System.Drawing.Image.FromFile(value);
            }
            public void e8set(string value)
            {
                if (pe8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pe8.BeginInvoke(new StringParameterDelegate(e8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pe8.Image = System.Drawing.Image.FromFile(value);
            }

            public void f1set(string value)
            {
                if (pf1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf1.BeginInvoke(new StringParameterDelegate(f1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf1.Image = System.Drawing.Image.FromFile(value);
            }
            public void f2set(string value)
            {
                if (pf2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf2.BeginInvoke(new StringParameterDelegate(f2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf2.Image = System.Drawing.Image.FromFile(value);
            }
            public void f3set(string value)
            {
                if (pf3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf3.BeginInvoke(new StringParameterDelegate(f3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf3.Image = System.Drawing.Image.FromFile(value);
            }
            public void f4set(string value)
            {
                if (pf4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf4.BeginInvoke(new StringParameterDelegate(f4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf4.Image = System.Drawing.Image.FromFile(value);
            }
            public void f5set(string value)
            {
                if (pf5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf5.BeginInvoke(new StringParameterDelegate(f5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf5.Image = System.Drawing.Image.FromFile(value);
            }
            public void f6set(string value)
            {
                if (pf6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf6.BeginInvoke(new StringParameterDelegate(f6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf6.Image = System.Drawing.Image.FromFile(value);
            }
            public void f7set(string value)
            {
                if (pf7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf7.BeginInvoke(new StringParameterDelegate(f7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf7.Image = System.Drawing.Image.FromFile(value);
            }
            public void f8set(string value)
            {
                if (pf8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pf8.BeginInvoke(new StringParameterDelegate(f8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pf8.Image = System.Drawing.Image.FromFile(value);
            }

            public void g1set(string value)
            {
                if (pg1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg1.BeginInvoke(new StringParameterDelegate(g1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg1.Image = System.Drawing.Image.FromFile(value);
            }
            public void g2set(string value)
            {
                if (pg2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg2.BeginInvoke(new StringParameterDelegate(g2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg2.Image = System.Drawing.Image.FromFile(value);
            }
            public void g3set(string value)
            {
                if (pg3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg3.BeginInvoke(new StringParameterDelegate(g3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg3.Image = System.Drawing.Image.FromFile(value);
            }
            public void g4set(string value)
            {
                if (pg4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg4.BeginInvoke(new StringParameterDelegate(g4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg4.Image = System.Drawing.Image.FromFile(value);
            }
            public void g5set(string value)
            {
                if (pg5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg5.BeginInvoke(new StringParameterDelegate(g5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg5.Image = System.Drawing.Image.FromFile(value);
            }
            public void g6set(string value)
            {
                if (pg6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg6.BeginInvoke(new StringParameterDelegate(g6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg6.Image = System.Drawing.Image.FromFile(value);
            }
            public void g7set(string value)
            {
                if (pg7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg7.BeginInvoke(new StringParameterDelegate(g7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg7.Image = System.Drawing.Image.FromFile(value);
            }
            public void g8set(string value)
            {
                if (pg8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    pg8.BeginInvoke(new StringParameterDelegate(g8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                pg8.Image = System.Drawing.Image.FromFile(value);
            }

            public void h1set(string value)
            {
                if (ph1.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph1.BeginInvoke(new StringParameterDelegate(h1set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph1.Image = System.Drawing.Image.FromFile(value);
            }
            public void h2set(string value)
            {
                if (ph2.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph2.BeginInvoke(new StringParameterDelegate(h2set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph2.Image = System.Drawing.Image.FromFile(value);
            }
            public void h3set(string value)
            {
                if (ph3.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph3.BeginInvoke(new StringParameterDelegate(h3set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph3.Image = System.Drawing.Image.FromFile(value);
            }
            public void h4set(string value)
            {
                if (ph4.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph4.BeginInvoke(new StringParameterDelegate(h4set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph4.Image = System.Drawing.Image.FromFile(value);
            }
            public void h5set(string value)
            {
                if (ph5.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph5.BeginInvoke(new StringParameterDelegate(h5set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph5.Image = System.Drawing.Image.FromFile(value);
            }
            public void h6set(string value)
            {
                if (ph6.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph6.BeginInvoke(new StringParameterDelegate(h6set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph6.Image = System.Drawing.Image.FromFile(value);
            }
            public void h7set(string value)
            {
                if (ph7.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph7.BeginInvoke(new StringParameterDelegate(h7set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph7.Image = System.Drawing.Image.FromFile(value);
            }
            public void h8set(string value)
            {
                if (ph8.InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke  
                    ph8.BeginInvoke(new StringParameterDelegate(h8set), new object[] { value });
                    return;
                }
                // Must be on the UI thread if we've got this far  
                ph8.Image = System.Drawing.Image.FromFile(value);
            }

            void zugsound()
            {
                MusicPlayer.SoundLocation = "move.wav";
                MusicPlayer.Play();
            }
            void enemydiesound()
            {
                MusicPlayer.SoundLocation = "enemydie.wav";
                MusicPlayer.Play();
            }

            bool enemyon(int x, int y)
            {
                if (zug == 2 && (ar.ison(x, y) || br.ison(x, y) || cr.ison(x, y) || dr.ison(x, y) || er.ison(x, y) || fr.ison(x, y) || gr.ison(x, y) || hr.ison(x, y) || t1r.ison(x, y) || t2r.ison(x, y) || s1r.ison(x, y) || s2r.ison(x, y) || koenigrot.ison(x, y) || l1r.ison(x, y) || l2r.ison(x, y) || damerot.ison(x, y) || ersatzdame1.ison(x, y) || ersatzdame2.ison(x, y) || ersatzdame3.ison(x, y) || ersatzspringer1.ison(x, y) || ersatzspringer2.ison(x, y) || ersatzspringer3.ison(x, y) || ersatzlaeufer1.ison(x, y) || ersatzlaeufer2.ison(x, y) || ersatzlaeufer3.ison(x, y) || ersatzturm1.ison(x, y) || ersatzturm2.ison(x, y) || ersatzturm3.ison(x, y)))
                {
                    return true;
                }
                else if (zug == 1 && (ag.ison(x, y) || bg.ison(x, y) || cg.ison(x, y) || dg.ison(x, y) || eg.ison(x, y) || fg.ison(x, y) || gg.ison(x, y) || hg.ison(x, y) || t1g.ison(x, y) || t2g.ison(x, y) || s1g.ison(x, y) || s2g.ison(x, y) || koeniggruen.ison(x, y) || l1g.ison(x, y) || l2g.ison(x, y) || damegruen.ison(x, y) || ersatzdame1g.ison(x, y) || ersatzdame2g.ison(x, y) || ersatzdame3g.ison(x, y) || ersatzspringer1g.ison(x, y) || ersatzspringer2g.ison(x, y) || ersatzspringer3g.ison(x, y) || ersatzlaeufer1g.ison(x, y) || ersatzlaeufer2g.ison(x, y) || ersatzlaeufer3g.ison(x, y) || ersatzturm1g.ison(x, y) || ersatzturm2g.ison(x, y) || ersatzturm3g.ison(x, y)))
                {
                    return true;
                }

                return false;
            } //Erweitern
            bool eigeneron(int x, int y)
            {
                if (zug == 1 && (ar.ison(x, y) || br.ison(x, y) || cr.ison(x, y) || dr.ison(x, y) || er.ison(x, y) || fr.ison(x, y) || gr.ison(x, y) || hr.ison(x, y) || t1r.ison(x, y) || t2r.ison(x, y) || s1r.ison(x, y) || s2r.ison(x, y) || koenigrot.ison(x, y) || l1r.ison(x, y) || l2r.ison(x, y) || damerot.ison(x, y) || ersatzdame1.ison(x, y) || ersatzdame2.ison(x, y) || ersatzdame3.ison(x, y) || ersatzspringer1.ison(x, y) || ersatzspringer2.ison(x, y) || ersatzspringer3.ison(x, y) || ersatzlaeufer1.ison(x, y) || ersatzlaeufer2.ison(x, y) || ersatzlaeufer3.ison(x, y) || ersatzturm1.ison(x, y) || ersatzturm2.ison(x, y) || ersatzturm3.ison(x, y)))
                {
                    return true;
                }
                else if (zug == 2 && (ag.ison(x, y) || bg.ison(x, y) || cg.ison(x, y) || dg.ison(x, y) || eg.ison(x, y) || fg.ison(x, y) || gg.ison(x, y) || hg.ison(x, y) || t1g.ison(x, y) || t2g.ison(x, y) || s1g.ison(x, y) || s2g.ison(x, y) || koeniggruen.ison(x, y) || l1g.ison(x, y) || l2g.ison(x, y) || damegruen.ison(x, y) || ersatzdame1g.ison(x, y) || ersatzdame2g.ison(x, y) || ersatzdame3g.ison(x, y) || ersatzspringer1g.ison(x, y) || ersatzspringer2g.ison(x, y) || ersatzspringer3g.ison(x, y) || ersatzlaeufer1g.ison(x, y) || ersatzlaeufer2g.ison(x, y) || ersatzlaeufer3g.ison(x, y) || ersatzturm1g.ison(x, y) || ersatzturm2g.ison(x, y) || ersatzturm3g.ison(x, y)))
                {
                    return true;
                }

                return false;
            } //Erweitern
            void enemydie(int x, int y)
            {
                if (zug == 2)
                {
                    if (ar.ison(x, y))
                        ar.remove();
                    if (br.ison(x, y))
                        br.remove();
                    if (cr.ison(x, y))
                        cr.remove();
                    if (dr.ison(x, y))
                        dr.remove();
                    if (er.ison(x, y))
                        er.remove();
                    if (fr.ison(x, y))
                        fr.remove();
                    if (gr.ison(x, y))
                        gr.remove();
                    if (hr.ison(x, y))
                        hr.remove();
                    if (t1r.ison(x, y))
                        t1r.remove();
                    if (t2r.ison(x, y))
                        t2r.remove();
                    if (s1r.ison(x, y))
                        s1r.remove();
                    if (s2r.ison(x, y))
                        s2r.remove();
                    if (l1r.ison(x, y))
                        l1r.remove();
                    if (l2r.ison(x, y))
                        l2r.remove();
                    if (koenigrot.ison(x, y))
                    {
                        koenigrot.remove();
                        MusicPlayer.SoundLocation = "victory.wav";
                        MusicPlayer.Play();
                        ausgeben("Gruen hat gewonnen!");
                        gewonnen();
                        System.Windows.Forms.Application.Restart();
                    }
                    if (damerot.ison(x, y))
                        damerot.remove();
                }
                else if (zug == 1)
                {
                    if (ag.ison(x, y))
                        ag.remove();
                    if (bg.ison(x, y))
                        bg.remove();
                    if (cg.ison(x, y))
                        cg.remove();
                    if (dg.ison(x, y))
                        dg.remove();
                    if (eg.ison(x, y))
                        eg.remove();
                    if (fg.ison(x, y))
                        fg.remove();
                    if (gg.ison(x, y))
                        gg.remove();
                    if (hg.ison(x, y))
                        hg.remove();
                    if (t1g.ison(x, y))
                        t1g.remove();
                    if (t2g.ison(x, y))
                        t2g.remove();
                    if (s1g.ison(x, y))
                        s1g.remove();
                    if (s2g.ison(x, y))
                        s2g.remove();
                    if (l1g.ison(x, y))
                        l1g.remove();
                    if (l2g.ison(x, y))
                        l2g.remove();
                    if (damegruen.ison(x, y))
                        damegruen.remove();
                    if (koeniggruen.ison(x, y))
                    {
                        koeniggruen.remove();
                        Console.ForegroundColor = System.ConsoleColor.White;
                        MusicPlayer.SoundLocation = "victory.wav";
                        MusicPlayer.Play();
                        ausgeben("Rot hat gewonnen!");
                        gewonnen();
                        System.Windows.Forms.Application.Restart();
                    }
                }
            } //Erweitern
            void showfigures()
            {
                for (int y = 0; y < 8; ++y)
                    for (int x = 0; x < 8; ++x)
                        if (ar.ison(x, y) || br.ison(x, y) || cr.ison(x, y) || dr.ison(x, y) || er.ison(x, y) || fr.ison(x, y) || gr.ison(x, y) || hr.ison(x, y) || t1r.ison(x, y) || t2r.ison(x, y) || s1r.ison(x, y) || s2r.ison(x, y) || koenigrot.ison(x, y) || l1r.ison(x, y) || l2r.ison(x, y) || damerot.ison(x, y) || ersatzdame1.ison(x, y) || ersatzdame2.ison(x, y) || ersatzdame3.ison(x, y) || ersatzspringer1.ison(x, y) || ersatzspringer2.ison(x, y) || ersatzspringer3.ison(x, y) || ersatzlaeufer1.ison(x, y) || ersatzlaeufer2.ison(x, y) || ersatzlaeufer3.ison(x, y) || ersatzturm1.ison(x, y) || ersatzturm2.ison(x, y) || ersatzturm3.ison(x, y))
                        {
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Off);
                        }
                        else if (ag.ison(x, y) || bg.ison(x, y) || cg.ison(x, y) || dg.ison(x, y) || eg.ison(x, y) || fg.ison(x, y) || gg.ison(x, y) || hg.ison(x, y) || t1g.ison(x, y) || t2g.ison(x, y) || s1g.ison(x, y) || s2g.ison(x, y) || koeniggruen.ison(x, y) || l1g.ison(x, y) || l2g.ison(x, y) || damegruen.ison(x, y) || ersatzdame1g.ison(x, y) || ersatzdame2g.ison(x, y) || ersatzdame3g.ison(x, y) || ersatzspringer1g.ison(x, y) || ersatzspringer2g.ison(x, y) || ersatzspringer3g.ison(x, y) || ersatzlaeufer1g.ison(x, y) || ersatzlaeufer2g.ison(x, y) || ersatzlaeufer3g.ison(x, y) || ersatzturm1g.ison(x, y) || ersatzturm2g.ison(x, y) || ersatzturm3g.ison(x, y))
                        {
                            mLaunchpadDevice[x, y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Full);
                        }
            } //Natürlich auch erweitern
            void showfigureon(int x, int y)
            {
                if (ar.ison(x, y))
                    ausgeben2("Bauer1");
                if (br.ison(x, y))
                    ausgeben2("Bauer1");
                if (cr.ison(x, y))
                    ausgeben2("Bauer1");
                if (dr.ison(x, y))
                    ausgeben2("Bauer1");
                if (er.ison(x, y))
                    ausgeben2("Bauer1");
                if (fr.ison(x, y))
                    ausgeben2("Bauer1");
                if (gr.ison(x, y))
                    ausgeben2("Bauer1");
                if (hr.ison(x, y))
                    ausgeben2("Bauer1");
                if (t1r.ison(x, y))
                    ausgeben2("Turm1");
                if (t2r.ison(x, y))
                    ausgeben2("Turm1");
                if (s1r.ison(x, y))
                    ausgeben2("Springer1");
                if (s2r.ison(x, y))
                    ausgeben2("Springer1");
                if (l1r.ison(x, y))
                    ausgeben2("Läufer1");
                if (l2r.ison(x, y))
                    ausgeben2("Läufer1");
                if (koenigrot.ison(x, y))
                    ausgeben2("König1");
                if (damerot.ison(x, y))
                    ausgeben2("Dame1");
                if (ag.ison(x, y))
                    ausgeben2("Bauer2");
                if (bg.ison(x, y))
                    ausgeben2("Bauer2");
                if (cg.ison(x, y))
                    ausgeben2("Bauer2");
                if (dg.ison(x, y))
                    ausgeben2("Bauer2");
                if (eg.ison(x, y))
                    ausgeben2("Bauer2");
                if (fg.ison(x, y))
                    ausgeben2("Bauer2");
                if (gg.ison(x, y))
                    ausgeben2("Bauer2");
                if (hg.ison(x, y))
                    ausgeben2("Bauer2");
                if (t1g.ison(x, y))
                    ausgeben2("Turm2");
                if (t2g.ison(x, y))
                    ausgeben2("Turm2");
                if (s1g.ison(x, y))
                    ausgeben2("Springer2");
                if (s2g.ison(x, y))
                    ausgeben2("Springer2");
                if (l1g.ison(x, y))
                    ausgeben2("Läufer2");
                if (l2g.ison(x, y))
                    ausgeben2("Läufer2");
                if (koeniggruen.ison(x, y))
                    ausgeben2("König2");
                if (damegruen.ison(x, y))
                    ausgeben2("Dame2");

                //ERSATZ

                if (ersatzdame1.ison(x, y))
                    ausgeben2("Dame1");
                if (ersatzdame2.ison(x, y))
                    ausgeben2("Dame1");
                if (ersatzdame3.ison(x, y))
                    ausgeben2("Dame1");
                if (ersatzlaeufer1.ison(x, y))
                    ausgeben2("Läufer1");
                if (ersatzlaeufer2.ison(x, y))
                    ausgeben2("Läufer1");
                if (ersatzlaeufer3.ison(x, y))
                    ausgeben2("Läufer1");
                if (ersatzspringer1.ison(x, y))
                    ausgeben2("Springer1");
                if (ersatzspringer2.ison(x, y))
                    ausgeben2("Springer1");
                if (ersatzspringer3.ison(x, y))
                    ausgeben2("Springer1");
                if (ersatzturm1.ison(x, y))
                    ausgeben2("Turm1");
                if (ersatzturm2.ison(x, y))
                    ausgeben2("Turm1");
                if (ersatzturm3.ison(x, y))
                    ausgeben2("Turm1");


                if (ersatzdame1g.ison(x, y))
                    ausgeben2("Dame2");
                if (ersatzdame2g.ison(x, y))
                    ausgeben2("Dame2");
                if (ersatzdame3g.ison(x, y))
                    ausgeben2("Dame2");
                if (ersatzlaeufer1g.ison(x, y))
                    ausgeben2("Läufer2");
                if (ersatzlaeufer2g.ison(x, y))
                    ausgeben2("Läufer2");
                if (ersatzlaeufer3g.ison(x, y))
                    ausgeben2("Läufer2");
                if (ersatzspringer1g.ison(x, y))
                    ausgeben2("Springer2");
                if (ersatzspringer2g.ison(x, y))
                    ausgeben2("Springer2");
                if (ersatzspringer3g.ison(x, y))
                    ausgeben2("Springer2");
                if (ersatzturm1g.ison(x, y))
                    ausgeben2("Turm2");
                if (ersatzturm2g.ison(x, y))
                    ausgeben2("Turm2");
                if (ersatzturm3g.ison(x, y))
                    ausgeben2("Turm2");
            }

            Damerot ersatzdame1 = new Damerot(8, 8);
            Damerot ersatzdame2 = new Damerot(8, 8);
            Damerot ersatzdame3 = new Damerot(8, 8);
            Springerrot ersatzspringer1 = new Springerrot(8, 8);
            Springerrot ersatzspringer2 = new Springerrot(8, 8);
            Springerrot ersatzspringer3 = new Springerrot(8, 8);
            Turmrot ersatzturm1 = new Turmrot(8, 8);
            Turmrot ersatzturm2 = new Turmrot(8, 8);
            Turmrot ersatzturm3 = new Turmrot(8, 8);
            Laeuferrot ersatzlaeufer1 = new Laeuferrot(8, 8);
            Laeuferrot ersatzlaeufer2 = new Laeuferrot(8, 8);
            Laeuferrot ersatzlaeufer3 = new Laeuferrot(8, 8);

            Damegruen ersatzdame1g = new Damegruen(8, 8);
            Damegruen ersatzdame2g = new Damegruen(8, 8);
            Damegruen ersatzdame3g = new Damegruen(8, 8);
            Springergruen ersatzspringer1g = new Springergruen(8, 8);
            Springergruen ersatzspringer2g = new Springergruen(8, 8);
            Springergruen ersatzspringer3g = new Springergruen(8, 8);
            Turmgruen ersatzturm1g = new Turmgruen(8, 8);
            Turmgruen ersatzturm2g = new Turmgruen(8, 8);
            Turmgruen ersatzturm3g = new Turmgruen(8, 8);
            Laeufergruen ersatzlaeufer1g = new Laeufergruen(8, 8);
            Laeufergruen ersatzlaeufer2g = new Laeufergruen(8, 8);
            Laeufergruen ersatzlaeufer3g = new Laeufergruen(8, 8);

            public void bauermoveto(int x, int y, bool weiss = false)
            {
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                char spalte = feld[x];
                y = 8 - y;
                if (spalte == 'a')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            a1set("bauer.png");
                        else
                            a1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            a2set("bauer.png");
                        else
                            a2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            a3set("bauer.png");
                        else
                            a3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            a4set("bauer.png");
                        else
                            a4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            a5set("bauer.png");
                        else
                            a5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            a6set("bauer.png");
                        else
                            a6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            a7set("bauer.png");
                        else
                            a7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            a8set("bauer.png");
                        else
                            a8set("bauer2.png");
                    }
                }
                if (spalte == 'b')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            b1set("bauer.png");
                        else
                            b1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            b2set("bauer.png");
                        else
                            b2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            b3set("bauer.png");
                        else
                            b3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            b4set("bauer.png");
                        else
                            b4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            b5set("bauer.png");
                        else
                            b5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            b6set("bauer.png");
                        else
                            b6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            b7set("bauer.png");
                        else
                            b7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            b8set("bauer.png");
                        else
                            b8set("bauer2.png");
                    }
                }

                if (spalte == 'c')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            c1set("bauer.png");
                        else
                            c1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            c2set("bauer.png");
                        else
                            c2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            c3set("bauer.png");
                        else
                            c3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            c4set("bauer.png");
                        else
                            c4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            c5set("bauer.png");
                        else
                            c5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            c6set("bauer.png");
                        else
                            c6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            c7set("bauer.png");
                        else
                            c7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            c8set("bauer.png");
                        else
                            c8set("bauer2.png");
                    }
                }

                if (spalte == 'd')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            d1set("bauer.png");
                        else
                            d1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            d2set("bauer.png");
                        else
                            d2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            d3set("bauer.png");
                        else
                            d3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            d4set("bauer.png");
                        else
                            d4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            d5set("bauer.png");
                        else
                            d5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            d6set("bauer.png");
                        else
                            d6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            d7set("bauer.png");
                        else
                            d7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            d8set("bauer.png");
                        else
                            d8set("bauer2.png");
                    }
                }
                if (spalte == 'e')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            e1set("bauer.png");
                        else
                            e1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            e2set("bauer.png");
                        else
                            e2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            e3set("bauer.png");
                        else
                            e3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            e4set("bauer.png");
                        else
                            e4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            e5set("bauer.png");
                        else
                            e5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            e6set("bauer.png");
                        else
                            e6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            e7set("bauer.png");
                        else
                            e7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            e8set("bauer.png");
                        else
                            e8set("bauer2.png");
                    }
                }
                if (spalte == 'f')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            f1set("bauer.png");
                        else
                            f1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            f2set("bauer.png");
                        else
                            f2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            f3set("bauer.png");
                        else
                            f3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            f4set("bauer.png");
                        else
                            f4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            f5set("bauer.png");
                        else
                            f5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            f6set("bauer.png");
                        else
                            f6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            f7set("bauer.png");
                        else
                            f7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            f8set("bauer.png");
                        else
                            f8set("bauer2.png");
                    }
                }
                if (spalte == 'g')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            g1set("bauer.png");
                        else
                            g1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            g2set("bauer.png");
                        else
                            g2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            g3set("bauer.png");
                        else
                            g3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            g4set("bauer.png");
                        else
                            g4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            g5set("bauer.png");
                        else
                            g5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            g6set("bauer.png");
                        else
                            g6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            g7set("bauer.png");
                        else
                            g7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            g8set("bauer.png");
                        else
                            g8set("bauer2.png");
                    }
                }
                if (spalte == 'h')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            h1set("bauer.png");
                        else
                            h1set("bauer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            h2set("bauer.png");
                        else
                            h2set("bauer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            h3set("bauer.png");
                        else
                            h3set("bauer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            h4set("bauer.png");
                        else
                            h4set("bauer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            h5set("bauer.png");
                        else
                            h5set("bauer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            h6set("bauer.png");
                        else
                            h6set("bauer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            h7set("bauer.png");
                        else
                            h7set("bauer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            h8set("bauer.png");
                        else
                            h8set("bauer2.png");
                    }
                }


            }
            public void turmmoveto(int x, int y, bool weiss = false)
            {
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                char spalte = feld[x];
                y = 8 - y;
                if (spalte == 'a')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            a1set("turm.png");
                        else
                            a1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            a2set("turm.png");
                        else
                            a2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            a3set("turm.png");
                        else
                            a3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            a4set("turm.png");
                        else
                            a4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            a5set("turm.png");
                        else
                            a5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            a6set("turm.png");
                        else
                            a6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            a7set("turm.png");
                        else
                            a7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            a8set("turm.png");
                        else
                            a8set("turm2.png");
                    }
                }
                if (spalte == 'b')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            b1set("turm.png");
                        else
                            b1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            b2set("turm.png");
                        else
                            b2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            b3set("turm.png");
                        else
                            b3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            b4set("turm.png");
                        else
                            b4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            b5set("turm.png");
                        else
                            b5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            b6set("turm.png");
                        else
                            b6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            b7set("turm.png");
                        else
                            b7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            b8set("turm.png");
                        else
                            b8set("turm2.png");
                    }
                }

                if (spalte == 'c')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            c1set("turm.png");
                        else
                            c1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            c2set("turm.png");
                        else
                            c2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            c3set("turm.png");
                        else
                            c3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            c4set("turm.png");
                        else
                            c4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            c5set("turm.png");
                        else
                            c5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            c6set("turm.png");
                        else
                            c6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            c7set("turm.png");
                        else
                            c7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            c8set("turm.png");
                        else
                            c8set("turm2.png");
                    }
                }

                if (spalte == 'd')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            d1set("turm.png");
                        else
                            d1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            d2set("turm.png");
                        else
                            d2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            d3set("turm.png");
                        else
                            d3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            d4set("turm.png");
                        else
                            d4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            d5set("turm.png");
                        else
                            d5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            d6set("turm.png");
                        else
                            d6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            d7set("turm.png");
                        else
                            d7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            d8set("turm.png");
                        else
                            d8set("turm2.png");
                    }
                }
                if (spalte == 'e')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            e1set("turm.png");
                        else
                            e1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            e2set("turm.png");
                        else
                            e2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            e3set("turm.png");
                        else
                            e3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            e4set("turm.png");
                        else
                            e4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            e5set("turm.png");
                        else
                            e5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            e6set("turm.png");
                        else
                            e6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            e7set("turm.png");
                        else
                            e7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            e8set("turm.png");
                        else
                            e8set("turm2.png");
                    }
                }
                if (spalte == 'f')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            f1set("turm.png");
                        else
                            f1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            f2set("turm.png");
                        else
                            f2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            f3set("turm.png");
                        else
                            f3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            f4set("turm.png");
                        else
                            f4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            f5set("turm.png");
                        else
                            f5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            f6set("turm.png");
                        else
                            f6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            f7set("turm.png");
                        else
                            f7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            f8set("turm.png");
                        else
                            f8set("turm2.png");
                    }
                }
                if (spalte == 'g')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            g1set("turm.png");
                        else
                            g1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            g2set("turm.png");
                        else
                            g2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            g3set("turm.png");
                        else
                            g3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            g4set("turm.png");
                        else
                            g4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            g5set("turm.png");
                        else
                            g5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            g6set("turm.png");
                        else
                            g6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            g7set("turm.png");
                        else
                            g7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            g8set("turm.png");
                        else
                            g8set("turm2.png");
                    }
                }
                if (spalte == 'h')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            h1set("turm.png");
                        else
                            h1set("turm2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            h2set("turm.png");
                        else
                            h2set("turm2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            h3set("turm.png");
                        else
                            h3set("turm2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            h4set("turm.png");
                        else
                            h4set("turm2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            h5set("turm.png");
                        else
                            h5set("turm2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            h6set("turm.png");
                        else
                            h6set("turm2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            h7set("turm.png");
                        else
                            h7set("turm2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            h8set("turm.png");
                        else
                            h8set("turm2.png");
                    }
                }


            }
            public void springermoveto(int x, int y, bool weiss = false)
            {
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                char spalte = feld[x];
                y = 8 - y;
                if (spalte == 'a')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            a1set("springer.png");
                        else
                            a1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            a2set("springer.png");
                        else
                            a2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            a3set("springer.png");
                        else
                            a3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            a4set("springer.png");
                        else
                            a4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            a5set("springer.png");
                        else
                            a5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            a6set("springer.png");
                        else
                            a6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            a7set("springer.png");
                        else
                            a7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            a8set("springer.png");
                        else
                            a8set("springer2.png");
                    }
                }
                if (spalte == 'b')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            b1set("springer.png");
                        else
                            b1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            b2set("springer.png");
                        else
                            b2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            b3set("springer.png");
                        else
                            b3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            b4set("springer.png");
                        else
                            b4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            b5set("springer.png");
                        else
                            b5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            b6set("springer.png");
                        else
                            b6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            b7set("springer.png");
                        else
                            b7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            b8set("springer.png");
                        else
                            b8set("springer2.png");
                    }
                }

                if (spalte == 'c')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            c1set("springer.png");
                        else
                            c1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            c2set("springer.png");
                        else
                            c2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            c3set("springer.png");
                        else
                            c3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            c4set("springer.png");
                        else
                            c4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            c5set("springer.png");
                        else
                            c5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            c6set("springer.png");
                        else
                            c6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            c7set("springer.png");
                        else
                            c7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            c8set("springer.png");
                        else
                            c8set("springer2.png");
                    }
                }

                if (spalte == 'd')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            d1set("springer.png");
                        else
                            d1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            d2set("springer.png");
                        else
                            d2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            d3set("springer.png");
                        else
                            d3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            d4set("springer.png");
                        else
                            d4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            d5set("springer.png");
                        else
                            d5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            d6set("springer.png");
                        else
                            d6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            d7set("springer.png");
                        else
                            d7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            d8set("springer.png");
                        else
                            d8set("springer2.png");
                    }
                }
                if (spalte == 'e')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            e1set("springer.png");
                        else
                            e1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            e2set("springer.png");
                        else
                            e2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            e3set("springer.png");
                        else
                            e3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            e4set("springer.png");
                        else
                            e4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            e5set("springer.png");
                        else
                            e5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            e6set("springer.png");
                        else
                            e6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            e7set("springer.png");
                        else
                            e7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            e8set("springer.png");
                        else
                            e8set("springer2.png");
                    }
                }
                if (spalte == 'f')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            f1set("springer.png");
                        else
                            f1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            f2set("springer.png");
                        else
                            f2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            f3set("springer.png");
                        else
                            f3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            f4set("springer.png");
                        else
                            f4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            f5set("springer.png");
                        else
                            f5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            f6set("springer.png");
                        else
                            f6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            f7set("springer.png");
                        else
                            f7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            f8set("springer.png");
                        else
                            f8set("springer2.png");
                    }
                }
                if (spalte == 'g')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            g1set("springer.png");
                        else
                            g1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            g2set("springer.png");
                        else
                            g2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            g3set("springer.png");
                        else
                            g3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            g4set("springer.png");
                        else
                            g4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            g5set("springer.png");
                        else
                            g5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            g6set("springer.png");
                        else
                            g6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            g7set("springer.png");
                        else
                            g7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            g8set("springer.png");
                        else
                            g8set("springer2.png");
                    }
                }
                if (spalte == 'h')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            h1set("springer.png");
                        else
                            h1set("springer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            h2set("springer.png");
                        else
                            h2set("springer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            h3set("springer.png");
                        else
                            h3set("springer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            h4set("springer.png");
                        else
                            h4set("springer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            h5set("springer.png");
                        else
                            h5set("springer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            h6set("springer.png");
                        else
                            h6set("springer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            h7set("springer.png");
                        else
                            h7set("springer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            h8set("springer.png");
                        else
                            h8set("springer2.png");
                    }
                }


            }
            public void laeufermoveto(int x, int y, bool weiss = false)
            {
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                char spalte = feld[x];
                y = 8 - y;
                if (spalte == 'a')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            a1set("laeufer.png");
                        else
                            a1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            a2set("laeufer.png");
                        else
                            a2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            a3set("laeufer.png");
                        else
                            a3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            a4set("laeufer.png");
                        else
                            a4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            a5set("laeufer.png");
                        else
                            a5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            a6set("laeufer.png");
                        else
                            a6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            a7set("laeufer.png");
                        else
                            a7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            a8set("laeufer.png");
                        else
                            a8set("laeufer2.png");
                    }
                }
                if (spalte == 'b')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            b1set("laeufer.png");
                        else
                            b1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            b2set("laeufer.png");
                        else
                            b2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            b3set("laeufer.png");
                        else
                            b3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            b4set("laeufer.png");
                        else
                            b4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            b5set("laeufer.png");
                        else
                            b5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            b6set("laeufer.png");
                        else
                            b6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            b7set("laeufer.png");
                        else
                            b7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            b8set("laeufer.png");
                        else
                            b8set("laeufer2.png");
                    }
                }

                if (spalte == 'c')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            c1set("laeufer.png");
                        else
                            c1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            c2set("laeufer.png");
                        else
                            c2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            c3set("laeufer.png");
                        else
                            c3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            c4set("laeufer.png");
                        else
                            c4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            c5set("laeufer.png");
                        else
                            c5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            c6set("laeufer.png");
                        else
                            c6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            c7set("laeufer.png");
                        else
                            c7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            c8set("laeufer.png");
                        else
                            c8set("laeufer2.png");
                    }
                }

                if (spalte == 'd')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            d1set("laeufer.png");
                        else
                            d1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            d2set("laeufer.png");
                        else
                            d2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            d3set("laeufer.png");
                        else
                            d3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            d4set("laeufer.png");
                        else
                            d4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            d5set("laeufer.png");
                        else
                            d5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            d6set("laeufer.png");
                        else
                            d6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            d7set("laeufer.png");
                        else
                            d7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            d8set("laeufer.png");
                        else
                            d8set("laeufer2.png");
                    }
                }
                if (spalte == 'e')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            e1set("laeufer.png");
                        else
                            e1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            e2set("laeufer.png");
                        else
                            e2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            e3set("laeufer.png");
                        else
                            e3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            e4set("laeufer.png");
                        else
                            e4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            e5set("laeufer.png");
                        else
                            e5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            e6set("laeufer.png");
                        else
                            e6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            e7set("laeufer.png");
                        else
                            e7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            e8set("laeufer.png");
                        else
                            e8set("laeufer2.png");
                    }
                }
                if (spalte == 'f')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            f1set("laeufer.png");
                        else
                            f1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            f2set("laeufer.png");
                        else
                            f2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            f3set("laeufer.png");
                        else
                            f3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            f4set("laeufer.png");
                        else
                            f4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            f5set("laeufer.png");
                        else
                            f5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            f6set("laeufer.png");
                        else
                            f6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            f7set("laeufer.png");
                        else
                            f7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            f8set("laeufer.png");
                        else
                            f8set("laeufer2.png");
                    }
                }
                if (spalte == 'g')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            g1set("laeufer.png");
                        else
                            g1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            g2set("laeufer.png");
                        else
                            g2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            g3set("laeufer.png");
                        else
                            g3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            g4set("laeufer.png");
                        else
                            g4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            g5set("laeufer.png");
                        else
                            g5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            g6set("laeufer.png");
                        else
                            g6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            g7set("laeufer.png");
                        else
                            g7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            g8set("laeufer.png");
                        else
                            g8set("laeufer2.png");
                    }
                }
                if (spalte == 'h')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            h1set("laeufer.png");
                        else
                            h1set("laeufer2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            h2set("laeufer.png");
                        else
                            h2set("laeufer2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            h3set("laeufer.png");
                        else
                            h3set("laeufer2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            h4set("laeufer.png");
                        else
                            h4set("laeufer2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            h5set("laeufer.png");
                        else
                            h5set("laeufer2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            h6set("laeufer.png");
                        else
                            h6set("laeufer2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            h7set("laeufer.png");
                        else
                            h7set("laeufer2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            h8set("laeufer.png");
                        else
                            h8set("laeufer2.png");
                    }
                }


            }
            public void damemoveto(int x, int y, bool weiss = false)
            {
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                char spalte = feld[x];
                y = 8 - y;
                if (spalte == 'a')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            a1set("dame.png");
                        else
                            a1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            a2set("dame.png");
                        else
                            a2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            a3set("dame.png");
                        else
                            a3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            a4set("dame.png");
                        else
                            a4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            a5set("dame.png");
                        else
                            a5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            a6set("dame.png");
                        else
                            a6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            a7set("dame.png");
                        else
                            a7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            a8set("dame.png");
                        else
                            a8set("dame2.png");
                    }
                }
                if (spalte == 'b')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            b1set("dame.png");
                        else
                            b1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            b2set("dame.png");
                        else
                            b2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            b3set("dame.png");
                        else
                            b3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            b4set("dame.png");
                        else
                            b4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            b5set("dame.png");
                        else
                            b5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            b6set("dame.png");
                        else
                            b6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            b7set("dame.png");
                        else
                            b7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            b8set("dame.png");
                        else
                            b8set("dame2.png");
                    }
                }

                if (spalte == 'c')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            c1set("dame.png");
                        else
                            c1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            c2set("dame.png");
                        else
                            c2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            c3set("dame.png");
                        else
                            c3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            c4set("dame.png");
                        else
                            c4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            c5set("dame.png");
                        else
                            c5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            c6set("dame.png");
                        else
                            c6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            c7set("dame.png");
                        else
                            c7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            c8set("dame.png");
                        else
                            c8set("dame2.png");
                    }
                }

                if (spalte == 'd')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            d1set("dame.png");
                        else
                            d1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            d2set("dame.png");
                        else
                            d2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            d3set("dame.png");
                        else
                            d3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            d4set("dame.png");
                        else
                            d4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            d5set("dame.png");
                        else
                            d5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            d6set("dame.png");
                        else
                            d6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            d7set("dame.png");
                        else
                            d7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            d8set("dame.png");
                        else
                            d8set("dame2.png");
                    }
                }
                if (spalte == 'e')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            e1set("dame.png");
                        else
                            e1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            e2set("dame.png");
                        else
                            e2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            e3set("dame.png");
                        else
                            e3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            e4set("dame.png");
                        else
                            e4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            e5set("dame.png");
                        else
                            e5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            e6set("dame.png");
                        else
                            e6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            e7set("dame.png");
                        else
                            e7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            e8set("dame.png");
                        else
                            e8set("dame2.png");
                    }
                }
                if (spalte == 'f')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            f1set("dame.png");
                        else
                            f1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            f2set("dame.png");
                        else
                            f2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            f3set("dame.png");
                        else
                            f3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            f4set("dame.png");
                        else
                            f4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            f5set("dame.png");
                        else
                            f5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            f6set("dame.png");
                        else
                            f6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            f7set("dame.png");
                        else
                            f7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            f8set("dame.png");
                        else
                            f8set("dame2.png");
                    }
                }
                if (spalte == 'g')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            g1set("dame.png");
                        else
                            g1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            g2set("dame.png");
                        else
                            g2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            g3set("dame.png");
                        else
                            g3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            g4set("dame.png");
                        else
                            g4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            g5set("dame.png");
                        else
                            g5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            g6set("dame.png");
                        else
                            g6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            g7set("dame.png");
                        else
                            g7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            g8set("dame.png");
                        else
                            g8set("dame2.png");
                    }
                }
                if (spalte == 'h')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            h1set("dame.png");
                        else
                            h1set("dame2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            h2set("dame.png");
                        else
                            h2set("dame2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            h3set("dame.png");
                        else
                            h3set("dame2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            h4set("dame.png");
                        else
                            h4set("dame2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            h5set("dame.png");
                        else
                            h5set("dame2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            h6set("dame.png");
                        else
                            h6set("dame2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            h7set("dame.png");
                        else
                            h7set("dame2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            h8set("dame.png");
                        else
                            h8set("dame2.png");
                    }
                }


            }
            public void koenigmoveto(int x, int y, bool weiss = false)
            {
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                char spalte = feld[x];
                y = 8 - y;
                if (spalte == 'a')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            a1set("koenig.png");
                        else
                            a1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            a2set("koenig.png");
                        else
                            a2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            a3set("koenig.png");
                        else
                            a3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            a4set("koenig.png");
                        else
                            a4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            a5set("koenig.png");
                        else
                            a5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            a6set("koenig.png");
                        else
                            a6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            a7set("koenig.png");
                        else
                            a7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            a8set("koenig.png");
                        else
                            a8set("koenig2.png");
                    }
                }
                if (spalte == 'b')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            b1set("koenig.png");
                        else
                            b1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            b2set("koenig.png");
                        else
                            b2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            b3set("koenig.png");
                        else
                            b3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            b4set("koenig.png");
                        else
                            b4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            b5set("koenig.png");
                        else
                            b5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            b6set("koenig.png");
                        else
                            b6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            b7set("koenig.png");
                        else
                            b7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            b8set("koenig.png");
                        else
                            b8set("koenig2.png");
                    }
                }

                if (spalte == 'c')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            c1set("koenig.png");
                        else
                            c1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            c2set("koenig.png");
                        else
                            c2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            c3set("koenig.png");
                        else
                            c3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            c4set("koenig.png");
                        else
                            c4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            c5set("koenig.png");
                        else
                            c5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            c6set("koenig.png");
                        else
                            c6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            c7set("koenig.png");
                        else
                            c7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            c8set("koenig.png");
                        else
                            c8set("koenig2.png");
                    }
                }

                if (spalte == 'd')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            d1set("koenig.png");
                        else
                            d1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            d2set("koenig.png");
                        else
                            d2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            d3set("koenig.png");
                        else
                            d3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            d4set("koenig.png");
                        else
                            d4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            d5set("koenig.png");
                        else
                            d5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            d6set("koenig.png");
                        else
                            d6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            d7set("koenig.png");
                        else
                            d7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            d8set("koenig.png");
                        else
                            d8set("koenig2.png");
                    }
                }
                if (spalte == 'e')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            e1set("koenig.png");
                        else
                            e1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            e2set("koenig.png");
                        else
                            e2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            e3set("koenig.png");
                        else
                            e3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            e4set("koenig.png");
                        else
                            e4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            e5set("koenig.png");
                        else
                            e5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            e6set("koenig.png");
                        else
                            e6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            e7set("koenig.png");
                        else
                            e7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            e8set("koenig.png");
                        else
                            e8set("koenig2.png");
                    }
                }
                if (spalte == 'f')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            f1set("koenig.png");
                        else
                            f1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            f2set("koenig.png");
                        else
                            f2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            f3set("koenig.png");
                        else
                            f3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            f4set("koenig.png");
                        else
                            f4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            f5set("koenig.png");
                        else
                            f5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            f6set("koenig.png");
                        else
                            f6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            f7set("koenig.png");
                        else
                            f7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            f8set("koenig.png");
                        else
                            f8set("koenig2.png");
                    }
                }
                if (spalte == 'g')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            g1set("koenig.png");
                        else
                            g1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            g2set("koenig.png");
                        else
                            g2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            g3set("koenig.png");
                        else
                            g3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            g4set("koenig.png");
                        else
                            g4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            g5set("koenig.png");
                        else
                            g5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            g6set("koenig.png");
                        else
                            g6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            g7set("koenig.png");
                        else
                            g7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            g8set("koenig.png");
                        else
                            g8set("koenig2.png");
                    }
                }
                if (spalte == 'h')
                {
                    if (y == 1)
                    {
                        if (weiss == true)
                            h1set("koenig.png");
                        else
                            h1set("koenig2.png");
                    }
                    if (y == 2)
                    {
                        if (weiss == true)
                            h2set("koenig.png");
                        else
                            h2set("koenig2.png");
                    }
                    if (y == 3)
                    {
                        if (weiss == true)
                            h3set("koenig.png");
                        else
                            h3set("koenig2.png");
                    }
                    if (y == 4)
                    {
                        if (weiss == true)
                            h4set("koenig.png");
                        else
                            h4set("koenig2.png");
                    }
                    if (y == 5)
                    {
                        if (weiss == true)
                            h5set("koenig.png");
                        else
                            h5set("koenig2.png");
                    }
                    if (y == 6)
                    {
                        if (weiss == true)
                            h6set("koenig.png");
                        else
                            h6set("koenig2.png");
                    }
                    if (y == 7)
                    {
                        if (weiss == true)
                            h7set("koenig.png");
                        else
                            h7set("koenig2.png");
                    }
                    if (y == 8)
                    {
                        if (weiss == true)
                            h8set("koenig.png");
                        else
                            h8set("koenig2.png");
                    }
                }


            }

            void checkfield()
            {
                a1set("empty.png");
                a2set("empty.png");
                a3set("empty.png");
                a4set("empty.png");
                a5set("empty.png");
                a6set("empty.png");
                a7set("empty.png");
                a8set("empty.png");

                b1set("empty.png");
                b2set("empty.png");
                b3set("empty.png");
                b4set("empty.png");
                b5set("empty.png");
                b6set("empty.png");
                b7set("empty.png");
                b8set("empty.png");

                c1set("empty.png");
                c2set("empty.png");
                c3set("empty.png");
                c4set("empty.png");
                c5set("empty.png");
                c6set("empty.png");
                c7set("empty.png");
                c8set("empty.png");

                d1set("empty.png");
                d2set("empty.png");
                d3set("empty.png");
                d4set("empty.png");
                d5set("empty.png");
                d6set("empty.png");
                d7set("empty.png");
                d8set("empty.png");

                e1set("empty.png");
                e2set("empty.png");
                e3set("empty.png");
                e4set("empty.png");
                e5set("empty.png");
                e6set("empty.png");
                e7set("empty.png");
                e8set("empty.png");

                f1set("empty.png");
                f2set("empty.png");
                f3set("empty.png");
                f4set("empty.png");
                f5set("empty.png");
                f6set("empty.png");
                f7set("empty.png");
                f8set("empty.png");

                g1set("empty.png");
                g2set("empty.png");
                g3set("empty.png");
                g4set("empty.png");
                g5set("empty.png");
                g6set("empty.png");
                g7set("empty.png");
                g8set("empty.png");

                h1set("empty.png");
                h2set("empty.png");
                h3set("empty.png");
                h4set("empty.png");
                h5set("empty.png");
                h6set("empty.png");
                h7set("empty.png");
                h8set("empty.png");
                for (int y = 0; y < 8; ++y)
                    for (int x = 0; x < 8; ++x)
                        if (ar.ison(x, y) || br.ison(x, y) || cr.ison(x, y) || dr.ison(x, y) || er.ison(x, y) || fr.ison(x, y) || gr.ison(x, y) || hr.ison(x, y) || t1r.ison(x, y) || t2r.ison(x, y) || s1r.ison(x, y) || s2r.ison(x, y) || koenigrot.ison(x, y) || l1r.ison(x, y) || l2r.ison(x, y) || damerot.ison(x, y) || ag.ison(x, y) || bg.ison(x, y) || cg.ison(x, y) || dg.ison(x, y) || eg.ison(x, y) || fg.ison(x, y) || gg.ison(x, y) || hg.ison(x, y) || t1g.ison(x, y) || t2g.ison(x, y) || s1g.ison(x, y) || s2g.ison(x, y) || koeniggruen.ison(x, y) || l1g.ison(x, y) || l2g.ison(x, y) || damegruen.ison(x, y) || ersatzdame1.ison(x, y) || ersatzdame2.ison(x, y) || ersatzdame3.ison(x, y) || ersatzspringer1.ison(x, y) || ersatzspringer2.ison(x, y) || ersatzspringer3.ison(x, y) || ersatzlaeufer1.ison(x, y) || ersatzlaeufer2.ison(x, y) || ersatzlaeufer3.ison(x, y) || ersatzturm1.ison(x, y) || ersatzturm2.ison(x, y) || ersatzturm3.ison(x, y) || ersatzdame1g.ison(x, y) || ersatzdame2g.ison(x, y) || ersatzdame3g.ison(x, y) || ersatzspringer1g.ison(x, y) || ersatzspringer2g.ison(x, y) || ersatzspringer3g.ison(x, y) || ersatzlaeufer1g.ison(x, y) || ersatzlaeufer2g.ison(x, y) || ersatzlaeufer3g.ison(x, y) || ersatzturm1g.ison(x, y) || ersatzturm2g.ison(x, y) || ersatzturm3g.ison(x, y))
                        {
                            if (ar.ison(x, y))
                                bauermoveto(x, y, true);
                            if (br.ison(x, y))
                                bauermoveto(x, y, true);
                            if (cr.ison(x, y))
                                bauermoveto(x, y, true);
                            if (dr.ison(x, y))
                                bauermoveto(x, y, true);
                            if (er.ison(x, y))
                                bauermoveto(x, y, true);
                            if (fr.ison(x, y))
                                bauermoveto(x, y, true);
                            if (gr.ison(x, y))
                                bauermoveto(x, y, true);
                            if (hr.ison(x, y))
                                bauermoveto(x, y, true);
                            if (t1r.ison(x, y))
                                turmmoveto(x, y, true);
                            if (t2r.ison(x, y))
                                turmmoveto(x, y, true);
                            if (s1r.ison(x, y))
                                springermoveto(x, y, true);
                            if (s2r.ison(x, y))
                                springermoveto(x, y, true);
                            if (l1r.ison(x, y))
                                laeufermoveto(x, y, true);
                            if (l2r.ison(x, y))
                                laeufermoveto(x, y, true);
                            if (koenigrot.ison(x, y))
                                koenigmoveto(x, y, true);
                            if (damerot.ison(x, y))
                                damemoveto(x, y, true);
                            if (ag.ison(x, y))
                                bauermoveto(x, y, false);
                            if (bg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (cg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (dg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (eg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (fg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (gg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (hg.ison(x, y))
                                bauermoveto(x, y, false);
                            if (t1g.ison(x, y))
                                turmmoveto(x, y, false);
                            if (t2g.ison(x, y))
                                turmmoveto(x, y, false);
                            if (s1g.ison(x, y))
                                springermoveto(x, y, false);
                            if (s2g.ison(x, y))
                                springermoveto(x, y, false);
                            if (l1g.ison(x, y))
                                laeufermoveto(x, y, false);
                            if (l2g.ison(x, y))
                                laeufermoveto(x, y, false);
                            if (koeniggruen.ison(x, y))
                                koenigmoveto(x, y, false);
                            if (damegruen.ison(x, y))
                                damemoveto(x, y, false);

                            //ERSATZ

                            if (ersatzdame1.ison(x, y))
                                damemoveto(x, y, true);
                            if (ersatzdame2.ison(x, y))
                                damemoveto(x, y, true);
                            if (ersatzdame3.ison(x, y))
                                damemoveto(x, y, true);
                            if (ersatzlaeufer1.ison(x, y))
                                laeufermoveto(x, y, true);
                            if (ersatzlaeufer2.ison(x, y))
                                laeufermoveto(x, y, true);
                            if (ersatzlaeufer3.ison(x, y))
                                laeufermoveto(x, y, true);
                            if (ersatzspringer1.ison(x, y))
                                springermoveto(x, y, true);
                            if (ersatzspringer2.ison(x, y))
                                springermoveto(x, y, true);
                            if (ersatzspringer3.ison(x, y))
                                springermoveto(x, y, true);
                            if (ersatzturm1.ison(x, y))
                                turmmoveto(x, y, true);
                            if (ersatzturm2.ison(x, y))
                                turmmoveto(x, y, true);
                            if (ersatzturm3.ison(x, y))
                                turmmoveto(x, y, true);


                            if (ersatzdame1g.ison(x, y))
                                damemoveto(x, y, false);
                            if (ersatzdame2g.ison(x, y))
                                damemoveto(x, y, false);
                            if (ersatzdame3g.ison(x, y))
                                damemoveto(x, y, false);
                            if (ersatzlaeufer1g.ison(x, y))
                                laeufermoveto(x, y, false);
                            if (ersatzlaeufer2g.ison(x, y))
                                laeufermoveto(x, y, false);
                            if (ersatzlaeufer3g.ison(x, y))
                                laeufermoveto(x, y, false);
                            if (ersatzspringer1g.ison(x, y))
                                springermoveto(x, y, false);
                            if (ersatzspringer2g.ison(x, y))
                                springermoveto(x, y, false);
                            if (ersatzspringer3g.ison(x, y))
                                springermoveto(x, y, false);
                            if (ersatzturm1g.ison(x, y))
                                turmmoveto(x, y, false);
                            if (ersatzturm2g.ison(x, y))
                                turmmoveto(x, y, false);
                            if (ersatzturm3g.ison(x, y))
                                turmmoveto(x, y, false);

                        }
            }

            private void mLaunchpadDevice_ButtonPressed(object sender, ButtonPressEventArgs e)
            {
                if (e.Type == ButtonType.Toolbar)
                {
                    if (e.ToolbarButton == ToolbarButton.User1)
                    {
                        if (zug == 2)
                        {
                            zug = 1;
                            spieleranzeige();
                            showboard();
                        }
                    }
                    if (e.ToolbarButton == ToolbarButton.User2)
                    {
                        if (zug == 1)
                        {
                            zug = 2;
                            spieleranzeige();
                            showboard();
                        }
                    }
                    if (e.ToolbarButton == ToolbarButton.Mixer)
                    {
                        launchpadaus(mLaunchpadDevice);
                        if (mixer == false)
                        {
                            showfigures();
                            mixer = true;
                        }
                        else
                        {
                            mixer = false;
                            showboard();
                        }
                    }
                }


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




                if (e.Type == ButtonType.Grid)
                {
                    LaunchpadButton button = mLaunchpadDevice[e.X, e.Y];

                    checkfield();

                    //WENN AUSWAHL RÜCKGÄNGIG GEMACHT WERDEN SOLL
                    if ((button.RedBrightness == ButtonBrightness.Medium && button.GreenBrightness == ButtonBrightness.Off) || (button.RedBrightness == ButtonBrightness.Off && button.GreenBrightness == ButtonBrightness.Medium))
                    {
                        baueristdran = false;
                        springeristdran = false;
                        koenigistdran = false;
                        laeuferistdran = false;
                        dameistdran = false;
                        turmistdran = false;
                        pboxchange("lpchesslogo.png");
                        ausgeben2("");
                        showboard();
                        return;
                    }

                    if ((button.RedBrightness == ButtonBrightness.Medium && button.GreenBrightness == ButtonBrightness.Medium)) //ROCHADE
                    {
                        if (zug == 1)
                        {
                            if (e.X == 2 && e.Y == 7)
                            {
                                koenigistdran = false;
                                zugsound();
                                ausgeben("Rochade!");
                                ausgeben(koenigrot.moveto(e.X, e.Y));
                                ausgeben(t1r.moveto(e.X + 1, e.Y));

                                rochaderotgross = false;
                                rochaderotklein = false;

                                zug = 2;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                            else if (e.X == 6 && e.Y == 7)
                            {
                                koenigistdran = false;
                                zugsound();
                                ausgeben("Rochade!");
                                ausgeben(koenigrot.moveto(e.X, e.Y));
                                ausgeben(t2r.moveto(e.X - 1, e.Y));

                                rochaderotgross = false;
                                rochaderotklein = false;

                                zug = 2;
                                showboard();
                                spieleranzeige();
                                return;
                            }
                        }
                        else if (zug == 2)
                        {
                            if (e.X == 2 && e.Y == 0)
                            {
                                koenigistdran = false;
                                zugsound();
                                ausgeben("Rochade!");
                                ausgeben(koeniggruen.moveto(e.X, e.Y));
                                ausgeben(t1g.moveto(e.X + 1, e.Y));

                                rochadegruengross = false;
                                rochadegruenklein = false;

                                zug = 1;
                                showboard();
                                spieleranzeige();
                                return;
                            }
                            else if (e.X == 6 && e.Y == 0)
                            {
                                koenigistdran = false;
                                zugsound();
                                ausgeben("Rochade!");
                                ausgeben(koeniggruen.moveto(e.X, e.Y));
                                ausgeben(t2g.moveto(e.X - 1, e.Y));

                                rochadegruengross = false;
                                rochadegruenklein = false;

                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }
                    }

                    //WENN ZUG MÖGLICH IST...
                    else if (button.RedBrightness == ButtonBrightness.Full && button.GreenBrightness == ButtonBrightness.Full)
                    {
                        //BAUER DARF ZIEHEN?..
                        if (baueristdran == true)
                        {
                            if (zug == 1)
                            {
                                baueristdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                if (e.Y == 0) //Bauer auf Gegnerischer Seite
                                {
                                    rotverwandelt++;
                                    if (rotverwandelt < 4)
                                    while (true)
                                    {
                                        DialogResult damenwahl = MessageBox.Show("Wollen Sie eine Dame?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (damenwahl == DialogResult.Yes)
                                        {
                                            if (rotverwandelt == 1)
                                            { ersatzdame1 = new Damerot(); ersatzdame1.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 2)
                                            { ersatzdame2 = new Damerot(); ersatzdame2.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 3)
                                            { ersatzdame3 = new Damerot(); ersatzdame3.moveto(e.X, e.Y); break; }
                                        }
                                        DialogResult turmwahl = MessageBox.Show("Wollen Sie einen Turm?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (turmwahl == DialogResult.Yes)
                                        {
                                            if (rotverwandelt == 1)
                                            { ersatzturm1 = new Turmrot(); ersatzturm1.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 2)
                                            { ersatzturm2 = new Turmrot(); ersatzturm2.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 3)
                                            { ersatzturm3 = new Turmrot(); ersatzturm3.moveto(e.X, e.Y); break; }
                                        }
                                        DialogResult springerwahl = MessageBox.Show("Wollen Sie einen Springer?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (springerwahl == DialogResult.Yes)
                                        {
                                            if (rotverwandelt == 1)
                                            { ersatzspringer1 = new Springerrot(); ersatzspringer1.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 2)
                                            { ersatzspringer2 = new Springerrot(); ersatzspringer2.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 3)
                                            { ersatzspringer3 = new Springerrot(); ersatzspringer3.moveto(e.X, e.Y); break; }
                                        }
                                        DialogResult laeuferwahl = MessageBox.Show("Wollen Sie einen Läufer?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (laeuferwahl == DialogResult.Yes)
                                        {
                                            if (rotverwandelt == 1)
                                            { ersatzlaeufer1 = new Laeuferrot(); ersatzlaeufer1.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 2) { ersatzlaeufer2 = new Laeuferrot(); ersatzlaeufer2.moveto(e.X, e.Y); break; }
                                            if (rotverwandelt == 3) { ersatzlaeufer3 = new Laeuferrot(); ersatzlaeufer3.moveto(e.X, e.Y); break; }
                                        }
                                    }
                                    switch (bauer)
                                    {
                                        case 0: ar.remove(); break;
                                        case 1: br.remove(); break;
                                        case 2: cr.remove(); break;
                                        case 3: dr.remove(); break;
                                        case 4: er.remove(); break;
                                        case 5: fr.remove(); break;
                                        case 6: gr.remove(); break;
                                        case 7: hr.remove(); break;
                                        default: break;
                                    }
                                    ausgeben("Bauer verwandelt.");
                                }
                                else
                                    switch (bauer)
                                    {
                                        case 0: ausgeben(ar.moveto(e.X, e.Y)); break;
                                        case 1: ausgeben(br.moveto(e.X, e.Y)); break;
                                        case 2: ausgeben(cr.moveto(e.X, e.Y)); break;
                                        case 3: ausgeben(dr.moveto(e.X, e.Y)); break;
                                        case 4: ausgeben(er.moveto(e.X, e.Y)); break;
                                        case 5: ausgeben(fr.moveto(e.X, e.Y)); break;
                                        case 6: ausgeben(gr.moveto(e.X, e.Y)); break;
                                        case 7: ausgeben(hr.moveto(e.X, e.Y)); break;
                                        default: break;
                                    }
                                zug = 2;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                            else if (zug == 2)
                            {
                                baueristdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();


                                if (e.Y == 7) //Bauer auf Gegnerischer Seite
                                {
                                    gruenverwandelt++;
                                    if (gruenverwandelt < 4)
                                    while (true)
                                    {
                                        DialogResult damenwahl = MessageBox.Show("Wollen Sie eine Dame?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (damenwahl == DialogResult.Yes)
                                        {
                                            if (gruenverwandelt == 1)
                                            { ersatzdame1g = new Damegruen(); ersatzdame1g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 2) { ersatzdame2g = new Damegruen(); ersatzdame2g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 3) { ersatzdame3g = new Damegruen(); ersatzdame3g.moveto(e.X, e.Y); break; }

                                        }
                                        DialogResult turmwahl = MessageBox.Show("Wollen Sie einen Turm?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (turmwahl == DialogResult.Yes)
                                        {
                                            if (gruenverwandelt == 1)
                                            { ersatzturm1g = new Turmgruen(); ersatzturm1g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 2) { ersatzturm2g = new Turmgruen(); ersatzturm2g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 3) { ersatzturm3g = new Turmgruen(); ersatzturm3g.moveto(e.X, e.Y); break; }

                                        }
                                        DialogResult springerwahl = MessageBox.Show("Wollen Sie einen Springer?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (springerwahl == DialogResult.Yes)
                                        {
                                            if (gruenverwandelt == 1)
                                            { ersatzspringer1g = new Springergruen(); ersatzspringer1g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 2) { ersatzspringer2g = new Springergruen(); ersatzspringer2g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 3) { ersatzspringer3g = new Springergruen(); ersatzspringer3g.moveto(e.X, e.Y); break; }
                                        }
                                        DialogResult laeuferwahl = MessageBox.Show("Wollen Sie einen Läufer?", "Bauerntausch", MessageBoxButtons.YesNo);
                                        if (laeuferwahl == DialogResult.Yes)
                                        {
                                            if (gruenverwandelt == 1)
                                            { ersatzlaeufer1g = new Laeufergruen(); ersatzlaeufer1g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 2) { ersatzlaeufer2g = new Laeufergruen(); ersatzlaeufer2g.moveto(e.X, e.Y); break; }
                                            if (gruenverwandelt == 3) { ersatzlaeufer3g = new Laeufergruen(); ersatzlaeufer3g.moveto(e.X, e.Y); break; }
                                        }
                                    }
                                    switch (bauerg)
                                    {
                                        case 0: ag.remove(); break;
                                        case 1: bg.remove(); break;
                                        case 2: cg.remove(); break;
                                        case 3: dg.remove(); break;
                                        case 4: eg.remove(); break;
                                        case 5: fg.remove(); break;
                                        case 6: gg.remove(); break;
                                        case 7: hg.remove(); break;
                                        default: break;
                                    }
                                    ausgeben("Bauer verwandelt.");
                                }
                                else
                                    switch (bauerg)
                                    {
                                        case 0: ausgeben(ag.moveto(e.X, e.Y)); break;
                                        case 1: ausgeben(bg.moveto(e.X, e.Y)); break;
                                        case 2: ausgeben(cg.moveto(e.X, e.Y)); break;
                                        case 3: ausgeben(dg.moveto(e.X, e.Y)); break;
                                        case 4: ausgeben(eg.moveto(e.X, e.Y)); break;
                                        case 5: ausgeben(fg.moveto(e.X, e.Y)); break;
                                        case 6: ausgeben(gg.moveto(e.X, e.Y)); break;
                                        case 7: ausgeben(hg.moveto(e.X, e.Y)); break;
                                        default: break;
                                    }
                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }
                        //TURM DARF ZIEHEN?...
                        if (turmistdran == true)
                        {
                            if (zug == 1)
                            {
                                turmistdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                switch (turm)
                                {
                                    case 1: ausgeben(t1r.moveto(e.X, e.Y)); rochaderotgross = false; break;
                                    case 2: ausgeben(t2r.moveto(e.X, e.Y)); rochaderotklein = false; break;
                                    case 3: ausgeben(ersatzturm1.moveto(e.X, e.Y)); break;
                                    case 4: ausgeben(ersatzturm2.moveto(e.X, e.Y)); break;
                                    case 5: ausgeben(ersatzturm3.moveto(e.X, e.Y)); break;
                                    default: break;
                                }
                                zug = 2;
                                showboard();
                                spieleranzeige();
                                return;
                            }
                            else if (zug == 2)
                            {
                                turmistdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                switch (turmg)
                                {
                                    case 1: ausgeben(t1g.moveto(e.X, e.Y)); rochadegruengross = false; break;
                                    case 2: ausgeben(t2g.moveto(e.X, e.Y)); rochadegruenklein = false; break;
                                    case 3: ausgeben(ersatzturm1g.moveto(e.X, e.Y)); break;
                                    case 4: ausgeben(ersatzturm2g.moveto(e.X, e.Y)); break;
                                    case 5: ausgeben(ersatzturm3g.moveto(e.X, e.Y)); break;
                                    default: break;
                                }
                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }
                        if (springeristdran == true) //Springer..?
                        {
                            if (zug == 1)
                            {
                                springeristdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                switch (springer)
                                {
                                    case 1: ausgeben(s1r.moveto(e.X, e.Y)); break;
                                    case 2: ausgeben(s2r.moveto(e.X, e.Y)); break;
                                    case 3: ausgeben(ersatzspringer1.moveto(e.X, e.Y)); break;
                                    case 4: ausgeben(ersatzspringer2.moveto(e.X, e.Y)); break;
                                    case 5: ausgeben(ersatzspringer3.moveto(e.X, e.Y)); break;
                                    default: break;
                                }
                                zug = 2;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                            else if (zug == 2)
                            {
                                springeristdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                switch (springerg)
                                {
                                    case 1: ausgeben(s1g.moveto(e.X, e.Y)); break;
                                    case 2: ausgeben(s2g.moveto(e.X, e.Y)); break;
                                    case 3: ausgeben(ersatzspringer1g.moveto(e.X, e.Y)); break;
                                    case 4: ausgeben(ersatzspringer2g.moveto(e.X, e.Y)); break;
                                    case 5: ausgeben(ersatzspringer3g.moveto(e.X, e.Y)); break;
                                    default: break;
                                }
                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }
                        //KÖNIG DARF/MUSS ZIEHEN?
                        if (koenigistdran == true)
                        {
                            if (zug == 1)
                            {
                                koenigistdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                ausgeben(koenigrot.moveto(e.X, e.Y));
                                rochaderotgross = false;
                                rochaderotklein = false;

                                zug = 2;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                            else if (zug == 2)
                            {
                                koenigistdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                ausgeben(koeniggruen.moveto(e.X, e.Y));
                                rochadegruengross = false;
                                rochadegruenklein = false;

                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }

                        //LÄUFER DARF ZIEHEN?..
                        if (laeuferistdran == true)
                        {
                            if (zug == 1)
                            {
                                laeuferistdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                switch (laeufer)
                                {
                                    case 1: ausgeben(l1r.moveto(e.X, e.Y)); break;
                                    case 2: ausgeben(l2r.moveto(e.X, e.Y)); break;
                                    case 3: ausgeben(ersatzlaeufer1.moveto(e.X, e.Y)); break;
                                    case 4: ausgeben(ersatzlaeufer2.moveto(e.X, e.Y)); break;
                                    case 5: ausgeben(ersatzlaeufer3.moveto(e.X, e.Y)); break;
                                    default: break;
                                }
                                zug = 2;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                            else if (zug == 2)
                            {
                                laeuferistdran = false;

                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                switch (laeuferg)
                                {
                                    case 1: ausgeben(l1g.moveto(e.X, e.Y)); break;
                                    case 2: ausgeben(l2g.moveto(e.X, e.Y)); break;
                                    case 3: ausgeben(ersatzlaeufer1g.moveto(e.X, e.Y)); break;
                                    case 4: ausgeben(ersatzlaeufer2g.moveto(e.X, e.Y)); break;
                                    case 5: ausgeben(ersatzlaeufer3g.moveto(e.X, e.Y)); break;
                                    default: break;
                                }
                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }
                        //DAME???????
                        if (dameistdran == true)
                        {
                            dameistdran = false;
                            if (zug == 1)
                            {
                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                if (dame == 1)
                                    ausgeben(damerot.moveto(e.X, e.Y));
                                else if (dame == 2)
                                    ausgeben(ersatzdame1.moveto(e.X, e.Y));
                                else if (dame == 3)
                                    ausgeben(ersatzdame2.moveto(e.X, e.Y));
                                else if (dame == 4)
                                    ausgeben(ersatzdame3.moveto(e.X, e.Y));

                                zug = 2;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                            else if (zug == 2)
                            {
                                if (enemyon(e.X, e.Y))
                                { enemydie(e.X, e.Y); enemydiesound(); }
                                else zugsound();

                                if (dameg == 1)
                                    ausgeben(damegruen.moveto(e.X, e.Y));
                                else if (dameg == 2)
                                    ausgeben(ersatzdame1g.moveto(e.X, e.Y));
                                else if (dameg == 3)
                                    ausgeben(ersatzdame2g.moveto(e.X, e.Y));
                                else if (dameg == 4)
                                    ausgeben(ersatzdame3g.moveto(e.X, e.Y));

                                if (enemyon(e.X + 1, e.Y) && passantgruen == e.X + 1)
                                    if (e.X + 1 < 8)
                                        mLaunchpadDevice[e.X + 1, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);
                                if (enemyon(e.X - 1, e.Y) && passantgruen == e.X - 1)
                                    if (e.X - 1 >= 0)
                                        mLaunchpadDevice[e.X - 1, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);

                                zug = 1;
                                showboard();
                                spieleranzeige();
                                pboxchange("lpchesslogo.png");
                                ausgeben2("");
                                return;
                            }
                        }
                    }




                    //////////////////////////////////////AUSWAHL DER FIGUR/////////////////////////////////////////////////////////


                    if (enemyon(e.X, e.Y))
                    {
                        showfigureon(e.X, e.Y);
                    }
                    if (eigeneron(e.X, e.Y))
                    {
                        showfigureon(e.X, e.Y);
                    }


                    ///////////WENN ROTER BAUER GEWÄHLT WURDE//////////////////////
                    if (zug == 1 && (ar.ison(e.X, e.Y) || br.ison(e.X, e.Y) || cr.ison(e.X, e.Y) || dr.ison(e.X, e.Y) || er.ison(e.X, e.Y) || fr.ison(e.X, e.Y) || gr.ison(e.X, e.Y) || hr.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Off);

                        if (enemyon(e.X + 1, e.Y - 1))
                            if (e.X + 1 < 8 && e.Y - 1 >= 0)
                                mLaunchpadDevice[e.X + 1, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (enemyon(e.X - 1, e.Y - 1))
                            if (e.X - 1 >= 0 && e.Y - 1 >= 0)
                                mLaunchpadDevice[e.X - 1, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if ((!(enemyon(e.X, e.Y - 1))) && (!(eigeneron(e.X, e.Y - 1))))
                        {
                            if (e.X < 8 && e.Y - 1 >= 0)
                                mLaunchpadDevice[e.X, (e.Y - 1)].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            if (e.Y == 6)
                                if ((!(enemyon(e.X, e.Y - 2))) && (!(eigeneron(e.X, e.Y - 2))))
                                    mLaunchpadDevice[e.X, e.Y - 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        if (enemyon(e.X - 1, e.Y) && passantrot == e.X -1)
                            if (e.X - 1 >= 0)
                                mLaunchpadDevice[e.X - 1, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);
                        if (enemyon(e.X + 1, e.Y) && passantrot == e.X + 1)
                            if (e.X + 1 < 8)
                                mLaunchpadDevice[e.X + 1, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);

                        bauer = checkbauer(e.X, e.Y);
                        turmistdran = false;
                        springeristdran = false;
                        baueristdran = true;
                        laeuferistdran = false;
                        dameistdran = false;
                        koenigistdran = false;
                        return;

                    }
                    ///////////WENN GRÜNER BAUER GEWÄHLT WURDE//////////////////////
                    if (zug == 2 && (ag.ison(e.X, e.Y) || bg.ison(e.X, e.Y) || cg.ison(e.X, e.Y) || dg.ison(e.X, e.Y) || eg.ison(e.X, e.Y) || fg.ison(e.X, e.Y) || gg.ison(e.X, e.Y) || hg.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Medium);

                        if (enemyon(e.X + 1, e.Y + 1))
                            if (e.X + 1 < 8 && e.Y + 1 < 8)
                                mLaunchpadDevice[e.X + 1, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (enemyon(e.X - 1, e.Y + 1))
                            if (e.X - 1 >= 0 && e.Y + 1 < 8)
                                mLaunchpadDevice[e.X - 1, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if ((!(enemyon(e.X, e.Y + 1))) && (!(eigeneron(e.X, e.Y + 1))))
                        {
                            if (e.X < 8 && e.Y + 1 < 8)
                                mLaunchpadDevice[e.X, (e.Y + 1)].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                            if (e.Y == 1)
                                if ((!(enemyon(e.X, e.Y + 2))) && (!(eigeneron(e.X, e.Y + 2))))
                                    mLaunchpadDevice[e.X, e.Y + 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        bauerg = checkbauer(e.X, e.Y);
                        baueristdran = true;
                        turmistdran = false;
                        dameistdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = false;
                        return;
                    }

                    ///////////WENN ROTER TURM GEWÄHLT WURDE//////////////////////
                    if (zug == 1 && (t1r.ison(e.X, e.Y) || t2r.ison(e.X, e.Y) || ersatzturm1.ison(e.X, e.Y) || ersatzturm2.ison(e.X, e.Y) || ersatzturm3.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Off);
                        bool makebreak = false;

                        for (int r = e.X + 1; r < 8; ++r) //rechts
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, e.Y))
                                break;
                            if (enemyon(r, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[r, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int l = e.X - 1; l >= 0; --l) //links
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(l, e.Y))
                                break;
                            if (enemyon(l, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[l, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int u = e.Y + 1; u < 8; ++u) //unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, u))
                                break;
                            if (enemyon(e.X, u))
                                makebreak = true;

                            mLaunchpadDevice[e.X, u].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int o = e.Y - 1; o >= 0; --o) //oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, o))
                                break;
                            if (enemyon(e.X, o))
                                makebreak = true;

                            mLaunchpadDevice[e.X, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        turm = checkturm(e.X, e.Y);
                        baueristdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = false;
                        dameistdran = false;
                        turmistdran = true;
                        return;

                    }

                    ///////////WENN GRÜNER TURM GEWÄHLT WURDE//////////////////////
                    if (zug == 2 && (t1g.ison(e.X, e.Y) || t2g.ison(e.X, e.Y) || ersatzturm1g.ison(e.X, e.Y) || ersatzturm2g.ison(e.X, e.Y) || ersatzturm3g.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Medium);
                        bool makebreak = false; ;
                        for (int r = e.X + 1; r < 8; ++r) //rechts
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, e.Y))
                                break;
                            if (enemyon(r, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[r, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int l = e.X - 1; l >= 0; --l) //links
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(l, e.Y))
                                break;
                            if (enemyon(l, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[l, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int u = e.Y + 1; u < 8; ++u) //unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, u))
                                break;
                            if (enemyon(e.X, u))
                                makebreak = true;

                            mLaunchpadDevice[e.X, u].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int o = e.Y - 1; o >= 0; --o) //oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, o))
                                break;
                            if (enemyon(e.X, o))
                                makebreak = true;

                            mLaunchpadDevice[e.X, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        turm = checkturm(e.X, e.Y);
                        baueristdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = false;
                        dameistdran = false;
                        turmistdran = true;
                        return;
                    }

                    //WENN ROTER SPRINGER GEWÄHLT WURDE
                    if (zug == 1 && (s1r.ison(e.X, e.Y) || s2r.ison(e.X, e.Y) || s2g.ison(e.X, e.Y) || ersatzspringer1.ison(e.X, e.Y) || ersatzspringer2.ison(e.X, e.Y) || ersatzspringer3.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Off);

                        if (!(eigeneron(e.X - 1, e.Y - 2)) && e.X - 1 >= 0 && e.Y - 2 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y - 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 1, e.Y - 2)) && e.X + 1 < 8 && e.Y - 2 >= 0)
                            mLaunchpadDevice[e.X + 1, e.Y - 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 2, e.Y - 1)) && e.X + 2 < 8 && e.Y - 1 >= 0)
                            mLaunchpadDevice[e.X + 2, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 2, e.Y + 1)) && e.X + 2 < 8 && e.Y + 1 < 8)
                            mLaunchpadDevice[e.X + 2, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 1, e.Y + 2)) && e.X + 1 < 8 && e.Y + 2 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y + 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y + 2)) && e.X - 1 >= 0 && e.Y + 2 < 8)
                            mLaunchpadDevice[e.X - 1, e.Y + 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 2, e.Y + 1)) && e.X - 2 >= 0 && e.Y + 1 < 8)
                            mLaunchpadDevice[e.X - 2, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 2, e.Y - 1)) && e.X - 2 >= 0 && e.Y - 1 >= 0)
                            mLaunchpadDevice[e.X - 2, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);

                        springer = checkspringer(e.X, e.Y);
                        baueristdran = false;
                        turmistdran = false;
                        laeuferistdran = false;
                        dameistdran = false;
                        koenigistdran = false;
                        springeristdran = true;
                        return;

                    }

                    //WENN GRÜNER SPRINGER GEWÄHLT WURDE
                    if (zug == 2 && (s1g.ison(e.X, e.Y) || s2g.ison(e.X, e.Y) || ersatzspringer1g.ison(e.X, e.Y) || ersatzspringer2g.ison(e.X, e.Y) || ersatzspringer3g.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Medium);

                        if (!(eigeneron(e.X - 1, e.Y - 2)) && e.X - 1 >= 0 && e.Y - 2 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y - 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 1, e.Y - 2)) && e.X + 1 < 8 && e.Y - 2 >= 0)
                            mLaunchpadDevice[e.X + 1, e.Y - 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 2, e.Y - 1)) && e.X + 2 < 8 && e.Y - 1 >= 0)
                            mLaunchpadDevice[e.X + 2, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 2, e.Y + 1)) && e.X + 2 < 8 && e.Y + 1 < 8)
                            mLaunchpadDevice[e.X + 2, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X + 1, e.Y + 2)) && e.X + 1 < 8 && e.Y + 2 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y + 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y + 2)) && e.X - 1 >= 0 && e.Y + 2 < 8)
                            mLaunchpadDevice[e.X - 1, e.Y + 2].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 2, e.Y + 1)) && e.X - 2 >= 0 && e.Y + 1 < 8)
                            mLaunchpadDevice[e.X - 2, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 2, e.Y - 1)) && e.X - 2 >= 0 && e.Y - 1 >= 0)
                            mLaunchpadDevice[e.X - 2, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);

                        springerg = checkspringer(e.X, e.Y);
                        baueristdran = false;
                        turmistdran = false;
                        koenigistdran = false;
                        laeuferistdran = false;
                        dameistdran = false;
                        springeristdran = true;
                        return;

                    }

                    //WENN ROTER KÖNIG GEWÄHLT WURDE
                    if (zug == 1 && koenigrot.ison(e.X, e.Y))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Off);

                        if (!(eigeneron(e.X, e.Y - 1)) && e.Y - 1 >= 0)
                            mLaunchpadDevice[e.X, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Oben
                        if (!(eigeneron(e.X + 1, e.Y - 1)) && e.Y - 1 >= 0 && e.X + 1 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Schräg rechts oben
                        if (!(eigeneron(e.X + 1, e.Y)) && e.X + 1 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Rechts..
                        if (!(eigeneron(e.X + 1, e.Y + 1)) && e.Y + 1 < 8 && e.X + 1 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Schräg Runten
                        if (!(eigeneron(e.X, e.Y + 1)) && e.Y + 1 < 8)
                            mLaunchpadDevice[e.X, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y + 1)) && e.Y + 1 < 8 && e.X - 1 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y)) && e.X - 1 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y - 1)) && e.Y - 1 >= 0 && e.X - 1 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        /*!!*/
                        if (!(eigeneron(1, 7)) && !(eigeneron(2, 7)) && !(eigeneron(3, 7)) && !(enemyon(1, 7)) && !(enemyon(2, 7)) && !(enemyon(3, 7)) && rochaderotgross == true)
                            mLaunchpadDevice[2, 7].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);
                        if (!(eigeneron(5, 7)) && !(eigeneron(6, 7)) && !(enemyon(5, 7)) && !(enemyon(6, 7)) && rochaderotklein == true)
                            mLaunchpadDevice[6, 7].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);
                        baueristdran = false;
                        dameistdran = false;
                        turmistdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = true;
                        return;

                    }
                    //Wenn der Grüne könig gewählt wurde..
                    if (zug == 2 && koeniggruen.ison(e.X, e.Y))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Medium);

                        if (!(eigeneron(e.X, e.Y - 1)) && e.Y - 1 >= 0)
                            mLaunchpadDevice[e.X, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Oben
                        if (!(eigeneron(e.X + 1, e.Y - 1)) && e.Y - 1 >= 0 && e.X + 1 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Schräg rechts oben
                        if (!(eigeneron(e.X + 1, e.Y)) && e.X + 1 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Rechts..
                        if (!(eigeneron(e.X + 1, e.Y + 1)) && e.Y + 1 < 8 && e.X + 1 < 8)
                            mLaunchpadDevice[e.X + 1, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full); //Schräg Runten
                        if (!(eigeneron(e.X, e.Y + 1)) && e.Y + 1 < 8)
                            mLaunchpadDevice[e.X, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y + 1)) && e.Y + 1 < 8 && e.X - 1 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y + 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y)) && e.X - 1 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        if (!(eigeneron(e.X - 1, e.Y - 1)) && e.Y - 1 >= 0 && e.X - 1 >= 0)
                            mLaunchpadDevice[e.X - 1, e.Y - 1].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        //Rochade
                        if (!(eigeneron(1, 0)) && !(eigeneron(2, 0)) && !(eigeneron(3, 0)) && !(enemyon(1, 0)) && !(enemyon(2, 0)) && !(enemyon(3, 0)) && rochadegruengross == true)
                            mLaunchpadDevice[2, 0].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);
                        if (!(eigeneron(5, 0)) && !(eigeneron(6, 0)) && !(enemyon(5, 0)) && !(enemyon(6, 0)) && rochadegruenklein == true)
                            mLaunchpadDevice[6, 0].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Medium);

                        baueristdran = false;
                        turmistdran = false;
                        dameistdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = true;
                        return;

                    }

                    ///////////WENN ROTER LÄUFER GEWÄHLT WURDE//////////////////////
                    if (zug == 1 && (l1r.ison(e.X, e.Y) || l2r.ison(e.X, e.Y) || ersatzlaeufer1.ison(e.X, e.Y) || ersatzlaeufer2.ison(e.X, e.Y) || ersatzlaeufer3.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Off);
                        bool makebreak = false;

                        for (int r = e.X + 1, o = e.Y + 1; r < 8 && o < 8; ++r, ++o) //rechts unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X + 1, o = e.Y - 1; r < 8 && o >= 0; ++r, --o) //rechts oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y + 1; r >= 0 && o < 8; --r, ++o) //links unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y - 1; r >= 0 && o >= 0; --r, --o) //links oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        laeufer = checklaeufer(e.X, e.Y);
                        baueristdran = false;
                        springeristdran = false;
                        turmistdran = false;
                        koenigistdran = false;
                        dameistdran = false;
                        laeuferistdran = true;
                        return;

                    }

                    ///////////WENN GRÜNER LÄUFER GEWÄHLT WURDE//////////////////////
                    if (zug == 2 && (l1g.ison(e.X, e.Y) || l2g.ison(e.X, e.Y) || ersatzlaeufer1g.ison(e.X, e.Y) || ersatzlaeufer2g.ison(e.X, e.Y) || ersatzlaeufer3g.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Medium);
                        bool makebreak = false; ;

                        for (int r = e.X + 1, o = e.Y + 1; r < 8 && o < 8; ++r, ++o) //rechts unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X + 1, o = e.Y - 1; r < 8 && o >= 0; ++r, --o) //rechts oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y + 1; r >= 0 && o < 8; --r, ++o) //links unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y - 1; r >= 0 && o >= 0; --r, --o) //links oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        laeuferg = checklaeufer(e.X, e.Y);
                        baueristdran = false;
                        springeristdran = false;
                        turmistdran = false;
                        koenigistdran = false;
                        dameistdran = false;
                        laeuferistdran = true;
                        return;

                    }


                    //WENN ROTE DAME GEWÄHLT WURDE
                    if (zug == 1 && (damerot.ison(e.X, e.Y) || ersatzdame1.ison(e.X, e.Y) || ersatzdame2.ison(e.X, e.Y) || ersatzdame3.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Medium, ButtonBrightness.Off);

                        if (damerot.ison(e.X, e.Y))
                            dame = 1;
                        else if (ersatzdame1.ison(e.X, e.Y))
                            dame = 2;
                        else if (ersatzdame2.ison(e.X, e.Y))
                            dame = 3;
                        else if (ersatzdame3.ison(e.X, e.Y))
                            dame = 4;

                        bool makebreak = false; ;

                        for (int r = e.X + 1, o = e.Y + 1; r < 8 && o < 8; ++r, ++o) //rechts unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X + 1, o = e.Y - 1; r < 8 && o >= 0; ++r, --o) //rechts oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y + 1; r >= 0 && o < 8; --r, ++o) //links unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y - 1; r >= 0 && o >= 0; --r, --o) //links oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;

                        for (int r = e.X + 1; r < 8; ++r) //rechts
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, e.Y))
                                break;
                            if (enemyon(r, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[r, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int l = e.X - 1; l >= 0; --l) //links
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(l, e.Y))
                                break;
                            if (enemyon(l, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[l, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int u = e.Y + 1; u < 8; ++u) //unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, u))
                                break;
                            if (enemyon(e.X, u))
                                makebreak = true;

                            mLaunchpadDevice[e.X, u].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int o = e.Y - 1; o >= 0; --o) //oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, o))
                                break;
                            if (enemyon(e.X, o))
                                makebreak = true;

                            mLaunchpadDevice[e.X, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        baueristdran = false;
                        turmistdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = false;
                        dameistdran = true;
                        return;

                    }

                    //WENN GRÜNE DAME GEWÄHLT WURDE
                    if (zug == 2 && (damegruen.ison(e.X, e.Y) || ersatzdame1g.ison(e.X, e.Y) || ersatzdame2g.ison(e.X, e.Y) || ersatzdame3g.ison(e.X, e.Y)))
                    {
                        if (mixer == false)
                            launchpadaus(mLaunchpadDevice);
                        else
                            showboard();
                        mLaunchpadDevice[e.X, e.Y].SetBrightness(ButtonBrightness.Off, ButtonBrightness.Medium);

                        if (damegruen.ison(e.X, e.Y))
                            dameg = 1;
                        else if (ersatzdame1g.ison(e.X, e.Y))
                            dameg = 2;
                        else if (ersatzdame2g.ison(e.X, e.Y))
                            dameg = 3;
                        else if (ersatzdame3g.ison(e.X, e.Y))
                            dameg = 4;

                        bool makebreak = false;

                        for (int r = e.X + 1, o = e.Y + 1; r < 8 && o < 8; ++r, ++o) //rechts unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X + 1, o = e.Y - 1; r < 8 && o >= 0; ++r, --o) //rechts oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y + 1; r >= 0 && o < 8; --r, ++o) //links unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int r = e.X - 1, o = e.Y - 1; r >= 0 && o >= 0; --r, --o) //links oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, o))
                                break;
                            if (enemyon(r, o))
                                makebreak = true;

                            mLaunchpadDevice[r, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;

                        for (int r = e.X + 1; r < 8; ++r) //rechts
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(r, e.Y))
                                break;
                            if (enemyon(r, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[r, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int l = e.X - 1; l >= 0; --l) //links
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(l, e.Y))
                                break;
                            if (enemyon(l, e.Y))
                                makebreak = true;

                            mLaunchpadDevice[l, e.Y].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int u = e.Y + 1; u < 8; ++u) //unten
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, u))
                                break;
                            if (enemyon(e.X, u))
                                makebreak = true;

                            mLaunchpadDevice[e.X, u].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }
                        makebreak = false;
                        for (int o = e.Y - 1; o >= 0; --o) //oben
                        {
                            if (makebreak == true)
                                break;
                            if (eigeneron(e.X, o))
                                break;
                            if (enemyon(e.X, o))
                                makebreak = true;

                            mLaunchpadDevice[e.X, o].SetBrightness(ButtonBrightness.Full, ButtonBrightness.Full);
                        }

                        baueristdran = false;
                        turmistdran = false;
                        springeristdran = false;
                        laeuferistdran = false;
                        koenigistdran = false;
                        dameistdran = true;
                        return;

                    }
                    //<-----------neue Figuren bitte wieder hier dazu

                }




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            }


            class Bauerrot
            {
                private
                char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Bauerrot(int a = 0, int b = 6)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {

                    string ausgabe = ("Rot:   Bauer     " + feld[(x)] + ((8 - y)));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Bauergruen
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Bauergruen(int a = 0, int b = 1)
                {
                    x = a;
                    y = b;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    string ausgabe = ("Grün: Bauer     " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Turmrot
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Turmrot(int a = 0, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    string ausgabe = ("Rot:   Turm      " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Turmgruen
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Turmgruen(int a = 0, int b = 0)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    string ausgabe = ("Grün: Turm      " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Springerrot
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Springerrot(int a = 0, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    string ausgabe = ("Rot:   Springer  " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Springergruen
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Springergruen(int a = 0, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    string ausgabe = ("Grün: Springer  " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Koenigrot
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Koenigrot(int a = 4, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    string ausgabe = ("Rot:   Koenig    " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Koeniggruen
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Koeniggruen(int a = 4, int b = 0)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    string ausgabe = ("Grün: Koenig    " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Laeuferrot
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Laeuferrot(int a = 0, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    string ausgabe = ("Rot:   Laeufer   " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Laeufergruen
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Laeufergruen(int a = 0, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    string ausgabe = ("Grün: Laeufer   " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Damerot
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Damerot(int a = 4, int b = 7)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    string ausgabe = ("Rot:   Dame      " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
            class Damegruen
            {
                private
                    char[] feld = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int x;
                int y;
                public
                Damegruen(int a = 4, int b = 0)
                {
                    x = a;
                    y = b;
                }
                public string moveto(int a, int b)
                {
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    string ausgabe = ("Grün: Dame      " + feld[(x)] + (8 - y));
                    x = a;
                    y = b;
                    ausgabe = ausgabe + (" -> " + feld[(a)] + (8 - b));
                    return ausgabe;
                }
                public void remove()
                {
                    x = 8;
                    y = 8;
                }
                public bool ison(int a, int b)
                {
                    return (a == x && b == y);
                }
            };
        }

        //////////////////////////  e passant! Rochadenproblem (fressen des Turms)


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                device = new LaunchpadDevice();
                device.DoubleBuffered = true;
            }
            catch
            {
                textBox2.Text = ("Launchpad nicht angeschlossen, oder durch ein anderes Programm verwendet!");
                return;
            }
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    device[x, y].TurnOffLight();
            device.GetButton(ToolbarButton.Session).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.Left).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.User1).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.User2).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.GetButton(ToolbarButton.Mixer).SetBrightness(ButtonBrightness.Off, ButtonBrightness.Off);
            device.Reset();
            Warten warten = new Warten(device);
            button1.Enabled = true;
            button2.Enabled = false;
            button2.Text = "Launchpad erkannt";
            hilfe();
        }

        bool selbstchange = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (selbstchange == false)
            {
                if (textBox1.Text == "Bauer2")
                    pictureBox1.Image = System.Drawing.Image.FromFile("bauer2.png");
                if (textBox1.Text == "König2")
                    pictureBox1.Image = System.Drawing.Image.FromFile("koenig2.png");
                if (textBox1.Text == "Dame2")
                    pictureBox1.Image = System.Drawing.Image.FromFile("dame2.png");
                if (textBox1.Text == "Läufer2")
                    pictureBox1.Image = System.Drawing.Image.FromFile("laeufer2.png");
                if (textBox1.Text == "Springer2")
                    pictureBox1.Image = System.Drawing.Image.FromFile("springer2.png");
                if (textBox1.Text == "Turm2")
                    pictureBox1.Image = System.Drawing.Image.FromFile("turm2.png");
                if (textBox1.Text == "Bauer1")
                    pictureBox1.Image = System.Drawing.Image.FromFile("bauer.png");
                if (textBox1.Text == "König1")
                    pictureBox1.Image = System.Drawing.Image.FromFile("koenig.png");
                if (textBox1.Text == "Dame1")
                    pictureBox1.Image = System.Drawing.Image.FromFile("dame.png");
                if (textBox1.Text == "Läufer1")
                    pictureBox1.Image = System.Drawing.Image.FromFile("laeufer.png");
                if (textBox1.Text == "Springer1")
                    pictureBox1.Image = System.Drawing.Image.FromFile("springer.png");
                if (textBox1.Text == "Turm1")
                    pictureBox1.Image = System.Drawing.Image.FromFile("turm.png");
            }
            selbstchange = false;
            if (textBox1.Text.Contains('2'))
            {
                selbstchange = true;
                textBox1.Text = textBox1.Text.Replace('2', '\0');
            }
            if (textBox1.Text.Contains('1'))
            {
                selbstchange = true;
                textBox1.Text = textBox1.Text.Replace('1', '\0');
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Launchpadschach Copyright 2014 by Felix Mark", "About", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("FIDE_Schachregeln.pdf");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Hilfe:" + Environment.NewLine +
            "Drücken Sie während eines Spiels [mixer] auf dem Launchpad,\num die Ansicht umzuschalten." + Environment.NewLine +
            "Drücken Sie während eines Spiels [user1] bzw. [user2] auf dem Launchpad,\num den am Zug befindlichen Spieler manuell zu wechseln." + Environment.NewLine +
            "Sie können echte Figuren auf das Launchpad stellen, oder aber nur die Anzeige des Programms verwenden." + Environment.NewLine +
            "Probleme beim Erkennen des Launchpads? -Schließen Sie alle Programme die das Launchpad verwenden, und probieren Sie erneut das Launchpad zu erkennen." + Environment.NewLine +
            "Stellen Sie sicher dass ihr Computer unter dem Betriebssystem WIndows läuft." + Environment.NewLine +
            "Bei weiteren Fragen kontaktieren Sie bitte fm.philex@hotmail.com"
            , "Hilfe", MessageBoxButtons.OK);
        }
    }
}
