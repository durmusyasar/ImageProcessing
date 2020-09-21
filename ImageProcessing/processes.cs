using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageProcessing
{
    public class Processes
    {
        public Bitmap Negative(Bitmap bitmap)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            Color firstColor, secondColor;
            int r, g, b;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    firstColor = bitmap.GetPixel(i, j);
                    r = 255 - firstColor.R;
                    g = 255 - firstColor.G;
                    b = 255 - firstColor.B;

                    secondColor = Color.FromArgb(r, g, b);
                    result.SetPixel(i, j, secondColor);
                }

            }
            return result;
        }

        public Bitmap ConvertGray(Bitmap bitmap)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            Color firstColor, secondColor;
            int hue;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    firstColor = bitmap.GetPixel(i, j);
                    hue = Convert.ToInt16(0.299 * firstColor.R) + Convert.ToInt16(0.587 * firstColor.G) + Convert.ToInt16(0.114 * firstColor.B);
                    secondColor = Color.FromArgb(hue, hue, hue);
                    result.SetPixel(i, j, secondColor);
                }
            }
            return result;
        }

        public Bitmap Thresholding(Bitmap bitmap, int threshold)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            int hue;
            Color color1, color2;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color1 = bitmap.GetPixel(i, j);
                    if (color1.R >= threshold)
                    {
                        color2 = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        color2 = Color.FromArgb(0, 0, 0);
                    }
                    result.SetPixel(i, j, color2);
                }
            }
            return result;
        }

        public Bitmap Brightness(Bitmap bitmap, int brightnessValue)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            int hue, r, g, b;
            Color color1, color2;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color1 = bitmap.GetPixel(i, j);
                    if (color1.R + brightnessValue >= 255)
                    {
                        r = 255;
                    }
                    else if(color1.R + brightnessValue < 0)
                    {
                        r = 0;
                    }
                    else
                    {
                        r = color1.R + brightnessValue;
                    }

                    if (color1.G + brightnessValue >= 255)
                    {
                        g = 255;
                    }
                    else if (color1.G + brightnessValue < 0)
                    {
                        g = 0;
                    }
                    else
                    {
                        g = color1.G + brightnessValue;
                    }

                    if (color1.B + brightnessValue >= 255)
                    {
                        b = 255;
                    }
                    else if (color1.B + brightnessValue < 0)
                    {
                        b = 0;
                    }
                    else
                    {
                        b = color1.B + brightnessValue;
                    }
                    color2 = Color.FromArgb(r, g, b);
                    result.SetPixel(i, j, color2);
                }
            }
            return result;
        }
    }
}
