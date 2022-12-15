Criar banco de dados (dp_projeto) e executar o script para criar a tabela tbProdutos

DROP TABLE IF EXISTS `tbProdutos`;
CREATE TABLE `tbProdutos` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descProduto` varchar(50) NOT NULL,
  `situação` CHAR(1) NOT NULL,
  `dtFabricacao` DATETIME NOT NULL,
  `dtValidade` DATETIME NOT NULL,
  `cdFornecedor` INT(11) NOT NULL,
  `descFornecedor` VARCHAR(50) NOT NULL,
  `cnpjFornecedor` VARCHAR(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

Configurar string de conexão em appsettings.json, indicando porta, usuário, senha e banco.

"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3333;user=projeto;password=dbR00tP455;database=db_projeto;"
}

Rodar o projeto (F5) e os endpoints da api serão exibidos no swagger, através do navegador.

