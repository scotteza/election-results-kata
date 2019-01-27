using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ElectionResultsKata.Tests
{
    public class AcceptanceTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void Process_Two_Example_Lines()
        {
            var inputParser = new Mock<InputParser>();
            var inputProcessor = new Mock<InputProcessor>();
            var resultPrinter = new Mock<ResultPrinter>();
            var electionProcessor = new ElectionProcessor(inputParser.Object, inputProcessor.Object, resultPrinter.Object);
            var input = @"Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD" + Environment.NewLine
                                    + "Islington South & Finsbury, 22547, L, 9389, C, 4829, LD, 3375, UKIP, 3371, G, 309, Ind";

            var electionResult1 = new ElectionResult();
            electionResult1.SetConstituencyName("Cardiff West");
            electionResult1.AddRawResult(11014, "C");
            electionResult1.AddRawResult(17803, "L");
            electionResult1.AddRawResult(4923, "UKIP");
            electionResult1.AddRawResult(2069, "LD");

            var electionResult2 = new ElectionResult();
            electionResult2.SetConstituencyName("Islington South & Finsbury");
            electionResult2.AddRawResult(22547, "L");

            electionResult2.AddRawResult(9389, "C");
            electionResult2.AddRawResult(4829, "LD");
            electionResult2.AddRawResult(3375, "UKIP");
            electionResult2.AddRawResult(3371, "G");
            electionResult2.AddRawResult(309, "IND");

            inputParser.Setup(ip => ip.ParseInput(input)).Returns(new List<ElectionResult>
            {
                electionResult1,
                electionResult2
            });

            var result = electionProcessor.GetResult(input);

            inputParser.Verify(ip => ip.ParseInput(input));
            inputProcessor.Verify(ip=>ip.Process(electionResult1));
            inputProcessor.Verify(ip=>ip.Process(electionResult2));

        }
    }

    public class ElectionProcessor
    {
        public ElectionProcessor(InputParser inputParser, InputProcessor inputProcessor, ResultPrinter resultPrinter)
        {
            throw new System.NotImplementedException();
        }

        public object GetResult(string input)
        {
            throw new NotImplementedException();
        }
    }

    public interface ResultPrinter
    {
    }

    public interface InputProcessor
    {
        void Process(ElectionResult electionResult);
    }

    public interface InputParser
    {
        List<ElectionResult> ParseInput(string input);
    }

    public class ElectionResult
    {
        public void SetConstituencyName(string constituencyName)
        {
            throw new NotImplementedException();
        }

        public void AddRawResult(int voteCount, string constituencyName)
        {
            throw new NotImplementedException();
        }
    }
}
