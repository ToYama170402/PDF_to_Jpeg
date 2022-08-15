﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using System.Drawing;

namespace ConvertPDF
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
    public class ConvertPDF
    {
        public List<convertFile> convertFile = new List<convertFile>();
        public defaultSetting defaultSetting;
        public void loadFile(List<convertFile> convertFiles)
        {
            convertFile = convertFiles;
        }

        public void loadDefault(int dpi)
        {
            defaultSetting.dpi = dpi;
        }

        public void loadDefault(string fileType)
        {
            defaultSetting.fileType = fileType;
        }
        public void loadDefault(int dpi, string fileType)
        {
            defaultSetting.dpi = dpi;
            defaultSetting.fileType = fileType;
        }
        public void addFile(string fileName, int dpi, string fileType)
        {
            convertFile.Add(new convertFile(fileName, dpi, fileType));
        }
        public void addFile(string fileName)
        {
            convertFile.Add(new convertFile(fileName, defaultSetting.dpi, defaultSetting.fileType));
        }
        public void addFile(string fileName, int dpi)
        {
            convertFile.Add(new convertFile(fileName, dpi, defaultSetting.fileType));
        }
        public void addFile(string fileName, string fileType)
        {
            convertFile.Add(new convertFile(fileName, defaultSetting.dpi, fileType));
        }
        public void convertAll()
        {
            int fileN = convertFile.Count;
            PdfDocument pdfDocument = new PdfDocument();

            foreach (convertFile converts in convertFile)
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
                        imageFormat = switchImgFormat(converts.fileType);
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
