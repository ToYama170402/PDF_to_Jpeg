using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using System.Drawing;

namespace PDFtoJpeg
{
    //変換するファイルのフルパス、DPI、形式を保持
    public struct convertFile {
        public string fileName;
        public int dpi;
        public string fileType;

        public convertFile(string fileName, int dpi, string fileType)
        {
            this.fileName = fileName;
            this.dpi = dpi;
            this.fileType = fileType;
        }
    }

    //デフォルトのDPI、ファイル形式保持
    public struct defaultSetting
    {
        public int dpi;
        public string fileType;
        public defaultSetting(int dpi,string fileType)
        {
            this.dpi = 600;
            this.fileType = "png";
        }
    }
    public class PDFtoJpeg
    {
        List<convertFile> convertFile = new List<convertFile>();
        defaultSetting defaultSetting;
        public void loadFile(List<convertFile> convertFiles)
        {
            convertFile = convertFiles;
        }
        public void loadDefault()
        {
            defaultSetting.dpi = 600;
            defaultSetting.fileType = "png";
        }
        public void addFile(string fileName, int dpi, string fileType)
        {
            convertFile.Add(new convertFile(fileName, dpi, fileType));
        }
        public void convbertAll()
        {
            int fileN = convertFile.Count;
            PdfDocument pdfDocument = new PdfDocument();
            for (int i = 0; i < fileN; i++)
            {
                pdfDocument.LoadFromFile(convertFile[i].fileName);
                int pageN = pdfDocument.Pages.Count;
                for (int j = 0; i < pageN; i++)
                {
                    Image image = pdfDocument.SaveAsImage(j);
                    int pageNumber = j + 1;
                    string path = convertFile[i].fileName + pageNumber + ".jpeg";
                    path = string.Format(path);
                    System.Drawing.Imaging.ImageFormat imageFormat;
                    if (convertFile[i].fileType != null)
                    {
                        imageFormat = switchImgFormat(convertFile[i].fileType);
                    }
                    else
                    {
                        imageFormat = switchImgFormat(defaultSetting.fileType);
                    }
                    image.Save(path, imageFormat);

                }
            }
        }
        private System.Drawing.Imaging.ImageFormat switchImgFormat(string fileType)
        {
            switch (fileType)
            {
                case "jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case "tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                default:
                    return System.Drawing.Imaging.ImageFormat.Png;

            }
        }
    }
}
