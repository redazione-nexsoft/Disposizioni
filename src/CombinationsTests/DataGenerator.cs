using Combinations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace CombinationsTests
{
    [TestClass]
    public class DataGenerator
    {

        // ** RIMUOVERE L'ATTRIBUTO IGNORE SE SI DESIDERA GENERARE I DATI ** //
        [TestMethod]
        [Ignore]
        public async Task Generate()
        {
            var records = await RunStats();
            
            var fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "records.csv");

            await SaveRecords(records, fileName);

            System.Diagnostics.Debug.Print($"File: {fileName}");
		}

        private async Task<Record[]> RunStats()
        {
            var ret = new BlockingCollection<Record>();
            var setSizes = new int[] { 2, 5, 10 };
            var regSizes = new int[] { 1, 2, 5, 7 };
            var tasks = new List<Task>();
            for(int i = 0; i < setSizes.Length; i++)
            {
                var elementi = GeneraElementi(setSizes[i]);
                for(int k = 0; k < regSizes.Length; k++)
                {
                    var task = RunStats(ret, elementi, regSizes[k]);
                }
            }

            await Task.WhenAll(tasks.ToArray());

            return ret.ToArray();            
        }

        private int[] GeneraElementi(int numeroElementi)
        {
            Random rnd = new Random();
            int[] ret = new int[numeroElementi];
            for(int i = 0; i < numeroElementi; i++)
            {
                ret[i] = rnd.Next();
            }
            return ret;
        }

        private async Task RunStats<T>(BlockingCollection<Record> ret, T[] elementi, int numeroPostazioni)
        {
            var record = new Record
            {
                NumeroElementi = elementi.Length,
                NumeroPostazioni = numeroPostazioni,
            };

            var t = new Stopwatch();
            t.Start();
            var combinazioni = LinearIterations.Combina(elementi, numeroPostazioni);
            t.Stop();
            record.NumeroCombinazioni = combinazioni.Length;
            record.TempoEsecuzione1 = t.Elapsed.TotalSeconds;
            record.Throughput1 = (record.TempoEsecuzione1 > 0) ? (record.NumeroCombinazioni / record.TempoEsecuzione1) : record.NumeroCombinazioni;

            t.Start();
            combinazioni = RecursiveIterations.Combina(elementi, numeroPostazioni);
            t.Stop();
            record.TempoEsecuzione2 = t.Elapsed.TotalSeconds;
            record.Throughput2 = (record.TempoEsecuzione2 > 0) ? (record.NumeroCombinazioni / record.TempoEsecuzione2) : record.NumeroCombinazioni;

            ret.Add(record);
            await Task.CompletedTask;
        }

        private async Task SaveRecords(Record[] records, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var writer = new StreamWriter(stream);
                var row = MakeHeader();
                await writer.WriteLineAsync(row);
                foreach (var record in records)
                {
                    row = MakeRow(record);
                    await writer.WriteLineAsync(row);
                }
                await writer.FlushAsync();
            }
        }

        private string MakeHeader()
        {
            return "Numero Elementi;Numero Postazioni;Numero Combinazioni;Tempo Esecuzione (Linear);Throughput (Linear);Tempo Esecuzione (Recursive);Throughput (Recursive)";
        }

        private string MakeRow(Record record)
        {
            FormattableString str = $"{record.NumeroElementi}; {record.NumeroPostazioni}; {record.NumeroCombinazioni}; {record.TempoEsecuzione1:0.#######}; {record.Throughput1:0.###}; {record.TempoEsecuzione2:0.#######}; {record.Throughput2:0.###}";
            return str.ToString(CultureInfo.CurrentCulture);
        }

        public class Record
        {
            public int NumeroElementi { get; set; }
            public int NumeroPostazioni { get; set; }
            public int NumeroCombinazioni { get; set; }
            public double TempoEsecuzione1 { get; set; }
            public double Throughput1 { get; set; }
            public double TempoEsecuzione2 { get; set; }
            public double Throughput2 { get; set; }
        }

	}
}
