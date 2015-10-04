# Olo.Interview
Top Pizza Configuration Challenge

## Top Pizzas (TopPizzas.exe)
Top pizzas is a specialized json rest client that outputs the top 20 most commonly ordered pizza configurations by consuming a json rest endpoint or by reading a specified file.

### Usage

TopPizzas.exe [/dataSrc:<filePath|Uri>]

When invoked without arguments TopPizzas will look in the current directory for a file called pizzas.json then output the top 20 pizza configurations.

When invoked with arguments TopPizzas will read the specified data source and output the top 20 pizza configurations.  If the specified data source starts with "http" it assumed to be a Uri otherwise it is assumed to be a local file.

