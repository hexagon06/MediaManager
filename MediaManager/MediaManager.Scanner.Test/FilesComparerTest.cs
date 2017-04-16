using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaManager.Interfaces;
using MediaManager.Interfaces.Fakes;
using System.Collections.Generic;

namespace MediaManager.Scanner.Test
{
    [TestClass]
    public class FilesComparerTest
    {

        [TestMethod]
        public void TestNew()
        {
            var oldStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\File.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File"
            };
            var old = new List<IFile>(){
                oldStub
            };
            var scanStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\File2.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File2"
            };
            var scan = new List<IFile>(){
                oldStub,
                scanStub
            };


            var comparer = new FilesComparer(old);
            IEnumerable<ScanCompareResult> result = comparer.Compare(scan);

            var comparedResult = result.Single();
            Assert.AreEqual(scanStub.FileLocationGet(), comparedResult.NewScan.FileLocation, "FilesComparer.Compare() resulting location should be the same");
            Assert.AreEqual(CompareResult.New, comparedResult.Result);
        }

        [TestMethod]
        public void TestDelete()
        {
            var oldStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\File.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File"
            };
            var scanStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\File2.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File2"
            };
            var old = new List<IFile>(){
                oldStub,
                scanStub
            };
            var scan = new List<IFile>(){
                oldStub
            };


            var comparer = new FilesComparer(old);
            IEnumerable<ScanCompareResult> result = comparer.Compare(scan);

            var comparedResult = result.Single();
            Assert.AreEqual(scanStub.FileLocationGet(), comparedResult.OldScan.FileLocation, "FilesComparer.Compare() resulting location should be the same");
            Assert.AreEqual(CompareResult.Removed, comparedResult.Result);
        }

        [TestMethod]
        public void TestMoved()
        {
            var oldStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\File.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File"
            };
            var scanStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\folder\\File.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File"
            };
            var old = new List<IFile>(){
                oldStub
            };
            var scan = new List<IFile>(){
                scanStub
            };


            var comparer = new FilesComparer(old);
            IEnumerable<ScanCompareResult> result = comparer.Compare(scan);

            var comparedResult = result.Single();
            Assert.AreEqual(scanStub.FileLocationGet(), comparedResult.NewScan.FileLocation);
            Assert.AreEqual(oldStub.FileLocationGet(), comparedResult.OldScan.FileLocation);
            Assert.AreEqual(CompareResult.Moved, comparedResult.Result);
        }

        [TestMethod]
        public void TestNoChange()
        {
            var oldStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\File.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File"
            };
            var scanStub = new StubIFile()
            {
                FileLocationGet = () => "D:\\fFile.avi",
                ExtensionGet = () => ".avi",
                FileNameGet = () => "File"
            };
            var old = new List<IFile>(){
                oldStub
            };
            var scan = new List<IFile>(){
                scanStub
            };


            var comparer = new FilesComparer(old);
            IEnumerable<ScanCompareResult> result = comparer.Compare(scan);

            var comparedResult = result.Single();
            Assert.AreEqual(oldStub.FileLocationGet(), comparedResult.OldScan.FileLocation);
            Assert.AreEqual(CompareResult.NoChange, comparedResult.Result);
        }
    }
}
