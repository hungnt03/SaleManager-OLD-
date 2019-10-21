using BarcodeLib;
using SaleManager.WebApi.DataContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SaleManager.WebApi.Infrastructures
{
    public class BarcodeHelper
    {
        private SaleManagerEntities db = new SaleManagerEntities();
        public string GenerateBarcode()
        {
            Random random = new Random();
            var barcodeExisteds = db.Product.Select(s => s.Barcode).ToList();
            var id = string.Empty;
            var generated = false;
            while (!generated)
            {
                id = random.Next(11111111, 99999999).ToString();
                if (!barcodeExisteds.Contains(id))
                    generated = true;
            }
            GenerateBarcodeImg(id);
            return id;
        }

        public void GenerateBarcodeImg(string barcodeId)
        {
            string imageDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + "App_Data\\Images\\";
            Barcode barcode = new Barcode();
            //Color foreColor = Color.Black;
            //Color backColor = Color.Transparent;
            Image image = barcode.Encode(TYPE.CODE128, barcodeId);
            barcode.SaveImage(imageDir + barcodeId + ".jpg", SaveTypes.JPG);
        }
    }
}