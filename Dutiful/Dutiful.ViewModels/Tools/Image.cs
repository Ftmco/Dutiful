namespace Dutiful.ViewModels.Tools;

public record SaveBase64File(string Base64, string Path);

public record SaveByteFile(byte[] Bytes,string Path);