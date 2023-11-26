// See https://aka.ms/new-console-template for more information
using CommandLine;
using Data;
using LivesAlone;

Console.WriteLine("Hello, World!");
Parser.Default.ParseArguments<Options>(args)
      .WithParsed(RunWithOptions)
      .WithNotParsed(HandleParseError);

static void RunWithOptions(Options opts)
{
    // This method is called if the arguments are parsed successfully
    if (!string.IsNullOrEmpty(opts.FolderPath))
    {
        Console.WriteLine($"Provided folder path: {opts.FolderPath}");
        Console.WriteLine($"Getting Data from Csvs...");
        var repo = new Repo(opts.FolderPath);
        Console.WriteLine($"....Data retrieved from Csvs.");
        Console.WriteLine($"Patients Over 18: {repo.PatientsOverEighteenByPostCode.Count}");
        Console.WriteLine($"Patients Under 18: {repo.PatientsUnderEighteenByPostCode.Count}");
        Console.WriteLine($"Patients Data: {repo.DataRepository.Count}");
        Console.WriteLine($"Processing Data...");
        var dataProcessor = new DataProcessor();
        var alonePatients = dataProcessor.ReturnAlonePatients(repo);
        Console.WriteLine($"....Data processed.");

        var patientTypeCounts = alonePatients
            .GroupBy(p => p.PatientType)
            .Select(g => new { PatientType = g.Key, Count = g.Count() });

        var patientPopulationCounts = repo.DataRepository
            .GroupBy(p => p.PatientType)
            .Select(g => new { PatientType = g.Key, Count = g.Count() });

        foreach (var count in patientTypeCounts)
        {
            var populationCount = patientPopulationCounts.FirstOrDefault(p => p.PatientType == count.PatientType);
            if (count.PatientType == "DementiaCohabiting") populationCount = new {PatientType = "DementiaCohabiting", Count = count.Count};
            var percentage = ((double)count.Count / populationCount.Count * 100).ToString("F2");
            Console.WriteLine($"Patients in: {count.PatientType} = {count.Count} / {(double)populationCount.Count} ({percentage}%)");
        }
        Console.WriteLine($"Patients Alone: {alonePatients.Count}");
        Console.WriteLine($"Total Patients: {repo.DataRepository.Count}");
        Console.WriteLine($"Percentage Potential Alone: {((double)alonePatients.Count / (double)repo.DataRepository.Count * 100):F2}%");

        var exportFIlename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"AlonePatients_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
        Console.WriteLine($"Exporting to CSV...{exportFIlename}");
        new ExportToCsv(alonePatients, exportFIlename);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("No folder path provided.");
    }
}

static void HandleParseError(IEnumerable<Error> errs)
{
    // Handle errors in command-line argument parsing
    foreach (var err in errs)
    {
        Console.WriteLine($"Error: {err.Tag}");
    }
}