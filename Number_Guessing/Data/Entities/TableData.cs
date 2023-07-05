namespace Number_Guessing.Data.Entities
{
    public class TableData
    {
        public TableData(int guessedNumber, int numOfAttempts, string message)
        {
            GuessedNumber = guessedNumber;
            NumOfAttempts = numOfAttempts;
            Message = message;
        }
        public int Id { get; set; }
        public int GuessedNumber { get; set; }
        public int NumOfAttempts { get; set; }
        public string Message { get; set; }

    }
}
