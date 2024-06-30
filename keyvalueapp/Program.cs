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
        var tenantId="970f0b6d-e74a-4d60-9dbf-3541e4007161";
        var clientId="8030654a-d873-4d9e-aec7-c5e88b1b63fe";
        var clientSecret="BPi8Q~_N6MVF2etkemvazUicsLOz81W7i46x-auV";

        var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        
        var client = new SecretClient(new Uri(keyVaultUri), credential);
        var secret = await client.GetSecretAsync("mysecret");
        Console.WriteLine($"My secret from Keyvault {secret.Value.Value}");

    }
}