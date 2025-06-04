using System.Globalization;

namespace DesafioFundamentos.Models
{
    /// <summary>
    /// Classe de gerenciamento do estacionamento.
    /// </summary>
    public class Estacionamento
    {
        private decimal _precoInicial;
        private decimal _precoPorHora;
        private List<Veiculo> _veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Adiciona o veículo na lista do estacionamento.
        /// </summary>
        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine(" ");
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();
            Console.Write("Digite a hora de entrada (HH:mm): ");
            string dataEntrada = Console.ReadLine();
            DateTime.TryParseExact(dataEntrada,
                "HH:mm", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out DateTime data);

            if(data == default)
            {
                Console.WriteLine("Hora de entrada inválida. Por favor, use o formato HH:mm.");
                return;
            }
            
            Veiculo novoVeiculo = new Veiculo(placa, data);
            _veiculos.Add(novoVeiculo);
        }

        /// <summary>
        /// Valida se o veículo existe e o remove da lista, calculando o valor total a ser pago.
        /// </summary>
        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            Veiculo veiculoParaRemover = _veiculos.Where(x => x.Placa == placa).FirstOrDefault();
            // Verifica se o veículo existe
            if (veiculoParaRemover.Placa != string.Empty)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = _precoInicial + _precoPorHora * horas; 

                // TODO: Remover a placa digitada da lista de veículos
                
                _veiculos.Remove(veiculoParaRemover);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        /// <summary>
        /// Lista todos os carros que estão estacionados no estacionamento.
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                for(int i = 0 ; i < _veiculos.Count; i++)
                {
                    Console.WriteLine($"Posição: {i+1} | Placa: {_veiculos[i].Placa}, Data de Entrada: {_veiculos[i].DataEntrada.ToString("HH:mm")}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
