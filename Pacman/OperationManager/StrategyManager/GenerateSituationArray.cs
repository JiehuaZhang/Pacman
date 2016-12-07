namespace OperationManager.StrategyManager
{
    public static class GenerateSituationArray
    {
        /// <summary>
        /// a:up;b:right;c:button;d:left;e:center;
        /// </summary>
        /// <returns></returns>
        public static string[]  GetSituationArray()
        {
            var list = new string[243];
            var i = 0;
            for (var a = 0; a < 3; a++)
            {
                for (var b = 0; b < 3; b++)
                {
                    for (var c = 0; c < 3; c++)
                    {
                        for (var d = 0; d < 3; d++)
                        {
                            for (var e = 0; e < 3; e++)
                            {
                                list[i] = $"{a}{b}{c}{d}{e}";
                                i++;
                            }
                        }
                    }
                }
            }
            return list;
        }
    }
}
