using System;

namespace DIO_Bank
{
    public class Conta
    {   
        private TipoConta TipoConta { get; set;}
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        // metodo construtor dentro da Classe de msm nome
        public Conta (TipoConta tipo_conta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipo_conta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool SacarFundos (double valor_saque)
        {   //  validar Saque
            if ( valor_saque > this.Saldo + this.Credito ) {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }   
            else
            {
                this.Saldo = this.Saldo - valor_saque;
                //  this.Saldo -= valor_saque;
                Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
                return true;
            }
        }
        public void DepositarFundos (double valor_deposito)
        {
            this.Saldo = this.Saldo + valor_deposito;
            //  this.Saldo += valor_deposito;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }
        public void TransferirFundos (double valor_transferencia, Conta conta_destino)
        {
            if ( this.SacarFundos(valor_transferencia) ) {
                conta_destino.DepositarFundos(valor_transferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += $"Tipo Conta: {this.TipoConta} | ";
            retorno += $"Nome: {this.Nome} | ";
            retorno += $"Saldo: {this.Saldo} | ";
            retorno += $"Crédito: {this.Credito}";
            return retorno;
        }
    }
}