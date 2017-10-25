using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace cs_r_editor
{
    public class RModel
    {
        protected string mName = "R Program";

        [ReadOnly(true)]
        public string Description
        {
            get { return "R Model"; }
        }

        public RModel()
        {
            WorkingDirectory = Path.Combine(AppDirectory, "R", "R-3.1.3", "bin");
            mID = Guid.NewGuid().ToString();
        }

        private static string AppDirectory
        {
            get
            {
                return System.Windows.Forms.Application.StartupPath;
            }
        }


        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }

        [ReadOnly(true)]
        public string Type
        {
            get { return "R Model"; }
        }

        private string mID = "";
        [Browsable(false)]
        public string ID
        {
            get { return mID; }
        }

        [Browsable(false)]
        public bool IsInputMultiVariables
        {
            get { return true; }
        }

        [Browsable(false)]
        public double TrainingPercentage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void Update()
        {
            mSources.Clear();
            foreach (string file in Directory.GetFiles(mWorkingDirectory, "*.csv"))
            {
                mSources.Add(Path.GetFileName(file));
            }
            mScripts.Clear();
            foreach (string file in Directory.GetFiles(mWorkingDirectory, "*.R"))
            {
                mScripts.Add(Path.GetFileName(file));
            }
        }

        public void SaveFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public RModel Clone()
        {
            RModel clone = new RModel();
            clone.Copy(this);
            return clone;
        }

        public void Copy(RModel rhs)
        {
            RModel rhs2 = rhs as RModel;
            mName = rhs2.mName;
            mSources.AddRange(rhs2.mSources);
            mWorkingDirectory = rhs2.mWorkingDirectory;
        }

        protected List<string> mSources = new List<string>();
        [Browsable(false)]
        public List<string> Sources
        {
            get { return mSources; }
        }

        protected List<string> mScripts = new List<string>();
        [Browsable(false)]
        public List<string> Scripts
        {
            get { return mScripts; }
        }

        protected string mWorkingDirectory = "";
        [DisplayName("Working Directory")]
        public string WorkingDirectory
        {
            get { return mWorkingDirectory; }
            set
            {
                mWorkingDirectory = value;
                Update();
            }
        }

        [Browsable(false)]
        public List<double> XValues
        {
            get { throw new NotImplementedException(); }
        }

        [Browsable(false)]
        public List<double> YValues
        {
            get { throw new NotImplementedException(); }
        }

        [Browsable(false)]
        public int InputDimension
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        [Browsable(false)]
        public int OutputDimension
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private object mTag = null;
        [Browsable(false)]
        public object Tag
        {
            get
            {
                return mTag;
            }
            set
            {
                mTag = value;
            }
        }

        public string GetFullPath(string filename)
        {
            return Path.Combine(mWorkingDirectory, filename);
        }

        private static Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
        public static List<string> SplitCSV(string input)
        {
            List<string> items = new List<string>();
            foreach (Match match in csvSplit.Matches(input))
            {
                items.Add(match.Value.TrimStart(',').Replace("\"", "").Trim());
            }

            return items;
        }

        public string LoadScript(string filepath)
        {
            string content = "";
            using (StreamReader reader = new StreamReader(filepath))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        public DataTable LoadData(string filepath)
        {
            DataTable table = new DataTable();
            List<string> columnHeaders = new List<string>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = null;
                bool firstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLine)
                    {
                        firstLine = false;
                        List<string> columns = SplitCSV(line);
                        foreach (string columnHeader in columns)
                        {
                            columnHeaders.Add(columnHeader);
                            table.Columns.Add(columnHeader);
                        }
                        continue;
                    }
                    List<string> cells = SplitCSV(line);
                    DataRow row = table.NewRow();
                    for (int i = 0; i < cells.Count; ++i)
                    {
                        row[columnHeaders[i]] = cells[i];
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public string ScriptEnginePath
        {
            get
            {
                return Path.Combine(AppDirectory, "R", "R-3.1.3", "bin", "Rscript.exe");
            }
        }

        public void SaveScript(string filepath, string script_content)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(script_content);
            }
        }
    }
}
