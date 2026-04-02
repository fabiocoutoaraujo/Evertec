# Repositório destinado ao live coding realizado dia 27 de março.

## Como rodar o projeto.

- Clonar o repositório com o comando ``git clone https://github.com/fabiocoutoaraujo/Evertec``

- Acessar o diretório ``cd Evertec\FCA``

- Abrir e executar a solução no Visual Studion ``FCA.slnx`` e pressionar F5

- A solução utiliza o EntityFrameworkCore.InMemory então não há necessidade de configurações adicionais

- Os endpoints estão devidamente documentados e com exemplos de payload para execução. 

## Estrutura e decisões de arquitetura.

- Em breve...

## Pontos que poderiam ser melhorados em uma aplicação real.

- Implementar CancelationToken entre chamadas assíncronas, evitando desperdício de recursos (CPU e Memória) caso a operação seja cancelada;

- Implementar o Result Pattern como alternativa ao uso de exceções no controle de fluxo das regras de negócio;

- Evoluir a implementação dos DTOs (Data Transfer Objects), alterando os parâmetros para uma estrutura de objetos imutáveis (Records);

## SQL(Tabelas,Inserts,Selects)
