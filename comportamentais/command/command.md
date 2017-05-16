## Command

Controlar as chamadas a um determinado componente, modelando cada requisição como um objeto. Permitir que as operações possam ser desfeitas,
enfileiradas ou registradas através de comandos.

A ideia do Command é abstrair um comando que deve ser executado, pois não é possível executá-lo naquele momento (pois precisamos por em uma fila
ou coisa do tipo).

![command](https://cloud.githubusercontent.com/assets/14116020/26088703/074c85da-39cf-11e7-9d2e-c3f46662c6c2.png)

* **Command (Comando)**: Define uma interface para a execução dos métodos do Receiver.

* **ConcreteCommand (TocarMusica, AumentarVolume, DiminuirVolume)**: Classe que implementa Command e modela uma operação específica do Receiver.

* **Invoker (ListaDeComandos)**: Classe que armazena os Commands que devem ser executados.

* **Receiver (Player)**: Define os objetos que terão as chamadas aos seus métodos controladas.

* **Cliente**: Instancia os Commands associando-os ao Receiver e armazena-os no Invoker.

***
#### Implementação
***

1. Crie uma **Receiver** para rodar os comandos de **Command**

2. Crie a interface **Command** que será implementada pela ConcreteCommand através do método **executa()**

3. Crie cada comando (**ConcreteCommand**) que será inserido na lista de comandos e associados ao **Receiver**

4. Crie o **Invoker** que armazenará a lista de comandos através do método adiciona() executará todos os comandos da lista através do método
   executa()

5. Crie a cliente que irá instanciar um Receiver e o Invoker adicionado cada ConcreteCommand dentro do Invoker e executando-o

