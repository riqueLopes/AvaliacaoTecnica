using System;

namespace CalculoCredito
{
    class Program
    {
        static void Main(string[] args)
        {
            ParametrosCredito pc = new ParametrosCredito();
            string entrada = string.Empty;
            decimal valorCredito = 0m;
            int tipoCredito = 0;
            int qtdParcela = 0;
            DateTime dtPrimeiroVen;

            // Valor Credito
            while (true)
            {
                Console.WriteLine("Informe o valor do crédito:");
                entrada = Console.ReadLine();

                if (!string.IsNullOrEmpty(entrada))
                {
                    bool success = decimal.TryParse(entrada, out valorCredito);
                    if (success)
                    {
                        pc.ValorCredito = Convert.ToDecimal(entrada);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor do crédito inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Valor do crédito não informado.");
                }

            }

            Console.WriteLine("\n");

            //Tipo crédito
            while (true)
            {
                Console.WriteLine("Informe o código do tipo de crédito:");
                Console.WriteLine("Cód - Tipo\n" +
                    "1 - Credito Direto.\n" +
                    "2 - Credito Consignado.\n" +
                    "3 - Credito Pessoa Jurídica.\n" +
                    "4 - Credito Pessoa Física.\n" +
                    "5 - Credito Imobiliário.\n");

                entrada = Console.ReadLine();

                if (!string.IsNullOrEmpty(entrada))
                {
                    bool success = int.TryParse(entrada, out tipoCredito);
                    if (success)
                    {
                        pc.TipoCredito = Convert.ToInt32(entrada);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tipo de crédito inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Tipo de crédito não informado.");
                }

            }
            Console.WriteLine("\n");

            //QtdParcela
            while (true)
            {
                Console.WriteLine("Informe quantidade de parcelas ( Quantidade de parcelas máximas é de 72x e a mínima é de 5x ) :");
                entrada = Console.ReadLine();

                if (!string.IsNullOrEmpty(entrada))
                {
                    bool success = int.TryParse(entrada, out qtdParcela);
                    if (success)
                    {
                        pc.QtdParcela = Convert.ToInt32(entrada);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de parcelas inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Quantidade de parcelas não informada.");
                }

            }

            Console.WriteLine("\n");

            //DtVencimento
            while (true)
            {
                Console.WriteLine("Informe a data do primeiro vencimento( Deve ser preenchido no formato DD/MM/AAAA ):");
                entrada = Console.ReadLine();

                if (!string.IsNullOrEmpty(entrada))
                {
                    bool success = DateTime.TryParse(entrada, out dtPrimeiroVen);
                    if (success)
                    {
                        pc.DtPrimeiroVen = Convert.ToDateTime(entrada);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Formato de data inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Data não informada.");
                }

            }

            //Chama metodo de calculo
            RulesCredito rc = new RulesCredito();
            Resultado result = rc.CalculaCredito(pc);

            Console.WriteLine("\n");
            //Mostra resultado
            if (result.Status)
            {
                Console.WriteLine("Status do crédito 'APROVADO'");
                Console.WriteLine(string.Format("Valor total com juros R${0}", result.VtTotalComJuros));
                Console.WriteLine(string.Format("Valor do juros R${0}", result.VlJuros));
            }

            else
            {
                Console.WriteLine("Status do crédito 'RECUSADO'.");
            }

            Console.ReadKey();
        }
    }
}
