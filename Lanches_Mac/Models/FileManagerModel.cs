namespace Lanches_Mac1.Models
{
    public class FileManagerModel
    {
        //Acesso a métodos e propriedades para o tratamento de arquivos.
        public FileInfo[] Files { get; set; }

        //Interface onde se permite o envio dos arquivos, onde iremos fazer a copia do arquivo para a pasta de destino.
        public IFormFile IformFile { get; set; }

        //Lista dos arquivos de envio.
        public List<IFormFile> IFormFiles { get; set;}

        //Caminho de armazenamento, o nome da pasta onde será salvo os arquivos.
        public string PathImagesProdutos { get; set; }
    }
}
