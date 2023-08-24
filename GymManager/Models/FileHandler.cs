using Newtonsoft.Json;
using System;
using System.IO;

namespace GymManager.Models
{
    internal class FileHandler
    {
        // TODO: Write CRUD functionality for file system DB.
        // All CRUD operations will ne handled through methoods in this class.

        public static void CreateClientFile(Client client)
        {
            string clientDirectory = $"Clients/{client.Id}";
            // creates dir if its not found (Clients/{clientId}/)
            Directory.CreateDirectory(clientDirectory);

            // maps every prop name and value of a class' instance to json key-value pairs
            string serializedClient = JsonConvert.SerializeObject(client);
            string clientFilePath = Path.Combine(clientDirectory, "client.json");
            // write the json data to the file
            File.AppendAllText(clientFilePath, serializedClient + Environment.NewLine);
        }

        public static void CreateCoachFile(Coach coach)
        {
            string clientDirectory = $"Coaches/{coach.Id}";
            // creates dir if its not found (Clients/{clientId}/)
            Directory.CreateDirectory(clientDirectory);

            // maps every prop name and value of a class' instance to json key-value pairs
            string serializedClient = JsonConvert.SerializeObject(coach);
            string clientFilePath = Path.Combine(clientDirectory, "coach.json");
            // write the json data to the file
            File.AppendAllText(clientFilePath, serializedClient + Environment.NewLine);
        }

    }
}
