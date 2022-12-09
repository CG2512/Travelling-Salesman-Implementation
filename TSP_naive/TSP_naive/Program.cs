namespace TSP_naive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   matrix representation of graph
            int[,] graph
                = new int[4, 4] { { 0, 10, 15, 20 },
                              { 10, 0, 35, 25 },
                              { 15, 35, 0, 30 },
                              { 20, 25, 30, 45 } };
            int s = 0;
            string[] cities = new string[] { "A", "B", "C", "D" };
            List<string> Path=travllingSalesmanProblem(cities,graph, s);
            Console.WriteLine("Best path is: ");
            for (int i = 0; i < Path.Count; i++)
            {
                Console.WriteLine("City " + Path[i]);
            }
        }

        // implementation of traveling Salesman Problem
        static List<string> travllingSalesmanProblem(string[] cities,int[,] graph,
                                            int s)
        {
            List<int> vertex = new List<int>();
            List<string> best_path = new List<string>();
            int V= graph.GetLength(0);
            for (int i = 0; i < V; i++)
                if (i != s)
                    vertex.Add(i);

            // store minimum weight
            // Hamiltonian Cycle.
            int min_path = Int32.MaxValue;

            do
            {
                // store current Path weight(cost)
                List<string> current_path = new List<string>() { cities[s] };
                int current_pathweight = 0;
                int k = s;

                // compute current path weight
                for (int i = 0; i < vertex.Count; i++)
                {
                    current_pathweight += graph[k, vertex[i]];
                    current_path.Add(cities[vertex[i]]);
                    k = vertex[i];
                }

                current_pathweight += graph[k, s];

                // update minimum
                if (current_pathweight < min_path)
                    {
                    min_path = current_pathweight;
                    best_path = current_path;
                    }

            } while (findNextPermutation(vertex));


            return best_path;
        }

        // Function to swap the data resent in the left and
        // right indices
        public static List<int> swap(List<int> data, int left,
                                     int right)
        {
            // Swap the data
            int temp = data[left];
            data[left] = data[right];
            data[right] = temp;

            // Return the updated array
            return data;
        }

        // Function to reverse the sub-array starting from left
        // to the right both inclusive
        public static List<int> reverse(List<int> data,
                                        int left, int right)
        {
            // Reverse the sub-array
            while (left < right)
            {
                int temp = data[left];
                data[left++] = data[right];
                data[right--] = temp;
            }

            // Return the updated array
            return data;
        }

        // Function to find the next permutation of the given
        // integer array
        public static bool findNextPermutation(List<int> data)
        {
            // If the given dataset is empty
            // or contains only one element
            // next_permutation is not possible
            if (data.Count <= 1)
                return false;
            int last = data.Count - 2;

            // find the longest non-increasing
            // suffix and find the pivot
            while (last >= 0)
            {
                if (data[last] < data[last + 1])
                    break;
                last--;
            }

            // If there is no increasing pair
            // there is no higher order permutation
            if (last < 0)
                return false;
            int nextGreater = data.Count - 1;

            // Find the rightmost successor
            // to the pivot
            for (int i = data.Count - 1; i > last; i--)
            {
                if (data[i] > data[last])
                {
                    nextGreater = i;
                    break;
                }
            }

            // Swap the successor and
            // the pivot
            data = swap(data, nextGreater, last);

            // Reverse the suffix
            data = reverse(data, last + 1, data.Count - 1);

            // Return true as the
            // next_permutation is done
            return true;
        }
    }
}