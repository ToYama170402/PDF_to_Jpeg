using System;
using Spire.Pdf;
using System.Drawing;
using System.IO;

namespace ConvertPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertPDF pdfto = new ConvertPDF();
            bool boolFile = false;
            //コマンドライン引数解析
            int i = 0;
            foreach (string str in args)
            {
                if (File.Exists(str))
                {
                    boolFile = true;
                    string individualFileName = str;
                    int individualDPI = 600;
                    string individualFileType = "png";
                    for (int j = 0; j < 5; j++)
                    {
                        int k = i + j;
                        if (args.Length > k)
                        {
                            switch (args[k])
                            {
                                case "-dpi":
                                    int.TryParse(args[k + 1], out individualDPI);
                                    break;
                                case "-to":
                                    individualFileType = args[k + 1];
                                    break;
                            }
                        }

                    }
                    pdfto.addFile(individualFileName, individualDPI, individualFileType);

                }
                else if (boolFile == false)
                {
                    switch (args[i])
                    {
                        case "-dpi":
                            int localDPI;
                            int.TryParse(args[i++], out localDPI);
                            pdfto.loadDefault(localDPI);
                            break;
                        case "-to":
                            pdfto.loadDefault(args[i++]);
                            break;
                    }
                }
                i++;
            }
            pdfto.convertAll();
        }
    }
}
