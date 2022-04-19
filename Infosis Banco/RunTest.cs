using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Infosis_Banco
{
    public class RunTest
    {
        public RunTest() //construtor do path (.net 6.0)
        {

        }
        public static void Main(string[] args)
        {
            
            String path = @"C:\Users\Administrator\Desktop\Infosis Banco\Infosis Banco\worksheet.xlsx"; //setto o caminho
            ExcelPackage package = new(new System.IO.FileInfo(path)); //passando o caminho do arquivo (path) pra variavel package
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            int maxLine = workSheet.Dimension.End.Row; //busca a quantidade de linhas preenchidas no excel

            using (var connectionDb = new AppContext()) //instancia da classe AppContext (responsável por abrir e fechar a conexao com o dba)
            {
                for (int linha = 2; linha <= maxLine; linha++)
                {
                    
                    //buscando valores da tabela Office
                    var findOffice = connectionDb.Offices.FirstOrDefault(x => x.Type == workSheet.Cells[linha, 1].Value.ToString());
                    if (findOffice == null) //verifica se o valor (Type) é nulo, se for, ele preenche com os dados
                    {
                        var office = new Office();
                        office.Type = workSheet.Cells[linha, 1].Value.ToString();

                        //salvando valores no banco
                        connectionDb.Offices.Add(office);
                        connectionDb.SaveChanges();
                    }


                    //buscando valores da tabela ContractModality
                    var findContractModality = connectionDb.ContractModalitys.FirstOrDefault(x => x.Hour == int.Parse(workSheet.Cells[linha, 2].Value.ToString()) && x.Description == workSheet.Cells[linha, 3].Value.ToString());
                    if(findContractModality == null)
                    {
                        ContractModality modalityContract = new ContractModality();
                        modalityContract.Hour = int.Parse(workSheet.Cells[linha, 2].Value.ToString());
                        modalityContract.Description = workSheet.Cells[linha, 3].Value.ToString();

                        connectionDb.ContractModalitys.Add(modalityContract);
                        connectionDb.SaveChanges();
                    }

                    
                    var findNivel = connectionDb.Niveis.FirstOrDefault(x=> x.Type == workSheet.Cells[linha, 4].Value.ToString());
                    if(findNivel == null)
                    {
                        //buscando valores da tabela Nivel
                        Nivel nivel = new Nivel();
                        nivel.Type = workSheet.Cells[linha, 4].Value.ToString();

                        connectionDb.Niveis.Add(nivel);
                        connectionDb.SaveChanges();
                    }
                   

                    var auxBenefitType = connectionDb.BenefitTypes.FirstOrDefault(x => x.Description == workSheet.Cells[linha, 5].Value.ToString());
                    if(auxBenefitType == null)
                    {

                        //criando tipos de benefício
                        BenefitType benefitType = new BenefitType();
                        benefitType.Description = workSheet.Cells[linha, 5].Value.ToString();
                        benefitType.Value = decimal.Parse(workSheet.Cells[linha, 6].Value.ToString());
                        benefitType.PercentDefault = decimal.Parse(workSheet.Cells[linha, 7].Value.ToString());

                        connectionDb.BenefitTypes.Add(benefitType);
                        connectionDb.SaveChanges();
                    }


                    //CRIANDO MODALIDADE CARGO

                    //buscando o Id de cada entidade que encaixa na Modalidade Cargo (ModalityOffice)
                    var officeId = connectionDb.Offices.FirstOrDefault(x => x.Type == workSheet.Cells[linha, 1].Value.ToString()).Id;
                    var nivelId = connectionDb.Niveis.FirstOrDefault(x => x.Type == workSheet.Cells[linha, 4].Value.ToString()).Id;
                    var aux = connectionDb.ContractModalitys.Where(x => x.Hour == int.Parse(workSheet.Cells[linha, 2].Value.ToString()));
                    var contractModalityId = aux.FirstOrDefault(x => x.Description == workSheet.Cells[linha, 3].Value.ToString()).Id;

                    //atribuindo o valor de cada id para modalidade cargo
                    ModalityOffice modalityOffice = new ModalityOffice();
                    modalityOffice.OfficeId = officeId;
                    modalityOffice.NivelId = nivelId;
                    modalityOffice.ContractModalityId = contractModalityId;

                    connectionDb.ModalityOffices.Add(modalityOffice);
                    connectionDb.SaveChanges();


                    //pegando id de Modalidade Cargo para que possa se relacionar com a entidade Funcionário
                    var modalityOfficeId = connectionDb.ModalityOffices.FirstOrDefault(x => x.OfficeId == officeId && x.ContractModalityId == contractModalityId && x.NivelId == nivelId).Id;
                    var findEmployee = connectionDb.Employees.FirstOrDefault(x => x.CPF == long.Parse(workSheet.Cells[linha, 12].Value.ToString()));
                    if (findEmployee == null)
                    {
                        //criando funcionário
                        Employee employee = new Employee();
                        employee.Name = workSheet.Cells[linha, 8].Value.ToString();
                        employee.LastName = workSheet.Cells[linha, 9].Value.ToString();
                        employee.Address = workSheet.Cells[linha, 10].Value.ToString();
                        employee.Telephone = long.Parse(workSheet.Cells[linha, 11].Value.ToString());
                        employee.CPF = long.Parse(workSheet.Cells[linha, 12].Value.ToString());
                        employee.ModalityOfficeId = modalityOfficeId; //buscando o id da modalidade cargo para atribuir ao funcionário

                        connectionDb.Employees.Add(employee);
                        connectionDb.SaveChanges();
                    }

                    var benefitTypeId = connectionDb.BenefitTypes.FirstOrDefault(x => x.Description == workSheet.Cells[linha, 5].Value.ToString()).Id;

                    //criando beneficio
                    Benefit benefit = new Benefit();
                    benefit.BenefitTypeId = benefitTypeId;
                    benefit.NivelId = nivelId;

                    connectionDb.Benefits.Add(benefit);
                    connectionDb.SaveChanges();


                    var benefitId = connectionDb.Benefits.FirstOrDefault(x => x.BenefitTypeId == benefitTypeId && x.NivelId == nivelId).Id;
                    var employeeId = connectionDb.Employees.FirstOrDefault(x => x.CPF == long.Parse(workSheet.Cells[linha, 12].Value.ToString())).Id;
                    
                    var findDepositVerification = connectionDb.DepositVerifications.FirstOrDefault(x => x.Value == int.Parse(workSheet.Cells[linha, 13].Value.ToString()));
                    if(findDepositVerification == null)
                    {
                        //criando DepositVerification (depositoBeneficio)
                        DepositVerification depositVerification = new DepositVerification();
                        depositVerification.Value = int.Parse(workSheet.Cells[linha, 13].Value.ToString());
                        depositVerification.Matureness = Convert.ToDateTime(workSheet.Cells[linha, 14].Value.ToString());
                        depositVerification.BenefitId = benefitId;
                        depositVerification.EmployeeId = employeeId;

                    connectionDb.DepositVerifications.Add(depositVerification);
                    connectionDb.SaveChanges();
                    }


                        //criando deposito
                        //TIRAR DÚVIDA SOBRE A VERIFICAÇÃO 
                     var depositVerificationsId = connectionDb.DepositVerifications.FirstOrDefault(x => x.Value == decimal.Parse(workSheet.Cells[linha, 13].Value.ToString())).Id;
                        Deposit deposit = new Deposit();
                        deposit.DepositEmployeeValue = decimal.Parse(workSheet.Cells[linha, 15].Value.ToString()); 
                        deposit.Date = Convert.ToDateTime(workSheet.Cells[linha, 16].Value.ToString());
                        deposit.DepositVerificationId = depositVerificationsId; 

                        connectionDb.Deposits.Add(deposit);
                        connectionDb.SaveChanges();
  
                }
            }
        }
    }
}
