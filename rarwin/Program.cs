using rarwin;
using CommandLine;
using SharpCompress.Readers;
using SharpCompress.Common;

Parser.Default.ParseArguments<Options>(args)
  .WithParsed(o =>
  {
      var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location);
      var fileToExtract = o.Input?.First().ToString();

      using var stream = File.OpenRead($"{path}\\{fileToExtract}");
      var reader = ReaderFactory.Open(stream);

	  var destPath = fileToExtract.Split('.');

	  if (o.Output.Any()) destPath[0] = o.Output.First().ToString();

	  if (!Directory.Exists($"{path}\\{destPath[0]}"))
	  {
		  Directory.CreateDirectory($"{path}\\{destPath[0]}");
	  }

	  while (reader.MoveToNextEntry())
	  {
		  if (!reader.Entry.IsDirectory)
		  {
			  Console.WriteLine(reader.Entry.Key);
			  reader.WriteEntryToDirectory($"{destPath[0]}", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
		  }
	  }
  });