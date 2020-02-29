namespace _420J13AS_final
{
    enum Weather
    {
        Sunny,
        Cloudy,
        Rainy
    }

    static class Meteo
    {
        static int[,] history = new int[3, 3];

        public static Weather Predict(Weather today)
        {
            Weather prediction = Weather.Sunny;

            // Implement this
            int count1 = -1;
            for (int i = 1; i < 3; i++)
            {

                int currentHistory = history[i, i - 1];
                if (count1 < currentHistory)
                {
                    today = prediction;
                    count1 = currentHistory;
                    prediction = (Weather)i;
                }
            }
            return prediction;
        }

        static void Record(Weather yesterday, Weather today)
        {
            history[(int)yesterday, (int)today]++;
        }

        static Meteo()
        {
            Record(Weather.Sunny, Weather.Sunny);
            Record(Weather.Sunny, Weather.Sunny);
            Record(Weather.Sunny, Weather.Sunny);
            Record(Weather.Sunny, Weather.Cloudy);
            Record(Weather.Sunny, Weather.Cloudy);
            Record(Weather.Sunny, Weather.Rainy);
            Record(Weather.Cloudy, Weather.Rainy);
            Record(Weather.Cloudy, Weather.Rainy);
            Record(Weather.Cloudy, Weather.Rainy);
            Record(Weather.Cloudy, Weather.Cloudy);
            Record(Weather.Cloudy, Weather.Cloudy);
            Record(Weather.Cloudy, Weather.Sunny);
            Record(Weather.Rainy, Weather.Cloudy);
            Record(Weather.Rainy, Weather.Cloudy);
            Record(Weather.Rainy, Weather.Cloudy);
            Record(Weather.Rainy, Weather.Rainy);
            Record(Weather.Rainy, Weather.Rainy);
            Record(Weather.Rainy, Weather.Sunny);
        }
    }
}
