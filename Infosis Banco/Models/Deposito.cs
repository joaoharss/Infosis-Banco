﻿namespace Infosis_Banco
{
    public class Deposito
    {
        public int Id { get; set; }
        public decimal ValorDepositoFuncionario { get; set; }
        public DateTime Data { get; set; }
        public DepositoBeneficio DepositoBeneficio { get; set; }
        public int DepositoBeneficioId { get; set; }
      
    }
}