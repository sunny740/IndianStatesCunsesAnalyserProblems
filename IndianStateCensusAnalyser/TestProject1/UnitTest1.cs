using IndianStateCensusAnalyser;
using IndianStateCensusAnalyzer;
using NUnit.Framework;

namespace IndianStateCensusAnalyzer
{
    public class Tests
    {
        CensusAnalyser censusAnalyzer;
        string path = @"D:\BridgeLabzProject\IndianStatesCunsesAnalyserProblems\IndianStatesCunsesAnalyserProblems\IndianStateCensusAnalyser\CsvFile\IndiaStateCode.csv";
        string file = "IndiaStateCensusData.csv";
        string InvalidFile = "IndiaStateCode.txt";
        string InvalidDelimiter = "DelimiterIndiaStateCensusData.csv";
        string InvalidHeader = "WrongIndiaStateCensusData.csv";
        string StateCodeDelimiter = "DelimiterIndiaStateCode.csv";
        string StateCodeExtension = "IndiaStateCode.csv";
        string StateCodeInvalidHeader = "WrongIndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyser();
        }

        // TC 1.1: Given the States Census CSV file, Check to ensure the Number of Record matches
        [Test]
        public void GivenCSVFile_CheckifNumberofRecordsMatch()
        {
            censusAnalyzer.keyValuePairs = censusAnalyzer.CensusData(path + file, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyzer.keyValuePairs.Count);
        }

        // TC 1.2: Given the State Census CSV File if incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectFileName_ReturnCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + file + "c", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.File_Not_Found, Exception);
        }

        // TC 1.3: Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectType_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidFile, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_File_Type, Exception);
        }

        // TC 1.4: Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectDelimiter_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidDelimiter, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_Delimeter, Exception);
        }

        // TC 1.5: Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void GivenIncorrectHeader_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidHeader, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Incorrect_Header, Exception);
        }
        // TC 2.1: Given the States Code CSV file, Check to ensure the Number of Record matches
        [Test]
        public void GivenStateCodeCSVFile_TestIfRecordMatched()
        {
            censusAnalyzer.keyValuePairs = censusAnalyzer.CensusData(path + StateCodeExtension, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyzer.keyValuePairs.Count);
        }

        // TC 2.2: Given the State Census CSV File if incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectFileName_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + InvalidHeader + "hellow", "SrNo, State Name, TIN, StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.File_Not_Found, Exception);
        }

        // TC 2.3: Given the State Code CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectType_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + StateCodeExtension, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_File_Type, Exception);
        }

        // TC 2.4: Given the State Code CSV File when correct but delimiter incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectDelimiter_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + StateCodeDelimiter, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Invalid_Delimeter, Exception);
        }

        // TC 2.5: Given the State Code CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void GivenStateCodeIncorrectHeader_ReturnsCustomException()
        {
            CensusCustomException Exception = Assert.Throws<CensusCustomException>(() => censusAnalyzer.CensusData(path + StateCodeInvalidHeader, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusCustomException.ExceptionType.Incorrect_Header, Exception);
        }
    }
}