using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace VDC.Helpers
{
    public class CodeHelper
    {
        public const string charSet = "2,3,4,5,6,8,9,A,B,C,D,E,F,G,H,J,K,M,N,P,R,S,U,W,X,Y";

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static string CreateRandomCode(int n)
        {
            string[] CharArray = charSet.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(CharArray.Length - 1);
                if (temp == t)
                {
                    return CreateRandomCode(n);
                }
                temp = t;
                randomCode += CharArray[t];
            }
            return randomCode;
        }

        public static MemoryStream CreateImage(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 13);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 23);
            Graphics g = Graphics.FromImage(image);
            Font f = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold));

            // 前景色
            Brush b = new System.Drawing.SolidBrush(Color.Black);

            // 背景色
            g.Clear(Color.White);

            // 填充文字
            g.DrawString(checkCode, f, b, 0, 1);

            // 随机线条
            Pen linePen = new Pen(Color.Gray, 0);
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x1 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int x2 = rand.Next(image.Width);
                int y2 = rand.Next(image.Height);
                g.DrawLine(linePen, x1, y1, x2, y2);
            }

            // 随机点
            for (int i = 0; i < 30; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                image.SetPixel(x, y, Color.Gray);
            }

            // 边框
            g.DrawRectangle(new Pen(Color.Gray), 0, 0, image.Width - 1, image.Height - 1);

            // 输出图片
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return ms;
        }
    }
}