using GrupoCiencias.Intranet.Application.Interfaces.Util;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Util
{
    public class WebUtilApplication : IWebUtilApplication
    { 

        public async Task<byte[]> ExportDataToExcelFormatAsync(DataTable sourceTable)
        {
            var workbook = new HSSFWorkbook();
            var memoryStream = new MemoryStream();
            var sheet = (HSSFSheet)workbook.CreateSheet("Reporte");
            var headerRow = (HSSFRow)sheet.CreateRow(7);
            int rowIndex = 8;

            // DocumentSummaryInformation
            var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "Grupo Ciencias";
            workbook.DocumentSummaryInformation = dsi;

            // SummaryInformation
            var information = PropertySetFactory.CreateSummaryInformation();
            information.Subject = "Grupo Ciencias";
            information.Author = "Grupo Ciencias";
            information.ApplicationName = "Reporte de Alumnos Matriculados";

            // Logo
            //HSSFPatriarch patriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch;
            //HSSFClientAnchor anchor = new HSSFClientAnchor(100, 255, 0, 0, 0, 0, 1, 6);
            //anchor.AnchorType = 2;

            var patriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch();
            var anchor = new HSSFClientAnchor(255, 255, 255, 200, 0, 0, 0, 255);
            anchor.AnchorType = (AnchorType)2;


            //string dirPicture = HttpContext.Current.Server.MapPath("~") + @"\Imagenes\everisbpo.jpg";
            //HSSFPicture picture = patriarch.CreatePicture(anchor, LoadImageExcel(dirPicture, workbook));

            //string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", "grupo_ciencias_FE001.png");

            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images" , "grupo_ciencias_FE001.png");

            HSSFPicture img = (HSSFPicture)patriarch.CreatePicture(anchor, LoadImageExcel(pathFile, workbook));
          
            // Estilos Cabecera
            IFont fontHeaders = workbook.CreateFont();
            {
                var withBlock = fontHeaders;
                withBlock.Color = HSSFColor.White.Index;
                withBlock.Boldweight = (short)FontBoldWeight.Bold;
                withBlock.FontName = "Arial";
                withBlock.FontHeightInPoints = 10;
            }
             

            HSSFColor color = setColor(workbook, Convert.ToByte(69), Convert.ToByte(77), Convert.ToByte(85));
            
            ICellStyle styleHeader = workbook.CreateCellStyle();
            
            var withstyleHeader = styleHeader;

            withstyleHeader.SetFont(fontHeaders);
            withstyleHeader.Alignment = HorizontalAlignment.Center;
            withstyleHeader.BorderRight = BorderStyle.Thin;
            withstyleHeader.BorderBottom = BorderStyle.Thin;
            withstyleHeader.BorderLeft = BorderStyle.Thin;
            withstyleHeader.BorderTop = BorderStyle.Thin;
            withstyleHeader.FillForegroundColor = HSSFColor.Grey80Percent.Index;
            withstyleHeader.FillPattern = FillPattern.SolidForeground;


            // Cabecera
            foreach (DataColumn column in sourceTable.Columns)
            {
                {
                    var withBlock = headerRow.CreateCell(column.Ordinal);
                    withBlock.SetCellValue(column.Caption);
                    withBlock.CellStyle = styleHeader;
                }
            }

            headerRow.HeightInPoints = 15;

            // Estilo Filas
            ICellStyle styleRows = workbook.CreateCellStyle();
            {
                var withBlock = styleRows;
                withBlock.Alignment = HorizontalAlignment.Center;
                withBlock.BorderRight = BorderStyle.Thin;
                withBlock.BorderBottom = BorderStyle.Thin;
                withBlock.BorderLeft = BorderStyle.Thin;
                withBlock.BorderTop = BorderStyle.Thin;
            }

            // Data
            foreach (DataRow row in sourceTable.Rows)
            {
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);

                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());

                    dataRow.GetCell(column.Ordinal).CellStyle = styleRows;
                }
                rowIndex += 1;
            }

            // Autosize
            for (int i = 0; i <= headerRow.LastCellNum; i++)
                sheet.AutoSizeColumn(i);

            sheet.DisplayGridlines = false;
            sheet.FitToPage = false;
            workbook.Write(memoryStream);
            byte[] ba = memoryStream.ToArray();
            memoryStream.Flush();

            return ba;
        }

        public static int LoadImageExcel(string path, HSSFWorkbook workbook)
        {
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);

            byte[] buffer = new byte[file.Length];

            file.Read(buffer, 0, Convert.ToInt32(file.Length));

            return workbook.AddPicture(buffer, PictureType.PNG);
        }

        private static HSSFColor setColor(HSSFWorkbook workbook, byte r, byte g, byte b)
        {
            HSSFPalette palette = workbook.GetCustomPalette();
            HSSFColor color = null;
            color = palette.FindColor(r, g, b);
            try
            { 
                if (color == null)
                {
                    palette.SetColorAtIndex(HSSFColor.Green.Index, r, g, b);
                    color = palette.GetColor(HSSFColor.Green.Index);
                }
                return color;
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public async Task<DataTable> ConvertToAsync<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            DataRow rowMaster = table.NewRow();
            foreach (T item in list)
            {
                 
                rowMaster = table.NewRow();
                SetDataColumn<T>(rowMaster, item);

                table.Rows.Add(rowMaster);
            }
            return table;
        }
         
        private static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            AddRowCount(table);

            //Cargamos los metadatos de las propiedades del objeto principal al datatable
            GetProperties(table, properties);

            return table;
        }

        private static void SetDataColumn<T>(DataRow rowMaster, T item)
        {
            foreach (PropertyDescriptor prop in GetProperties<T>())
            {
                if (prop.Name != "IdReporte")
                {
                    rowMaster[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

            }
        }

        private static PropertyDescriptorCollection GetProperties<T>()
        {
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            return properties;
        }

        private static void GetProperties(DataTable table, PropertyDescriptorCollection properties)
        {
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.Name != "IdReporte")
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                                       prop.PropertyType) ?? prop.PropertyType);
                } 
            }
        }

        private static void AddRowCount(DataTable table)
        {
            //Id
            DataColumn dtc = new DataColumn();
            dtc.AutoIncrement = true;
            dtc.ColumnName = "N°"; 
            table.Columns.Add(dtc);

        }
    }
}
