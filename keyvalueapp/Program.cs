// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("-----------Retrieve Secret Value from Azure KeyVault-----------");
        var keyValutName = "santoshkeyvault2";
        var keyVaultUri = $"https://{keyValutName}.vault.azure.net/";
        var tenantId="<tenant id from app registrations>";
        var clientId="<client id from app registrations>";
        var clientSecret="<client secret from app registrations>";

        var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        
        var client = new SecretClient(new Uri(keyVaultUri), credential);
        var secret = await client.GetSecretAsync("mysecret");
        Console.WriteLine($"My secret from Keyvault {secret.Value.Value}");

    }
}