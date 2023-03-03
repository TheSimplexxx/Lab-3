using System;
using System;
using System.Diagnostics;

using System.IO;
using System.Linq;
using System.Runtime.InteropServices;


using System.Drawing;


namespace Lab_3
{
    class Program1
    {
        //    static void Main(string[] args)
        //    {

        //        string csvFilePath = "transactions.csv";

        //        string dateFormat = "dd/MM/yyyy";

        //        Func<string, DateTime> getDate = (line) => DateTime.ParseExact(line.Split(',')[0], dateFormat, null);
        //        Func<string, double> getAmount = (line) => double.TryParse(line.Split(',')[1], out double result) ? result : 0.0;


        //        Action<DateTime, double> displayDailyTotal = (date, total) =>
        //        {
        //            Console.WriteLine($"{date.ToString(dateFormat)}: {total:C}");
        //        };

        //        int batchSize = 10;

        //        using (StreamReader reader = new StreamReader(csvFilePath))
        //        {
        //            DateTime previousDate = DateTime.MinValue;
        //            double dailyTotal = 0;

        //            string line;
        //            int lineCount = 0;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                DateTime date = getDate(line);
        //                double amount = getAmount(line);

        //                if (date != previousDate && previousDate != DateTime.MinValue)
        //                {
        //                    displayDailyTotal(previousDate, dailyTotal);
        //                    dailyTotal = 0;
        //                }

        //                dailyTotal += amount;

        //                lineCount++;
        //                if (lineCount % batchSize == 0)
        //                {
        //                    WriteDailyTotalToFile(previousDate, dailyTotal, csvFilePath, dateFormat);
        //                    dailyTotal = 0;
        //                }
        //                previousDate = date;
        //            }

        //            if (previousDate != DateTime.MinValue)
        //            {
        //                displayDailyTotal(previousDate, dailyTotal);
        //                WriteDailyTotalToFile(previousDate, dailyTotal, csvFilePath, dateFormat);
        //            }
        //        }

        //        Console.WriteLine("Done.");
        //        Console.ReadKey();
        //    }

        //    static void WriteDailyTotalToFile(DateTime date, double total, string filePath, string dateFormat)
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath, true))
        //        {
        //            string line = $"{date.ToString(dateFormat)}, {total:F2}";
        //            writer.WriteLine(line);
        //        }
        //    }
        //}
    }

 
    class Program2
    {

    //    static void Main(string[] args)
    //    {
    //        string productName = "apple";
    //        decimal maxPrice = 1.0m;

    //        Func<string, IEnumerable<Product>> getFilteredProducts = (path) =>
    //        {
    //            string json = File.ReadAllText(path);
    //            var products = JsonSerializer.Deserialize<List<Product>>(json);
    //            return products.Where(p => p.Name == productName && p.Price <= maxPrice);
    //        };

    //        Action<IEnumerable<Product>> printProducts = (products) =>
    //        {
    //            Console.WriteLine($"Filtered products with name '{productName}' and price <= {maxPrice}:");
    //            foreach (var product in products)
    //            {
    //                Console.WriteLine($"{product.Name} - {product.Price:C}");
    //            }
    //        };

    //        for (int i = 1; i <= 10; i++)
    //        {
    //            string path = $"products{i}.json";
    //            var filteredProducts = getFilteredProducts(path);
    //            printProducts(filteredProducts);
    //        }
    //    }

    //}
    //class Product
    //{
    //    public string Name { get; set; }
    //    public decimal Price { get; set; }
   }

    class Program3

    {
        
   
        
            public static void Third()
            {
                string path = "pictures";
                List<Bitmap> images = LoadImages(path);

                Func<Bitmap, Bitmap> operation1 = InvertColors;
                Func<Bitmap, Bitmap> operation2 = AddBorder;
                Action<Bitmap> displayImage = DisplayImage;

                foreach (Bitmap image in images)
                {
                    Bitmap result = operation1(image);
                    result = operation2(result);
                    displayImage(result);
                }
            }
            static List<Bitmap> LoadImages(string path)
            {
                List<Bitmap> images = new List<Bitmap>();
                List<string> files = Directory.GetFiles(path, "*.jpg").ToList();
                files.AddRange(Directory.GetFiles(path, "*.png"));
                foreach (string file in files)
                {
                    Bitmap image = new Bitmap(file);
                    images.Add(image);
                }
                return images;
            }
            static Bitmap InvertColors(Bitmap image)
            {
                Bitmap result = new Bitmap(image.Width, image.Height);
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color color = image.GetPixel(x, y);
                        int red = 255 - color.R;
                        int green = 255 - color.G;
                        int blue = 255 - color.B;
                        result.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
                return result;
            }
            static Bitmap AddBorder(Bitmap image)
            {
                Bitmap result = new Bitmap(image.Width + 10, image.Height + 10);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.FillRectangle(Brushes.White, 0, 0, result.Width, result.Height);
                    g.DrawImage(image, new Point(5, 5));
                }
                return result;
            }
            static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };

            public static void ConsoleWritePixel(Color cValue)
            {
                Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
                char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 }; // 1/4, 2/4, 3/4, 4/4
                int[] bestHit = new int[] { 0, 0, 4, int.MaxValue }; //ForeColor, BackColor, Symbol, Score

                for (int rChar = rList.Length; rChar > 0; rChar--)
                {
                    for (int cFore = 0; cFore < cTable.Length; cFore++)
                    {
                        for (int cBack = 0; cBack < cTable.Length; cBack++)
                        {
                            int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                            int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                            int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                            int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                            if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                            {
                                if (iScore < bestHit[3])
                                {
                                    bestHit[3] = iScore; //Score
                                    bestHit[0] = cFore;  //ForeColor
                                    bestHit[1] = cBack;  //BackColor
                                    bestHit[2] = rChar;  //Symbol
                                }
                            }
                        }
                    }
                }
                Console.ForegroundColor = (ConsoleColor)bestHit[0];
                Console.BackgroundColor = (ConsoleColor)bestHit[1];
                Console.Write(rList[bestHit[2] - 1]);
            }


            public static void DisplayImage(Bitmap source)
            {
                int sMax = 39;
                decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
                Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
                Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
                for (int i = 0; i < dSize.Height; i++)
                {
                    for (int j = 0; j < dSize.Width; j++)
                    {
                        ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                        ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                    }
                    System.Console.WriteLine();
                }
                Console.ResetColor();
            }
    }

    class Program4

    {

        static void Main(string[] args)
        {
            string[] files = { "file1.txt", "file2.txt", "file3.txt" };

            var tokenizeFunc = new Func<string, IEnumerable<string>>(Tokenize);
            var wordCountFunc = new Func<IEnumerable<string>, IDictionary<string, int>>(CountWords);
            var displayAction = new Action<IDictionary<string, int>>(DisplayWordCount);

            foreach (var file in files)
            {
                Console.WriteLine($"Processing file: {file}");

                var words = tokenizeFunc(File.ReadAllText(file));
                var wordCount = wordCountFunc(words);

                displayAction(wordCount);
            }
        }

        static IEnumerable<string> Tokenize(string text)
        {
            var separators = new[] { ' ', '\r', '\n', '\t', '.', ',', '!', '?', ':', ';' };

            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        static IDictionary<string, int> CountWords(IEnumerable<string> words)
        {
            var wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }

        static void DisplayWordCount(IDictionary<string, int> wordCount)
        {
            foreach (var pair in wordCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            Console.WriteLine();
        }
    }

}