namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        // O List<string> é adequado para armazenar apenas as placas
        private List<string> veiculos = new List<string>(); 

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (!string.IsNullOrWhiteSpace(placa) && !veiculos.Contains(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"\n✅ Veículo com placa **{placa}** estacionado com sucesso!");
            }
            else if (veiculos.Contains(placa))
            {
                Console.WriteLine($"\n⚠️ O veículo com a placa **{placa}** já está estacionado.");
            }
            else
            {
                Console.WriteLine("\n❌ Placa inválida. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal 
                // *IMPLEMENTE AQUI*
                
                // Tenta ler e converter a quantidade de horas
                if (!int.TryParse(Console.ReadLine(), out int horas))
                {
                    Console.WriteLine("\n❌ Quantidade de horas inválida.");
                    return; // Sai do método se a leitura falhar
                }
                
                // Garante que o mínimo de horas é 1
                horas = Math.Max(1, horas);
                
                // Cálculo: A primeira hora é o precoInicial, as demais (horas - 1) são cobradas por precoPorHora
                decimal valorTotal = precoInicial + (precoPorHora * (horas - 1));

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);

                Console.WriteLine($"\n✅ O veículo **{placa}** foi removido e o preço total foi de: R$ **{valorTotal:N2}**");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("\n========================");
                Console.WriteLine("  VEÍCULOS ESTACIONADOS");
                Console.WriteLine("========================");
                
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                int contador = 1;
                foreach (string placa in veiculos)
                {
                    Console.WriteLine($"{contador}º - Placa: **{placa}**");
                    contador++;
                }
                Console.WriteLine($"\nTotal de veículos: **{veiculos.Count}**");
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}