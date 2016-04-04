Sobre a solução:
Foram implementados quatro testes. 
Três testes são o "problema 1" um para cada navegador (IE, Firefox e Chrome).
O outro teste é o teste desktop.
Os dados relacionados aos testes são armazenados na pasta "C:\Projeto". 
Para cada teste que é executado é criado uma pasta no formato <timestamp>_<nome_do_teste>. Dentro da pasta do teste são criados os arquivos relacionados aos testes (log e screenshot).

Teste desktop:
Foi implementado com o AutoIT. Foi criado um script (está no projeto do visual studio) e esse script foi compilado em um arquivo exe (utilizando a ferramenta SciTE). 
Esse exe é executado a partir do c#. Antes de executar o teste é criado um arquivo "fake.txt" que será utilizado para o teste. Após o teste esse arquivo é deletado.
O script, para confirmar que o texto foi inserido no arquivo ".doc", após o teste, reabre ele, lê o texto novamente e compara com o texto original do txt.
Para verificar se não ocorreu erros na execução do script, o c# lê o arquivo de log gerado pelo script e busca pela mensagem de sucesso. Caso não encontre a mensagem o teste não passa.

Melhorias:
Verificar se o texto foi inserido antes de tirar o print. No momento, como o script não sabe se o texto já foi inserido, ele aguarda 3 segundos para tirar o print.
Utilizar a DLL AutoITX3 para poder chamar os métodos que o script chama diretamente do c#.
Nos testes web, ler quais campos e quais valores devem ser inseridos de um arquivo xml ou json.
