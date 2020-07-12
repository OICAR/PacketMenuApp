using ExcelService.Models;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelService.Utils
{
    public static class Utilities
    {


        private static char _DELIMITER = ',';
        private static Item _temp;
        private static List<Item> _tempList;
        //public static Tuple<List<string>, List<string>> ReturnMultipleList(int[] array, int number)
        //{
        //    return Tuple.Create(list1, list2);
        //}




        public static List<Item> CreateItem (Caterer model)
        {

            _tempList = new List<Item>();
            _temp = new Item();
            string json = null;

            var stream2 = new MemoryStream(model.Document);

            IFormFile file = new FormFile(stream2, 0, model.Document.Length, "name", "filename.xlsx");


            string folderName = "UploadExcel";

            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            List<string> ItemLista = new List<string>();
            List<string> IngredientsLista = new List<string>();
            if (file.Length > 0)
            {

                ISheet sheet;


                using (var stream = file.OpenReadStream())
                {

                    //json = ReadExcelasJSON(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;

                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;

                    }

                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == NPOI.SS.UserModel.CellType.Blank)) continue;
                        for (int celNumber = row.FirstCellNum; celNumber < cellCount; celNumber++)
                        {
                            if (row.GetCell(celNumber) != null)
                            {
                                var data = row.GetCell(celNumber).ToString();


                                switch (celNumber)
                                {

                                    case 0:

                                        _temp.Name = data;
                                        break;
                                    case 1:
                                        _temp.Price =int.Parse(data);

                                        break;
                                    case 2:
                                        _temp.Ingredents = parseToList(data, _DELIMITER);
                                        break;
                                    default:
                                        return null;
                                }



                            }

                        }

                        _tempList.Add(_temp);

                    }

                }

            }
            return _tempList;
        }



        private static List<string> parseToList(string data, char DELIMITER)

        {

            List<string> result = data.Split(DELIMITER).ToList();

            return result;
        }



    }


}

