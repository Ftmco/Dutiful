using Dutiful.ViewModels.Tools;

public static class ImageExtension
{
    public static async Task<string> SaveBase64FileAsync(this SaveBase64File saveBase64File)
        => await Task.Run(async () =>
        {
            byte[] fileBytes = Convert.FromBase64String(saveBase64File.Base64);
            SaveByteFile saveByteFile = new(fileBytes, saveBase64File.Path);
            return await saveByteFile.SaveByteFileAsync();
        });

    public static async Task<string> SaveByteFileAsync(this SaveByteFile saveByteFile)
    {
        return "";
    }
}