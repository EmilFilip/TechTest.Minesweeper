namespace SchneiderElectric.Minesweeper.Emil.Helpers
{
    public static class MapNumberToLetter
    {
        public static string GetLetterFromNumber(int arrayRowIndex)
        { 
            var letters = new List<string>();
            //add more if the board becomes bigger than what is specified in GameConstants.BoardSize constant
            letters.Add("A ");
            letters.Add("B ");
            letters.Add("C ");
            letters.Add("D ");
            letters.Add("E ");
            letters.Add("F ");
            letters.Add("G ");
            letters.Add("H ");

            return letters[arrayRowIndex];
        }
    }
}
