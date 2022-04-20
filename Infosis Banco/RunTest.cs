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
                    var buscaCargo = connectionDb.Cargos.FirstOrDefault(x => x.Tipo == workSheet.Cells[linha, 1].Value.ToString());
                    if (buscaCargo == null) //verifica se o valor (Type) é nulo, se for, ele preenche com os dados
                    {
                        var cargo = new Cargo();
                        cargo.Tipo = workSheet.Cells[linha, 1].Value.ToString();

                        //salvando valores no banco
                        connectionDb.Cargos.Add(cargo);
                        connectionDb.SaveChanges();
                    }


                    //buscando valores da tabela ContractModality
                    var buscaModalidadeContrato = connectionDb.ModalidadeContratos.FirstOrDefault(x => x.Hora == int.Parse(workSheet.Cells[linha, 2].Value.ToString()) && x.Descricao == workSheet.Cells[linha, 3].Value.ToString());
                    if(buscaModalidadeContrato == null)
                    {
                        ModalidadeContrato modalidadeContrato = new ModalidadeContrato();
                        modalidadeContrato.Hora = int.Parse(workSheet.Cells[linha, 2].Value.ToString());
                        modalidadeContrato.Descricao = workSheet.Cells[linha, 3].Value.ToString();

                        connectionDb.ModalidadeContratos.Add(modalidadeContrato);
                        connectionDb.SaveChanges();
                    }

                    
                    var buscaNivel = connectionDb.Niveis.FirstOrDefault(x=> x.Tipo == workSheet.Cells[linha, 4].Value.ToString());
                    if(buscaNivel == null)
                    {
                        //buscando valores da tabela Nivel
                        Nivel nivel = new Nivel();
                        nivel.Tipo = workSheet.Cells[linha, 4].Value.ToString();

                        connectionDb.Niveis.Add(nivel);
                        connectionDb.SaveChanges();
                    }
                   

                    var auxTipoBeneficio = connectionDb.TipoBeneficios.FirstOrDefault(x => x.Descricao == workSheet.Cells[linha, 5].Value.ToString());
                    if(auxTipoBeneficio == null)
                    {

                        //criando tipos de benefício
                        TipoBeneficio tipoBeneficio = new TipoBeneficio();
                        tipoBeneficio.Descricao = workSheet.Cells[linha, 5].Value.ToString();
                        tipoBeneficio.ValorTipoBeneficio = decimal.Parse(workSheet.Cells[linha, 6].Value.ToString());
                        tipoBeneficio.PorcentagemPadrao = decimal.Parse(workSheet.Cells[linha, 7].Value.ToString());

                        connectionDb.TipoBeneficios.Add(tipoBeneficio);
                        connectionDb.SaveChanges();
                    }


                    //CRIANDO MODALIDADE CARGO

                    //buscando o Id de cada entidade que encaixa na Modalidade Cargo (ModalityOffice)
                    var cargoId = connectionDb.Cargos.FirstOrDefault(x => x.Tipo == workSheet.Cells[linha, 1].Value.ToString()).Id;
                    var nivelId = connectionDb.Niveis.FirstOrDefault(x => x.Tipo == workSheet.Cells[linha, 4].Value.ToString()).Id;
                    var auxHoraModalidadeCargo = connectionDb.ModalidadeContratos.Where(x => x.Hora == int.Parse(workSheet.Cells[linha, 2].Value.ToString()));
                    var modalidadeContratoId = auxHoraModalidadeCargo.FirstOrDefault(x => x.Descricao == workSheet.Cells[linha, 3].Value.ToString()).Id;

                    //atribuindo o valor de cada id para modalidade cargo
                    ModalidadeCargo modalidadeCargo = new ModalidadeCargo();
                    modalidadeCargo.CargoId = cargoId;
                    modalidadeCargo.NivelId = nivelId;
                    modalidadeCargo.ModalidadeContratoId = modalidadeContratoId;

                    connectionDb.ModalidadeCargos.Add(modalidadeCargo);
                    connectionDb.SaveChanges();


                    //pegando id de Modalidade Cargo para que possa se relacionar com a entidade Funcionário
                    var modalidadeCargoId = connectionDb.ModalidadeCargos.FirstOrDefault(x => x.CargoId == cargoId && x.ModalidadeContratoId == modalidadeContratoId && x.NivelId == nivelId).Id;
                    var buscaFuncionario = connectionDb.Funcionarios.FirstOrDefault(x => x.CPF == long.Parse(workSheet.Cells[linha, 12].Value.ToString()));
                    if (buscaFuncionario == null)
                    {
                        //criando funcionário
                        Funcionario funcionario = new Funcionario();
                        funcionario.Nome = workSheet.Cells[linha, 8].Value.ToString();
                        funcionario.Sobrenome = workSheet.Cells[linha, 9].Value.ToString();
                        funcionario.Endereco = workSheet.Cells[linha, 10].Value.ToString();
                        funcionario.Telefone = long.Parse(workSheet.Cells[linha, 11].Value.ToString());
                        funcionario.CPF = long.Parse(workSheet.Cells[linha, 12].Value.ToString());
                        funcionario.ModalidadeCargoId = modalidadeCargoId; //buscando o id da modalidade cargo para atribuir ao funcionário

                        connectionDb.Funcionarios.Add(funcionario);
                        connectionDb.SaveChanges();
                    }

                    var tipoBeneficioId = connectionDb.TipoBeneficios.FirstOrDefault(x => x.Descricao == workSheet.Cells[linha, 5].Value.ToString()).Id;

                    //criando beneficio
                    Beneficio beneficio = new Beneficio();
                    beneficio.TipoBeneficioId = tipoBeneficioId;
                    beneficio.NivelId = nivelId;

                    connectionDb.Beneficios.Add(beneficio);
                    connectionDb.SaveChanges();


                    var beneficioId = connectionDb.Beneficios.FirstOrDefault(x => x.TipoBeneficioId == tipoBeneficioId && x.NivelId == nivelId).Id;
                    var funcionarioId = connectionDb.Funcionarios.FirstOrDefault(x => x.CPF == long.Parse(workSheet.Cells[linha, 12].Value.ToString())).Id;
                    
                    var buscaDepositoBeneficio = connectionDb.DepositoBeneficios.FirstOrDefault(x => x.ValorDepositoBeneficio == int.Parse(workSheet.Cells[linha, 13].Value.ToString()));
                    if(buscaDepositoBeneficio == null)
                    {
                        //criando DepositVerification (depositoBeneficio)
                        DepositoBeneficio depositoBeneficio = new DepositoBeneficio();
                        depositoBeneficio.ValorDepositoBeneficio = int.Parse(workSheet.Cells[linha, 13].Value.ToString());
                        depositoBeneficio.Vencimento = Convert.ToDateTime(workSheet.Cells[linha, 14].Value.ToString());
                        depositoBeneficio.BeneficioId = beneficioId;
                        depositoBeneficio.FuncionarioId = funcionarioId;

                    connectionDb.DepositoBeneficios.Add(depositoBeneficio);
                    connectionDb.SaveChanges();
                    }


                        //criando deposito
                        //TIRAR DÚVIDA SOBRE A VERIFICAÇÃO 
                        var depositoBeneficioId = connectionDb.DepositoBeneficios.FirstOrDefault(x => x.ValorDepositoBeneficio == decimal.Parse(workSheet.Cells[linha, 13].Value.ToString())).Id;
                        Deposito deposito = new Deposito();
                        deposito.ValorDepositoFuncionario = decimal.Parse(workSheet.Cells[linha, 15].Value.ToString());
                        deposito.Data = Convert.ToDateTime(workSheet.Cells[linha, 16].Value.ToString());
                        deposito.DepositoBeneficioId = depositoBeneficioId; 

                        connectionDb.Depositos.Add(deposito);
                        connectionDb.SaveChanges();
  
                }
            }
        }
    }
}
