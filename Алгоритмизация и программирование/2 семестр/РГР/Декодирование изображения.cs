//Декодирование изображения

using System;
using System.Collections.Generic;

namespace ImageDecoding
{
    class Program
    {
        static int w, h;
        static int[,] pixels;
        static Queue<string[]> info_lines = new Queue<string[]>();

        class ImagePart
        {
            public string type_colour;
            public int start_x, start_y;
            public int part_w, part_h;
            public ImagePart[] parts;
            public ImagePart(string type_colour, int x, int y, int w, int h)
            {
                this.type_colour = type_colour;
                start_x = x;
                start_y = y;
                part_w = w;
                part_h = h;
                parts = new ImagePart[4];
            }
        }

        static void FindAllZ(ImagePart part, List<ImagePart> list)
        {
            if (part.type_colour == "Z") list.Add(part);
        }

        static void CalculateArea(ImagePart parent, int index, out int x, out int y, out int w, out int h)
        {
            int left_w = parent.part_w / 2 + parent.part_w % 2;
            int right_w = parent.part_w / 2;
            int top_h = parent.part_h / 2 + parent.part_h % 2;
            int bottom_h = parent.part_h / 2;

            switch (index)
            {
                case 0: // LT
                    x = parent.start_x;
                    y = parent.start_y;
                    w = left_w;
                    h = top_h;
                    break;

                case 1: // RT
                    x = parent.start_x + left_w;
                    y = parent.start_y;
                    w = right_w;
                    h = top_h;
                    break;

                case 2: // LB
                    x = parent.start_x;
                    y = parent.start_y + top_h;
                    w = left_w;
                    h = bottom_h;
                    break;

                case 3: // RB
                    x = parent.start_x + left_w;
                    y = parent.start_y + top_h;
                    w = right_w;
                    h = bottom_h;
                    break;

                default:
                    throw new Exception("Ошибка!");
            }
        }

        static void FillPixels(ImagePart part)
        {
            if (part == null) return;

            if (part.type_colour == "Z")
            {
                for (int i = 0; i < 4; i++)
                {
                    FillPixels(part.parts[i]);
                }
            }
            else
            {
                int colour = Convert.ToInt32(part.type_colour);

                for (int y = part.start_y; y < part.start_y + part.part_h; y++)
                {
                    for (int x = part.start_x; x < part.start_x + part.part_w; x++)
                    {
                        pixels[y, x] = colour;
                    }
                }
            }
        }
        static void Main()
        {
            Console.Write("Введите через пробел ширину и высоту изображения: ");
            string[] size = Console.ReadLine().Split();
            w = Convert.ToInt32(size[0]);
            h = Convert.ToInt32(size[1]);
            pixels = new int[h, w];

            Console.Write("Введите цвет изображения: ");
            string fill_colour = Console.ReadLine().Trim();

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line.Length == 0) break;
                else info_lines.Enqueue(line.Split());
            }

            ImagePart main_data = new ImagePart(fill_colour, 0, 0, w, h);

            List<ImagePart> parts_z = new List<ImagePart>();
            FindAllZ(main_data, parts_z);

            int curr_z = 0;
            while (curr_z < parts_z.Count)
            {
                ImagePart curr = parts_z[curr_z];
                string[] data = info_lines.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int new_x, new_y, new_w, new_h;
                    CalculateArea(curr, i, out new_x, out new_y, out new_w, out new_h);
                    if (data[i] != "-")
                    {
                        curr.parts[i] = new ImagePart(data[i], new_x, new_y, new_w, new_h);
                        if (data[i] == "Z") parts_z.Add(curr.parts[i]);
                    }
                }
                curr_z++;
            }

            FillPixels(main_data);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.Write(pixels[y, x]);
                    if (x < w - 1) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
