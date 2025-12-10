using AdventOfCode.Common;
using System.Numerics;

namespace AdventOfCode.Solutions.Year2025;

public class Day08 : ISolution
{
    public string SolvePart1(string input)
    {
        var vectors = GetVectors(input);
        var vectorPairs = GetVectorPairs(vectors);

        var sortedVectorPairs = vectorPairs.OrderBy(x => x.Distance).Take(10).ToList();
        var circuits = new List<Circuit>();

        foreach (var vectorPair in sortedVectorPairs)
        {
            Vector3 v1 = vectorPair.Vector1;
            Vector3 v2 = vectorPair.Vector2;
            Console.WriteLine($"{v1.ToString()} - {v2.ToString()} : {vectorPair.Distance}");
            var existingCircuits = new List<Circuit>();
            foreach (var circuit in circuits)
            {
                if (circuit.Vectors.Contains(v1) || circuit.Vectors.Contains(v2))
                {
                    existingCircuits.Add(circuit);
                }
            }

            var newCircuit = new Circuit();
            newCircuit.Vectors.Add(v1);
            newCircuit.Vectors.Add(v2);

            foreach(var circuit in existingCircuits)
            {
                foreach(var vector in circuit.Vectors)
                {
                    newCircuit.Vectors.Add(vector);
                }
                circuits.Remove(circuit);
            }

            circuits.Add(newCircuit);
        }

        var sortedCircuits = circuits.OrderByDescending(x => x.Vectors.Count).Take(3).ToList();

        foreach (var circuit in sortedCircuits)
        {
            Console.WriteLine(circuit.Vectors.Count);
        }

        return (sortedCircuits[0].Vectors.Count * sortedCircuits[1].Vectors.Count * sortedCircuits[2].Vectors.Count).ToString();
    }

    public string SolvePart2(string input)
    {
        var vectors = GetVectors(input);
        var vectorPairs = GetVectorPairs(vectors);

        var sortedVectorPairs = vectorPairs.OrderBy(x => x.Distance).ToList();
        var circuits = new List<Circuit>();

        foreach (var vectorPair in sortedVectorPairs)
        {
            Vector3 v1 = vectorPair.Vector1;
            Vector3 v2 = vectorPair.Vector2;
            Console.WriteLine($"{v1.ToString()} - {v2.ToString()} : {vectorPair.Distance}");
            var existingCircuits = new List<Circuit>();
            foreach (var circuit in circuits)
            {
                if (circuit.Vectors.Contains(v1) || circuit.Vectors.Contains(v2))
                {
                    existingCircuits.Add(circuit);
                }
            }

            var newCircuit = new Circuit();
            newCircuit.Vectors.Add(v1);
            newCircuit.Vectors.Add(v2);

            foreach (var circuit in existingCircuits)
            {
                foreach (var vector in circuit.Vectors)
                {
                    newCircuit.Vectors.Add(vector);
                }
                circuits.Remove(circuit);
            }

            circuits.Add(newCircuit);

            if (newCircuit.Vectors.Count == vectors.Count)
            {
                Console.WriteLine($"{v1.ToString()} = {v2.ToString()}");
                return (v1.X * v2.X).ToString();
            }
        }

        var sortedCircuits = circuits.OrderByDescending(x => x.Vectors.Count).Take(3).ToList();

        foreach (var circuit in sortedCircuits)
        {
            Console.WriteLine(circuit.Vectors.Count);
        }

        return (sortedCircuits[0].Vectors.Count * sortedCircuits[1].Vectors.Count * sortedCircuits[2].Vectors.Count).ToString();
    }

    private static List<Vector3> GetVectors(string input)
    {
        var lines = InputParser.ToStringArray(input);
        var result = new List<Vector3>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var vector = new Vector3(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            result.Add(vector);
        }

        return result;
    }

    private static List<VectorPair> GetVectorPairs(List<Vector3> vectors)
    {
        var result = new List<VectorPair>();

        for (int i = 0; i < vectors.Count - 1; i++)
        {
            for (int j = i + 1; j < vectors.Count; j++)
            {
                var vd = new VectorPair() { Vector1 = vectors[i], Vector2 = vectors[j], Distance = Vector3.Distance(vectors[i], vectors[j]) };
                result.Add(vd);
            }
        }

        return result;
    }

    private class VectorPair
    {
        public double Distance;
        public Vector3 Vector1;
        public Vector3 Vector2;
    }

    private class Circuit
    {
        public HashSet<Vector3> Vectors = new();
    }
}