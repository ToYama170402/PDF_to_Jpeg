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

            Console.WriteLine("ファイルパス:" + args[0]);
            Console.WriteLine("ファイルを読み込み中");
            //PDFファイルをロードします。
            doc.LoadFromFile(args[0]);

            //総ページ数をカウント
            int allPageNumber = doc.Pages.Count;
            Console.WriteLine("総ページ数" + allPageNumber + "ページ");

            Console.WriteLine("Jpegに変換中");
            //各ページを Jpegとして保存
            for (int i = 0; i < allPageNumber; i++)
            {
                Image bmp = doc.SaveAsImage(i);
                int pagenumber = i + 1;
                string jpgpath = args[0] + pagenumber + ".jpeg";
                string fileName = string.Format(jpgpath);
                bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }
    }
}
