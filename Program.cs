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
            //コマンドライン引数解析
            int i = 0;
            foreach (string str in args)
            {
                bool boolFile = false;

                if (File.Exists(str))
                {
                    boolFile = true;
                    string individualFileName = str;
                    int individualDPI;
                    string individualFileType;
                    for (int j = 0; j < 5; i++)
                    {
                        int k = i + j;
                        switch (args[k])
                        {
                            case "-dpi":
                                int.TryParse(args[k++], out individualDPI);
                                break;
                            case "-to":
                                individualFileType = args[k++];
                                break;
                        }
                    }
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
