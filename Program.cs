using System.IO;

namespace ConvertPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertPDF pdfto = new();
            bool boolFile = false;
            //コマンドライン引数解析
            int i = 0;
            foreach (string str in args)
            {
                if (File.Exists(str))
                {
                    boolFile = true;
                    string individualFileName = str;
                    string individualFileType = "png";
                    for (int j = 0; j < 5; j++)
                    {
                        int k = i + j;
                        if (args.Length > k)
                        {
                            switch (args[k])
                            {
                                case "-to":
                                    individualFileType = args[k + 1];
                                    break;
                            }
                        }

                    }
                    pdfto.AddFile(individualFileName, individualFileType);

                }
                else if (boolFile == false)
                {
                    switch (args[i])
                    {
                        case "-to":
                            pdfto.LoadDefault(args[i++]);
                            break;
                    }
                }
                i++;
            }
            pdfto.ConvertAll();
        }
    }
}
