using Spire.Pdf;
using System.Collections.Generic;
using System.Drawing;

namespace ConvertPDF
{
    //変換するファイルのフルパス、形式を保持
    public struct ConvertFile
    {
        public string fileName;
        public string fileType;

        public ConvertFile(string fileName, string fileType)
        {
            this.fileName = fileName;
            this.fileType = fileType;
        }
    }

    //デフォルトのファイル形式保持
    public struct DefaultSetting
    {
        public string fileType;
        public DefaultSetting(string fileType)
        {
            this.fileType = fileType;
        }
    }
    public class ConvertPDF
    {
        public List<ConvertFile> convertFile = new();
        public DefaultSetting defaultSetting;
        public void LoadFile(List<ConvertFile> convertFiles)
        {
            convertFile = convertFiles;
        }

        public void LoadDefault(string fileType)
        {
            defaultSetting.fileType = fileType;
        }
        public void AddFile(string fileName, string fileType)
        {
            convertFile.Add(new ConvertFile(fileName, fileType));
        }
        public void AddFile(string fileName)
        {
            convertFile.Add(new ConvertFile(fileName, defaultSetting.fileType));
        }
        public void ConvertAll()
        {
            PdfDocument pdfDocument = new();

            foreach (ConvertFile converts in convertFile)
            {
                pdfDocument.LoadFromFile(converts.fileName);
                int pageN = pdfDocument.Pages.Count;
                for (int j = 0; j < pageN; j++)
                {
                    Image image = pdfDocument.SaveAsImage(j);
                    int pageNumber = j + 1;
                    string path = converts.fileName + pageNumber + "." + converts.fileType;
                    path = string.Format(path);
                    System.Drawing.Imaging.ImageFormat imageFormat;
                    if (converts.fileType != null)
                    {
                        imageFormat = SwitchImgFormat(converts.fileType);
                    }
                    else
                    {
                        imageFormat = SwitchImgFormat(defaultSetting.fileType);
                    }
                    image.Save(path, imageFormat);

                }
            }
        }
        private static System.Drawing.Imaging.ImageFormat SwitchImgFormat(string fileType)
        {
            return fileType switch
            {
                "jpeg" => System.Drawing.Imaging.ImageFormat.Jpeg,
                "png" => System.Drawing.Imaging.ImageFormat.Png,
                "bmp" => System.Drawing.Imaging.ImageFormat.Bmp,
                "gif" => System.Drawing.Imaging.ImageFormat.Gif,
                "tiff" => System.Drawing.Imaging.ImageFormat.Tiff,
                _ => System.Drawing.Imaging.ImageFormat.Png,
            };
        }
    }
}
