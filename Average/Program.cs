ClimateData data = GenerateFakeClimateData();

double averageTemperature = new();
averageTemperature = data.Data.Average(x => x.Temp);

//cut to two decimal houses
averageTemperature = Math.Round(averageTemperature, 2);

Console.WriteLine(" The average temperature for the data collected is: " + averageTemperature);

static ClimateData GenerateFakeClimateData()
{
    // Generate random climate data
    ClimateDatum[] data = new ClimateDatum[120];
    Random random = new Random();
    for (int i = 0; i < 120; i++)
    {
        double temp = random.NextDouble() * 50 - 10; // temperature range from -10 to 40
        data[i] = new ClimateDatum { Temp = temp };
    }

    return new ClimateData { Data = data };
}



