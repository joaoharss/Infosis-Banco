//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OfficeOpenXml;
//using Infosis_Banco;

////baixar .net 6.0 para fazer migrations 
////comando "dotnet tool install --global dotnet-ef --version 6.0"   



//namespace Infosis_Banco
//{
//    internal class Run
//    {
//        public static void Main(string[] args)
//        {
//            //mostrar o caminho da planilha
//            FileInfo worksheetPath = new FileInfo(@"Desktop\Pasta1.xlsx"); //caminho 
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//            using (ExcelPackage package = new ExcelPackage(worksheetPath)) //using para trabalhar com o arquivo em si
//            {
//                //especifica a planilha a ser usada
//                var folha = package.Workbook.Worksheets[0];
//                Console.WriteLine(folha.GetValue(1, 1).ToString());
//                //ExcelWorksheet folha = new ExcelWorksheet();


//               //int maxLine = folha.Dimension.End.Row; //busca a quantidade maxima de linhas do Excel pra tratar no loop

//                //using(var connectionDb = new AppContext()) //a instancia da classe AppContext é responsável por abrir e fechar a conexão com o banco
//                //{
//                //   for(int linha = 1; linha <= maxLine; linha++)
//                //    {
//                //        var office = new Office();
//                //        office.Type = folha.Cells[linha, 2].Value.ToString();
//                //        Console.WriteLine(office.Type);

//                //        //salvando banco
//                //        connectionDb.Offices.Add(office);
//                //        connectionDb.SaveChanges();

//                //    }
//                //}
//            }
//        }
//    }
//}

