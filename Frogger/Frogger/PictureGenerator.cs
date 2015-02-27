using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Frogger
{
    public class PictureGenerator
    {
        public static void StartScreen()
        {

            Image Picture = Image.FromFile(@"..\..\startscreen.png");
            //Console.SetWindowSize(140, 49);
            //Console.SetBufferSize((Picture.Width * 0x2), (Picture.Height * 0x2));
            FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0x0]);
            int FrameCount = Picture.GetFrameCount(Dimension);
            int Left = Console.WindowLeft, Top = Console.WindowTop;
            char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            Picture.SelectActiveFrame(Dimension, 0x0);
            for (int i = 0x0; i < Picture.Height; i++)
            {
                for (int x = 0x0; x < Picture.Width; x++)
                {
                    Color Color = ((Bitmap)Picture).GetPixel(x, i);
                    int Gray = (Color.R + Color.G + Color.B) / 0x3;
                    int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
                    Console.Write(Chars[Index]);
                }
                Console.Write('\n');
            }
            Console.SetCursorPosition(Left, Top);

            //Console.Read();

        }
    }
}
