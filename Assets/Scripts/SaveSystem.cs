using UnityEngine;
using System.IO; //pacote para mexer com arquivos de texto
using System.Runtime.Serialization.Formatters.Binary;// pacote para usar a criptografia binária



public static class SaveSystem 
{
    public static void SavePlayer (PlayerController player) //recebe um objeto player como parâmetro, 
    {
        BinaryFormatter formatter = new BinaryFormatter(); //cria um novo formatter

        string path = Application.persistentDataPath +"/Player.sav"; //cria um arquivo no caminho padrão de cada sistema operacional
        FileStream stream = new FileStream(path, FileMode.Create);//transmite os arquivos e cria o arquivo no caminho definido anteriormente

        Player_base data = new Player_base(player); //cria o objeto data

        formatter.Serialize(stream, data);//passa toda a data do dto, junto com a variável stream, transmite a data, e serializa tudo no arquivo criado
        stream.Close();//FECHA O ARQUIVO, NECESSÁRIO FECHAR SEMPRE
        Debug.Log(data.ToString());
    }

    public static Player_base LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_base data = formatter.Deserialize(stream) as Player_base;

            stream.Close();
            Debug.Log(data.ToString());

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
