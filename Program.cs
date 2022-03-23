using System;
using Spire.Xls;
using Spire.Pdf;
using System.Drawing;

namespace PDF_to_Jpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument doc = new PdfDocument();
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("ファイルパス:" + args[i]);

                //PDFファイルをロードします。
                Console.WriteLine("ファイルを読み込み中");
                doc.LoadFromFile(args[i]);

                //総ページ数をカウント
                int allPageNumber = doc.Pages.Count;
                Console.WriteLine("総ページ数" + allPageNumber + "ページ");

                //各ページを Jpegとして保存
                Console.WriteLine("Jpegに変換中");
                for (int j = 0; j < allPageNumber; j++)
                {
                    Image bmp = doc.SaveAsImage(j);
                    int pagenumber = j + 1;
                    string jpgpath = args[i] + pagenumber + ".jpeg";
                    string fileName = string.Format(jpgpath);
                    bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}
