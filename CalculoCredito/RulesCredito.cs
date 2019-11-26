using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCredito
{
    public class RulesCredito
    {
        public Resultado CalculaCredito(ParametrosCredito pc)
        {
            Resultado result = new Resultado();
            decimal txJuros = 0;
            bool ok = ValidaEntrada(pc);

            if (ok)
            {
                switch (pc.TipoCredito)
                {
                    case (int)TipoCredito.CreditoDireto:
                        {
                            txJuros = 2;
                            break;
                        }
                    case (int)TipoCredito.CreditoConsignado:
                        {
                            txJuros = 1;
                            break;
                        }
                    case (int)TipoCredito.CreditoPessoaJuridica:
                        {
                            txJuros = 5;
                            break;
                        }

                    case (int)TipoCredito.CreditoPessoaFisica:
                        {
                            txJuros = 3;
                            break;
                        }
                    case (int)TipoCredito.CreditoImobiliario:
                        {
                            txJuros = (9 / 12);
                            break;
                        }
                }
                /*Para este exercício, os juros são calculados da seguinte forma, incremente a porcentagem de juros no valor total do crédito.*/
                var juros = (pc.ValorCredito * (pc.QtdParcela * txJuros) / 100);
                //var juros = (pc.ValorCredito * txJuros / 100);

                result.VtTotalComJuros = pc.ValorCredito + juros;
                result.VlJuros = (decimal)juros;
                result.Status = true;
            }


            return result;
        }

        private bool ValidaEntrada(ParametrosCredito pc)
        {
            DateTime dtAtualMinino = DateTime.Now.AddDays(15);
            DateTime dtAtualMaximo = DateTime.Now.AddDays(40);

            if (pc.ValorCredito > 1000000)
                return false;

            if (pc.QtdParcela > 72 || pc.QtdParcela < 5)
                return false;

            if ((int)TipoCredito.CreditoPessoaJuridica == pc.TipoCredito && pc.ValorCredito < 15000)
                return false;

            if (pc.DtPrimeiroVen < dtAtualMinino || pc.DtPrimeiroVen > dtAtualMaximo)
                return false;

            return true;
        }
    }
}
