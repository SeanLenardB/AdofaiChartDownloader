using AdofaiChartDownloader;
using ExcelDataReader;
using System.Text;

internal class Program
{
    static HttpClient client = new();
    static int progress = 0;
    static int totalLength = 0;
    static string path = "";

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Please input .xlsx file location");
        string dataPath = Console.ReadLine()!.Replace("\"", "");
        path = dataPath[..(dataPath.LastIndexOf('\\')+1)];
        Console.WriteLine($"Charts will be downloaded to {path}");
        AdofaiChart[] charts = ParseCharts(dataPath).ToArray();
        Console.WriteLine($"Success! Detected {charts.Length} charts!");
        Console.WriteLine($"Press any key to start downloading..."); Console.ReadKey();
        totalLength = charts.Length;
        int i = 0;
        foreach (AdofaiChart chart in charts)
        {
            DownloadChart(chart);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Requested {++i}/{totalLength}");
            while (i > progress)
            {
                Thread.Sleep(500);
            }
        }
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Download Complete!");
        Console.WriteLine("You can quit the app now!");

        Console.ReadLine();
    }

    private static async void DownloadChart(AdofaiChart chart)
    {
        try
        {
            byte[] data;
            if (chart.Url.Contains("drive.google.com")) // if you have a google drive link, then use google apis.
            {
                if (chart.Url.Contains("/d/")) // this is google share link. get the id and download using direct link.
                {
                    string id = chart.Url[(chart.Url.IndexOf("/d/") + 3)..(chart.Url.IndexOf("/view"))];
                    data = await client.GetByteArrayAsync($"https://drive.google.com/uc?export=download&id={id}");
                } 
                else if (chart.Url.Contains("uc?")) // this is already direct link.
                {
                    data = await client.GetByteArrayAsync(chart.Url);
                } 
                else if (chart.Url.Contains("id=")) // this is another type of google indirect link. get the id and download using direct link.
                {
                    string id = chart.Url[(chart.Url.IndexOf("id=") + 3)..(chart.Url.IndexOf("&"))];
                    data = await client.GetByteArrayAsync($"https://drive.google.com/uc?export=download&id={id}");
                } else // fuck this i can't think of another type of google link.
                {
                    data = null!;
                    throw new Exception("WTF is that link?");
                }
            } else
            {
                data = await client.GetByteArrayAsync(chart.Url);
            }
            
            
            string fileName = $"[{chart.Level}] #{chart.Id}. {chart.Artist} - {chart.Name} [By {chart.Creator}].zip";
            foreach (char ch in "\\/:*?\"<>|".ToCharArray())
            {
                fileName = fileName.Replace(ch, '_');
            }
            File.WriteAllBytes(@$"{path}{fileName}", data);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Progress {++progress}/{totalLength} ({Math.Round(progress / (double)totalLength * 100, 2)}%)");
        } catch (Exception e)
        {
            if (e is HttpRequestException)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Progress {++progress}/{totalLength} ({Math.Round(progress / (double)totalLength * 100, 2)}%) [Failed] {e}");
                if (chart.Url.Contains("drive.google.com"))
                {
                    if (chart.Url.Contains("/d/"))
                    {
                        string id = chart.Url[(chart.Url.IndexOf("/d/") + 3)..(chart.Url.IndexOf("/view"))];
                        File.AppendAllText(@$"{path}Errors.txt", $"#{chart.Id} failed because download link failure. " +
                            $"[https://drive.google.com/uc?export=download&id={id}]\n");
                    }
                    else if (chart.Url.Contains("uc?"))
                    {
                        File.AppendAllText(@$"{path}Errors.txt", $"#{chart.Id} failed because download link failure. " +
                            $"[{chart.Url}]\n");
                    }
                    else if (chart.Url.Contains("id="))
                    {
                        string id = chart.Url[(chart.Url.IndexOf("id=") + 3)..(chart.Url.IndexOf("&"))];
                        File.AppendAllText(@$"{path}Errors.txt", $"#{chart.Id} failed because download link failure. " +
                            $"[https://drive.google.com/uc?export=download&id={id}]\n");
                    } else
                    {
                        File.AppendAllText(@$"{path}Errors.txt", $"#{chart.Id} failed because download link failure. " +
                            $"[{chart.Url}]\n");
                    }
                } else
                {
                    File.AppendAllText(@$"{path}Errors.txt", $"#{chart.Id} failed because download link failure. " +
                        $"[{chart.Url}]\n");
                }
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Progress {++progress}/{totalLength} ({Math.Round(progress / (double)totalLength * 100, 2)}%) [Failed] {e}");
                File.AppendAllText(@$"{path}Errors.txt", $"#{chart.Id} failed because download link failure. " +
                        $"[{chart.Url}]\n");
            }
        }
    }

    private static List<AdofaiChart> ParseCharts(string excelLocation)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using (IExcelDataReader dataReader = ExcelReaderFactory.CreateReader(File.Open(excelLocation, FileMode.Open), new() { FallbackEncoding = Encoding.UTF8 }))
        {
            List<AdofaiChart> charts = new();
            while (dataReader.Read())
            {
                charts.Add(new((int)dataReader.GetDouble(0), 
                    dataReader.GetValue(1).ToString()!, 
                    dataReader.GetValue(4).ToString()!, 
                    dataReader.GetValue(2).ToString()!, 
                    dataReader.GetValue(18).ToString()!, 
                    dataReader.GetValue(3).ToString()!));
            }
            
            return charts;
        }
        throw new InvalidDataException("The .xlsx file is not in a good format!");
    }
    
    
}