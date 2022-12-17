using AoCProblemSolvers.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCProblemSolvers._2015Day21
{
    internal class Day21Solver
    {
        private FileReader _fileReader;
        private IEnumerable<string> _rawText;
        private string[] _text;
        private int bossHitPoints;
        private int bossDamage;
        private int bossArmor;
        private Equipment _equipment;
        public Day21Solver()
        {
            _fileReader = new FileReader();
            _rawText = _fileReader.Read("../../../2015Day21/input.txt");
            _text = _rawText.ToArray();
            _equipment = new Equipment();
            bossHitPoints = int.Parse(_text[0].Split(": ")[1]);
            bossDamage = int.Parse(_text[1].Split(": ")[1]);
            bossArmor = int.Parse(_text[2].Split(": ")[1]);
        }

        public void SolvePartOne()
        {
            var engine = new Engine(bossHitPoints, bossDamage, bossArmor);
            var outcome = engine.CostOptimizer();
            Console.WriteLine(outcome);
        }
    }
}
