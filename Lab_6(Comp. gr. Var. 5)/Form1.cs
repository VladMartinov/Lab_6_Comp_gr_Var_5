using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab_6_Comp.gr.Var._5_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Задаем тёмно-синий цвет для неба
            SolidBrush mySky = new SolidBrush(Color.DarkBlue);

            // Задаем тёмно-зеленый цвет для земли
            SolidBrush myEarth = new SolidBrush(Color.DarkGreen);

            // Задаем черный и серый цвет для корпуса и капсулы НЛО
            SolidBrush myShip = new SolidBrush(Color.Black);
            SolidBrush myCabin = new SolidBrush(Color.Gray);

            // Задаем зеленый (с прозрачностью) для луча
            Color beamColor = Color.FromArgb(175, Color.Green);
            SolidBrush myBeam = new SolidBrush(beamColor);

            // Задаем желто-зеленый цвет для звезды
            SolidBrush myStar = new SolidBrush(Color.GreenYellow);

            //=========== 1 - Рисуем землю, небо и тень =================

            // Рисуем два прямоугольника
            g.FillRectangle(mySky, 0, 0, Width, (float)(Height * 0.6));
            g.FillRectangle(myEarth, 0, (float)(Height * 0.6), Width, Height);
            //=========== 2 - Рисуем луч из НЛО ===========
            GraphicsPath myGraphicsPath = new GraphicsPath();
            myGraphicsPath.AddString("ПРИШЕЛЬЦЫ\n АТАКУЮТ!", new FontFamily("Times New Roman"), 1, 32, new Point(20, 20), new StringFormat());
            // Задаем координаты точек кривой (луч)
            Point[] myPointArray1 = {   new Point(260, 190),
                                        new Point(240, 280), new Point(300, 270),
                                        new Point(380, 280), new Point(370, 190) };
            // Добавляем кривую в контейнер
            myGraphicsPath.AddCurve(myPointArray1);

            Console.ForegroundColor = ConsoleColor.Red;
          
            // Выводим луч, закрашенную зеленым (с прозрачностью) цветом
            g.FillPath(myBeam, myGraphicsPath);


            //=========== 3 - Рисуем корпус НЛО и кабины ===========
            g.FillEllipse(myCabin, (float)(Width * 0.35), (float)(Height * 0.125), (float)(Width * 0.3), (float)(Height * 0.25));

            g.FillEllipse(myShip, (float)(Width * 0.25), (float)(Height * 0.225), (float)(Width * 0.5), (float)(Height * 0.25));

            //=========== 4 - Рисуем луну и звезду ===========
            
            g.FillEllipse(myStar, (float) (Width*0.85), 10, 70, 70);
            g.DrawEllipse(Pens.Yellow, (float)(Width * 0.85), 10, 70, 70);
            
            int x = 400; int y = 50;
            g.FillPolygon(myStar, new Point[] { new Point(x,y),new Point(x+5,y+5),
                                                new Point(x+15,y+10),new Point(x+5,y+15),
                                                new Point(x,y+20),new Point(x-5,y+15),
                                                new Point(x-15,y+10),new Point(x-5,y+5) });

            // Вывод всего, что мы нарисовали
            base.OnPaint(e);
        }
    }
}