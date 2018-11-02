using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace AgentLogApp
{
    public partial class AgentLogWindow : Form
    {
        string agentlogPath = @"C:\Users\waleed\Documents\Visual Studio 2012\Projects\ItemShopAgentWeb\ItemShopAgentWeb\AgentWatchLog";
        private Thread _thread = null;
        delegate void SetTextCallBack(string text);
        string Tokens = "";
        string ProcessTokens = "";
        DataTable processDataTable = new DataTable();

        public AgentLogWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProcess();

            FillProcessTokens();

            InitilaizeTokens();

            File.WriteAllLines(agentlogPath + @"\AgentLog.txt", new string[] { });
            this._thread = new Thread(new ThreadStart(this.ReadFromFile));
            this._thread.Start();
        }

        private void InitilaizeTokens()
        {
            string brokerTokens = @"(?<Broker>CatalogueAgent|PurchaseAgent|ProfileMonitorAgent|StockAgent|DeliveryAgent|LostGoodAgent|InteractionAgent|CustomerContactAgent|SearchAgent|CompetitiveAgent)";

            string agentTokens = @"(?<Agent>CustomerAgent|AdminAgent)";

            string actTokens = @"(?<Act>Inform|QueryIf|Request)";

            string otherTextTokens = "(?<Other>is sending message to |reply message to |Creating Message...|" +
                                        "Saving Message Parameter...|Saving Message Content Type...|Saving Message Content...|" +
                                        "has sent the message and waiting for reply... |has received the message...|" +
                                        "Processing Data...|Validating Data...|Executing Message...|" +
                                        "Processing records...|Validating records...|Getting records...|" +
                                        "Counting Matched Records...|Gathering Records...|Counting Records...|" +
                                        "Checking Count...|Calculating New Key...)";

            Tokens = @"" + actTokens + "|" + otherTextTokens + "|" + agentTokens + "|" + brokerTokens + "|" + ProcessTokens;
        }

        public void ReadFromFile()
        {
            try
            {

                long offset = 0;

                FileSystemWatcher fsw = new FileSystemWatcher
                {
                    Path = agentlogPath,
                    Filter = "AgentLog.txt"
                };

                FileStream file = File.Open(
                    agentlogPath + @"\AgentLog.txt",
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Write);

                StreamReader reader = new StreamReader(file);
                while (true)
                {
                    fsw.WaitForChanged(WatcherChangeTypes.Changed);

                    file.Seek(offset, SeekOrigin.Begin);
                    if (!reader.EndOfStream)
                    {
                        while (!reader.EndOfStream)
                        {
                            SetText(reader.ReadToEnd());
                        }
                        offset = file.Position;
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void SetText(string text)
        {
            try
            {
                if (this.agentLogrtb.InvokeRequired)
                {
                    SetTextCallBack d = new SetTextCallBack(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.agentLogrtb.Text += text;
                }
            }
            catch (Exception)
            {

            }

        }

        private void GetProcess()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Integrated Security=True;Initial Catalog=TroposDB;Data Source=.");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Capability where ProjectId = 1", conn);
                cmd.CommandType = CommandType.Text;

                SqlParameter sqlParameterProjectId = cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
                sqlParameterProjectId.Direction = ParameterDirection.Input;
                sqlParameterProjectId.Value = 1;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(processDataTable);
                conn.Close();

            }
            catch (Exception)
            {

            }
        }

        private void FillProcessTokens()
        {
            try
            {

                ProcessTokens = @"(?<Process>";
                for (int i = 0; i < processDataTable.Rows.Count; i++)
                {
                    ProcessTokens += processDataTable.Rows[i]["Name"].ToString().TrimEnd() + "Capability";

                    if ((i + 1) == processDataTable.Rows.Count)
                    {
                        ProcessTokens += ")";
                    }
                    else
                    {
                        ProcessTokens += "|";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void agentLogrtb_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Regex rex = new Regex(Tokens);
                MatchCollection mc = rex.Matches(agentLogrtb.Text);
                int startCursorPosition = agentLogrtb.SelectionStart;
                foreach (Match m in mc)
                {
                    int startIndex = m.Index;
                    int stopIndex = m.Length;
                    if (m.Groups["Broker"].Success == true)
                    {
                        agentLogrtb.Select(startIndex, stopIndex);
                        agentLogrtb.SelectionColor = Color.Blue;

                    }
                    else if (m.Groups["Agent"].Success == true)
                    {
                        agentLogrtb.Select(startIndex, stopIndex);
                        agentLogrtb.SelectionColor = Color.Blue;

                    }
                    else if (m.Groups["Other"].Success == true)
                    {
                        agentLogrtb.Select(startIndex, stopIndex);
                        agentLogrtb.SelectionColor = Color.Black;

                    }
                    else if (m.Groups["Act"].Success == true)
                    {
                        agentLogrtb.Select(startIndex, stopIndex);
                        agentLogrtb.SelectionColor = Color.Green;

                    }
                    else if (m.Groups["Process"].Success == true)
                    {
                        agentLogrtb.Select(startIndex, stopIndex);
                        agentLogrtb.SelectionColor = Color.Red;
                    }
                    else
                    {

                    }
                    agentLogrtb.SelectionStart = startCursorPosition;
                    agentLogrtb.SelectionLength = 0;
                    agentLogrtb.SelectionColor = Color.Black;

                }

            }
            catch (Exception)
            {

            }
        }
    }
}
