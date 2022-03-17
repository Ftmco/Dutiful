namespace Dutiful.ViewModels.Tools;

public record SaveBase64File(string Base64, string Path);

public record SaveByteFile(byte[] Bytes,string Path);

public record SendFile(string Base64,string OgName,string Type);

public record FileViewModel(Guid Id,string Name,string OgName,string CreateDate,string Directory,string Type,string ObjectType);