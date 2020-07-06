namespace Esoft.Util.Searchers
{
    public static class Levenshtein
    {
        public static int Distance(string value1, string value2)
        {
            if (value1.Length == 0)
            {
                return 0;
            }

            int[] costs = new int[value1.Length];

            
            for (int i = 0; i < costs.Length;)
            {
                costs[i] = ++i;
            }

            int minSize = value1.Length < value2.Length ? value1.Length : value2.Length;

            for (int i = 0; i < minSize; i++)
            {
                
                int cost = i;
                int addationCost = i;

                
                char value2Char = value2[i];

                for (int j = 0; j < value1.Length; j++)
                {
                    int insertionCost = cost;

                    cost = addationCost;

                    
                    addationCost = costs[j];

                    if (value2Char != value1[j])
                    {
                        if (insertionCost < cost)
                        {
                            cost = insertionCost;
                        }

                        if (addationCost < cost)
                        {
                            cost = addationCost;
                        }

                        ++cost;
                    }

                    costs[j] = cost;
                }
            }

            return costs[costs.Length - 1];
        }
    }
}