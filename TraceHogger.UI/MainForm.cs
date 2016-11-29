using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TH.DataAccess.Blocks;
using TH.DataAccess.Repositories;
using TraceHogger.Helpers;
using TraceHogger.Services;

namespace TraceHogger.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            var tables = TableRepository.GetTables("MordorEV").ToList();

            clbTableList.Items.Clear();

            foreach (var table in tables)
            {
                clbTableList.Items.Add(table, CheckState.Unchecked);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var tables = clbTableList.CheckedItems.Cast<string>().ToList();

            var analyzer = new SingleTraceAnalyzer();

            var analyzedTraces = new List<TraceAnalysis>();

            foreach (var table in tables)
            {
                var rows = TraceRowRepository.GetRows(table);
                var analysis = analyzer.InitAnalysis(rows, table);
                analyzedTraces.Add(analysis);

                rtbAnalysisResults.AppendText(TraceAnalysisOutputHelper.OutputBasicStats(analysis, Convert.ToInt32(nudNumberOfRows.Value)));
                rtbAnalysisResults.AppendText("###### ###### ###### ###### ###### ###### ------------------------------------------------------------- * -->>");
                rtbAnalysisResults.AppendText(Environment.NewLine + Environment.NewLine);
            }

            rtbAnalysisResults.AppendText(TraceAnalysisOutputHelper.OutputCombinedStats(analyzedTraces));

            var multiAnalyzer = new MultiTraceAnalyzer();

            multiAnalyzer.FindFlocks(analyzedTraces);

            rtbAnalysisResults.SelectionStart = rtbAnalysisResults.Text.Length;
            rtbAnalysisResults.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbAnalysisResults.Clear();
        }
    }
}
