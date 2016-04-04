Sobre a solu��o:
Foram implementados quatro testes. 
Tr�s testes s�o o "problema 1" um para cada navegador (IE, Firefox e Chrome).
O outro teste � o teste desktop.
Os dados relacionados aos testes s�o armazenados na pasta "C:\Projeto". 
Para cada teste que � executado � criado uma pasta no formato <timestamp>_<nome_do_teste>. Dentro da pasta do teste s�o criados os arquivos relacionados aos testes (log e screenshot).

Teste desktop:
Foi implementado com o AutoIT. Foi criado um script (est� no projeto do visual studio) e esse script foi compilado em um arquivo exe (utilizando a ferramenta SciTE). 
Esse exe � executado a partir do c#. Antes de executar o teste � criado um arquivo "fake.txt" que ser� utilizado para o teste. Ap�s o teste esse arquivo � deletado.
O script, para confirmar que o texto foi inserido no arquivo ".doc", ap�s o teste, reabre ele, l� o texto novamente e compara com o texto original do txt.
Para verificar se n�o ocorreu erros na execu��o do script, o c# l� o arquivo de log gerado pelo script e busca pela mensagem de sucesso. Caso n�o encontre a mensagem o teste n�o passa.

Melhorias:
Verificar se o texto foi inserido antes de tirar o print. No momento, como o script n�o sabe se o texto j� foi inserido, ele aguarda 3 segundos para tirar o print.
Utilizar a DLL AutoITX3 para poder chamar os m�todos que o script chama diretamente do c#.
Nos testes web, ler quais campos e quais valores devem ser inseridos de um arquivo xml ou json.
